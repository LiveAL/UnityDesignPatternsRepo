/*
 * Ashton Lively
 * Players.cs
 * Assignment 11
 * Player behavior in the game. May be AI or the player controlled character.
 */

using System.Collections;
using UnityEngine;

public abstract class Players : MonoBehaviour
{
    [HideInInspector] public GameController.TeamColor thisTeam;
    [HideInInspector] public LayerMask enemyTeam;

    [HideInInspector] public bool onPoint = false;
    [HideInInspector] public bool canAttack = true;
    [HideInInspector] public bool dead = false;

    [HideInInspector] public float speed;
    [HideInInspector] public int health;

    [HideInInspector] public CapturePointManager capturePoint;
    [HideInInspector] public SpawnManager spawner;

    [HideInInspector] public Vector3 target;

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

        // Player is dead
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

        // Visualize attack
        transform.localScale = new Vector3(4, 4, 1);

        foreach (Collider2D target in targets) // Enemies in range take damage
        {
            target.gameObject.GetComponent<Players>().TakeDamage();
        }

        // Delay next attack
        yield return new WaitForSeconds(1f);

        // Visualize ready to attack again
        transform.localScale = new Vector3(3, 3, 1);

        canAttack = true;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<CapturePoint>().activePoint)
        {
            // Add to list of players on the point
            onPoint = true;
            collision.GetComponent<CapturePoint>().AddPlayer(thisTeam);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<CapturePoint>().activePoint)
        {
            // Remove from list of players on the point
            onPoint = false;
            collision.GetComponent<CapturePoint>().RemovePlayer(thisTeam);
        }
    }
}
