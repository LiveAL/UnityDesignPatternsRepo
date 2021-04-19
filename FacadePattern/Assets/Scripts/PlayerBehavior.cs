using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : Players
{
    public SpriteRenderer sr;
    public Collider2D coll;

    private Color redColor = new Color(0.8584906f, 0.3361071f, 0.3361071f, 1);
    private Color blueColor = new Color(0.244304f, 0.5851645f, 0.8490566f, 1);

    // Start is called before the first frame update
    void Start()
    {
        speed = 5;
        sr = GetComponent<SpriteRenderer>();
        coll = GetComponent<Collider2D>();
    }

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

            StopCoroutine(Interact());
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
            transform.position = spawner.GetPosition();
            coll.enabled = true;
            sr.enabled = true;

            dead = false;

            StartCoroutine(Interact());

        }
    }

    public IEnumerator WaitForRespawn()
    {
        yield return new WaitForSeconds(10f);

        Respawn();
    }

    public IEnumerator Interact()
    {
        while (true)
        {
            // Move
            float xMove = Input.GetAxis("Horizontal");
            float yMove = Input.GetAxis("Vertical");

            Vector3 move = new Vector3(xMove, yMove, 0).normalized;

            transform.position += (move * speed * Time.deltaTime);

            // Attack
            if (Input.GetMouseButtonDown(0) && canAttack)
            {
                Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 2f, enemyTeam);

                if (hits != null)
                {
                    Attack(hits);
                }
            }

            yield return null;
        }
    }
}
