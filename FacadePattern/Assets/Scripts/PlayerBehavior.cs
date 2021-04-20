using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehavior : Players
{
    private SpriteRenderer sr;
    private Collider2D coll;

    private Color redColor = new Color(0.8584906f, 0.3361071f, 0.3361071f, 1);
    private Color blueColor = new Color(0.244304f, 0.5851645f, 0.8490566f, 1);

    public GameObject respawnTime;
    public Text respawnTimer;

    // Start is called before the first frame update
    void Start()
    {
        speed = 6;

        sr = GetComponent<SpriteRenderer>();
        coll = GetComponent<Collider2D>();

        health = 10;
    }

    /// <summary>
    /// Set player values
    /// </summary>
    /// <param name="color">Color of the player's team</param>
    /// <param name="spawner">Spawner for the player's team</param>
    /// <param name="enemyTeamMask">Layermask the enemy team is on</param>
    /// <param name="thisTeamMask">Layermask the player's team is on</param>
    public void SetValues(GameController.TeamColor color, SpawnManager spawner, LayerMask enemyTeamMask, LayerMask thisTeamMask)
    {
        thisTeam = color;
        enemyTeam = enemyTeamMask;
        this.spawner = spawner;
        gameObject.layer = thisTeamMask;

        if (color == GameController.TeamColor.RED)
            sr.color = redColor;
        else
            sr.color = blueColor;

        dead = true;

        Respawn();
        StartCoroutine(Interact());
    }

    /// <summary>
    /// NPC takes damage
    /// </summary>
    public override void TakeDamage()
    {
        health--;

        if (health <= 0)
        {
            dead = true;
            coll.enabled = false;
            sr.enabled = false;

            StartCoroutine(WaitForRespawn());
        }
    }

    /// <summary>
    /// Respawn NPC
    /// </summary>
    public override void Respawn()
    {
        if (dead)
        {
            respawnTime.SetActive(false);

            transform.position = spawner.GetPosition();
            coll.enabled = true;
            sr.enabled = true;

            health = 6;

            dead = false;

            transform.localScale = new Vector3(3, 3, 1);

            canAttack = true;
        }
    }

    /// <summary>
    /// Player waits to respawn after death.
    /// </summary>
    /// <returns></returns>
    public IEnumerator WaitForRespawn()
    {
        canAttack = false;
        respawnTime.SetActive(true);

        float timeLeft = 5;
        respawnTimer.text = "Time to respawn: " + timeLeft;

        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(1f);
            timeLeft--;
            respawnTimer.text = "Time to respawn: " + timeLeft;
        }
        
        Respawn();
    }

    /// <summary>
    /// Player may use their controls
    /// </summary>
    public IEnumerator Interact()
    {
        while (true)
        {
            // Move
            float xMove = Input.GetAxis("Horizontal");
            float yMove = Input.GetAxis("Vertical");

            Vector3 move = new Vector3(xMove, yMove, 0).normalized;
            transform.Translate(move * speed * Time.deltaTime);

            // Attack
            if (Input.GetMouseButtonDown(0) && canAttack)
            {
                Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 2f, (1<<enemyTeam));

                if (hits.Length > 0)
                {
                    StartCoroutine(Attack(hits));
                }
            }

            yield return null;
        }
    }
}
