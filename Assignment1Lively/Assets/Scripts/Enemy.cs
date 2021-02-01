/*
 * Ashton Lively
 * Enemy.cs
 * Assignment 1
 * Enemy parent class. Contains fields for combat attributes and methods for using them. 
 */
using UnityEngine;
using UnityEngine.UI;

public abstract class Enemy : MonoBehaviour
{
    /// <summary>
    /// The amount of health the enemy has
    /// </summary>
    protected int hitPoints;

    /// <summary>
    /// The amount of damage enemy deals
    /// </summary>
    protected int damage;

    /// <summary>
    /// How long does it take for the enemy to attack again
    /// </summary>
    protected float timeBetweenHits;

    /// <summary>
    /// The current opponent of the enemy
    /// </summary>
    protected GameObject opponent;

    public abstract void Attack();

    /// <summary>
    /// Set the amount of health left
    /// </summary>
    /// <param name="newHitPoints">The new amount of health left</param>
    public void setHitPoints(int newHitPoints)
    {
        hitPoints = newHitPoints;
        // Set NPC hover stats
        GetComponentInChildren<Text>().text = hitPoints.ToString();

        // Destroy when health is depleted
        if (getHitPoints() < 1)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Get the amount of health left
    /// </summary>
    /// <returns>Amount of health remaining</returns>
    public int getHitPoints() { return hitPoints; }

    /// <summary>
    /// Set the amount of damage that can be dealt
    /// </summary>
    /// <param name="newDamage">New amount of damage dealt</param>
    public void setDamage(int newDamage) { damage = newDamage; }
    /// <summary>
    /// Get the amount of damage that can be dealt
    /// </summary>
    /// <returns></returns>
    public int getDamage() { return damage; }

    /// <summary>
    /// Set the time delay between strikes
    /// </summary>
    /// <param name="newTimeBetweenHits">New time delay</param>
    public void setTimeBetweenHits(float newTimeBetweenHits) { timeBetweenHits = newTimeBetweenHits;  }
    /// <summary>
    /// Get the time delay between strikes
    /// </summary>
    /// <returns></returns>
    public float getTimeBetweenHits() { return timeBetweenHits; }

    /// <summary>
    /// Set a new opponent to fight
    /// </summary>
    /// <param name="tagOfEnemy">Tag for the enemy type</param>
    public void setNewOpponent(string tagOfEnemy)
    {
       opponent = GameObject.FindGameObjectWithTag(tagOfEnemy);
    }
    /// <summary>
    /// Get the current opponent
    /// </summary>
    /// <returns>The current opponent</returns>
    public GameObject getOpponent() { return opponent; }
}
