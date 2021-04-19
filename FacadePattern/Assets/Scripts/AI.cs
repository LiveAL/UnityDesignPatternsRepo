/*
 * Ashton Lively
 * AI.cs
 * Assignment 11
 * Behavior for non playable characters to capture control points and
 * attack enemy opponents. 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : Players
{
    public void SetValues(GameController.TeamColor teamColor, SpawnManager spawner, LayerMask enemyTeam, LayerMask teamMask)
    {
        thisTeam = teamColor;
        this.spawner = spawner;
        this.enemyTeam = enemyTeam;

        gameObject.layer = teamMask;

        dead = true;

        speed = Random.Range(2, 5);

        SetTarget();
        Respawn();
        StartCoroutine(Move());
    }

    /// <summary>
    /// Is the NPC dead?
    /// </summary>
    /// <returns></returns>
    public bool GetDeathStatus()
    {
        return dead;
    }

    /// <summary>
    /// Set the position to move to
    /// </summary>
    public void SetTarget()
    {
        target = capturePoint.GetCaptureTarget();
    }

    /// <summary>
    /// Set the spawner the NPC uses
    /// </summary>
    /// <param name="spawner"></param>
    public void SetSpawner(SpawnManager spawner)
    {
        this.spawner = spawner;
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
            StopCoroutine(Move());
            gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// Respawn NPC
    /// </summary>
    public override void Respawn()
    {
        if (dead)
        {
            float xOffset = spawner.GetPosition().x + Random.Range(-1f, 1f);
            float yOffset = spawner.GetPosition().y + Random.Range(-1f, 1f);
            transform.position = new Vector3(xOffset, yOffset, 0);

            gameObject.SetActive(true);

            health = 3;

            dead = false;

            StartCoroutine(Move());
        }
    }

    /// <summary>
    /// Move towards point.
    /// </summary>
    private IEnumerator Move()
    {
        while (true)
        {
            // Move towards the capture point
            transform.position = Vector3.MoveTowards(transform.position, target, (speed * Time.deltaTime));

            if (canAttack)
            {
                Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, .5f, enemyTeam);

                if (hits.Length > 0)
                {
                    StartCoroutine(Attack(hits));
                }
            }

            yield return null;
        }
    }
}
