using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Players : MonoBehaviour
{
    public GameController.TeamColor thisTeam;
    public LayerMask enemyTeam;

    public bool onPoint = false;
    public bool canAttack = true;
    public bool dead = false;

    public float speed;
    public int health = 3;

    public CapturePointManager capturePoint;
    public SpawnManager spawner;

    public Vector3 target;

    private void Awake()
    {
        capturePoint = FindObjectOfType<CapturePointManager>();
    }

    /// <summary>
    /// Respawn NPC
    /// </summary>
    public virtual void Respawn()
    {
        if (dead)
        {
            transform.position = spawner.GetPosition();
        }
    }

    /// <summary>
    /// NPC takes damage
    /// </summary>
    public virtual void TakeDamage()
    {
        health--;

        if (health <= 0)
        {
            dead = true;
            gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// Attack in range.
    /// </summary>
    /// <param name="targets">Targets hit by the attack.</param>
    public IEnumerator Attack(Collider2D[] targets)
    {
        canAttack = false;

        transform.localScale = new Vector3(4, 4, 1);

        foreach (Collider2D target in targets)
        {
            target.GetComponent<Players>().TakeDamage();
        }
        // Delay next attack
        yield return new WaitForSeconds(1f);

        transform.localScale = new Vector3(3, 3, 1);

        canAttack = true;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<CapturePoint>().activePoint)
        {
            onPoint = true;
            collision.GetComponent<CapturePoint>().AddPlayer(thisTeam);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<CapturePoint>().activePoint)
        {
            onPoint = false;
            collision.GetComponent<CapturePoint>().RemovePlayer(thisTeam);
        }
    }
}
