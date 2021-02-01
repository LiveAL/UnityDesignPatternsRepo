/*
 * Ashton Lively
 * Archer.cs
 * Assignment 1
 * Contains behavior for archer enemies to attack. 
 */
using System.Collections;
using UnityEngine;

public class Archer : Enemy , IHasWeapon, IRangedAttacker
{
    /// <summary>
    /// Is a weapon equipped?
    /// </summary>
    private bool equipped;
    /// <summary>
    /// Amount of ammo remaining
    /// </summary>
    private int ammoAmount; 

    /// <summary>
    /// Arrow prefab
    /// </summary>
    private GameObject arrow;

    // Start is called before the first frame update
    void Start()
    {
        arrow = Resources.Load("Arrow") as GameObject;

        setDamage(1);
        setEquippedStatus(true);
        setHitPoints(12);
        setNewOpponent("Swordsman");
        setTimeBetweenHits(4f);
        setAmmoAmount(10);

        Attack();
    }

    /// <summary>
    /// Attack enemy
    /// </summary>
    public override void Attack()
    {
        if (getEquippedStatus())
        {
            StartCoroutine(WaitForHit(getTimeBetweenHits()));
        }
    }

    /// <summary>
    /// Delay the next attack 
    /// </summary>
    /// <param name="delay">Time between attacks</param>
    /// <returns></returns>
    IEnumerator WaitForHit(float delay)
    {
        while (getAmmoAmount() > 0)
        {
            // Get new opponent if no opponent is tracked
            if (getOpponent() == null)
            {
                setNewOpponent("Swordsman");
            }

            yield return new WaitForSeconds(delay);

            if (getOpponent() != null)
            {
                // Instantiate arrow at origin of bow sprite
                Vector2 bowPos = GameObject.Find("Bow").transform.position;
                Quaternion bowRot = GameObject.Find("Bow").transform.rotation;
                Instantiate(arrow, bowPos, bowRot);

                setAmmoAmount(getAmmoAmount() - 1);
            }
        }
    }

    /// <summary>
    /// Set whether or not the weapon is equipped
    /// </summary>
    /// <param name="equipped">Is the weapon equipped?</param>
    public void setEquippedStatus(bool equipped)
    {
        this.equipped = equipped;
    }
    /// <summary>
    /// Get whether or not the weapon is equipped
    /// </summary>
    /// <returns>True if weapon equipped</returns>
    public bool getEquippedStatus()
    {
        return equipped;
    }

    /// <summary>
    /// Set the amounnt of ammo remaining
    /// </summary>
    /// <param name="ammo">Amount of ammo remaining</param>
    public void setAmmoAmount(int ammo)
    {
        ammoAmount = ammo;
    }

    /// <summary>
    /// Get the ammo remaining amount
    /// </summary>
    /// <returns>Amount of ammo remaining</returns>
    public int getAmmoAmount()
    {
        return ammoAmount;
    }
}
