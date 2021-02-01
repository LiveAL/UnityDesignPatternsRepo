/*
 * Ashton Lively
 * Swordsman.cs
 * Assignment 1
 * Contains behavior for swordsman enemies to attack and seek foes. 
 */
using System.Collections;
using UnityEngine;

public class Swordsman : Enemy, IHasWeapon, IMeleeAttacker
{
    /// <summary>
    /// Swordsman walking speed
    /// </summary>
    private float moveSpeed;

    /// <summary>
    /// Is a weapon equipped?
    /// </summary>
    private bool equipped;

    /// <summary>
    /// Ammount of ammo remaining
    /// </summary>
    private int ammoAmount;

    /// <summary>
    /// Animator attached to the sword object
    /// </summary>
    private Animator swordAnim;

    private float distanceToOpponent = 10;

    // Start is called before the first frame update
    void Start()
    {
        setDamage(3);
        setEquippedStatus(true);
        setHitPoints(4);
        setNewOpponent("Archer");
        setTimeBetweenHits(1f);
        setMoveSpeed(.004f);

        swordAnim = gameObject.transform.Find("Sword").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveToEnemy();
    }

    private void MoveToEnemy()
    {
        // If opponent is null, get new opponent
        if (getOpponent() == null)
        {
            setNewOpponent("Archer");
        }

        // Move if the opponent is not in range
        if (getOpponent() != null && distanceToOpponent > 1.6f)
        {
            transform.position = Vector3.MoveTowards(transform.position, getOpponent().transform.position, moveSpeed);

            distanceToOpponent = Mathf.Abs(transform.position.x - getOpponent().transform.position.x);

            if (distanceToOpponent < 1.6f)
            {
                Attack();
            }
        }
    }

    /// <summary>
    /// Attack the opponent
    /// </summary>
    public override void Attack()
    {
        StartCoroutine(WaitForNextHit());
    }

    /// <summary>
    /// Delay the next attack
    /// </summary>
    /// <returns></returns>
    private IEnumerator WaitForNextHit()
    {
        while (getOpponent() != null)
        {
            yield return new WaitForSeconds(getTimeBetweenHits());

            // Update distance for sword swinging animation
            swordAnim.SetBool("Swinging", true);

            if (getOpponent() != null)
            {
                // Current HP of opponent
                int currentHP = getOpponent().GetComponent<Enemy>().getHitPoints();

                // Damage opponent for damage amount 
                getOpponent().GetComponent<Enemy>().setHitPoints(currentHP - damage);
            }
        }

        // Update distance for sword swinging animation
        swordAnim.SetBool("Swinging", false);
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
    /// Get the walking speed of the swordsman
    /// </summary>
    /// <returns>The swordsman walking speed</returns>
    public float getMoveSpeed()
    {
        return moveSpeed;
    }
    /// <summary>
    /// Set the walking speed of the swordsman
    /// </summary>
    /// <param name="speed">New walking speed</param>
    public void setMoveSpeed(float speed)
    {
        moveSpeed = speed;
    }

    
}
