using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [Tooltip("Amount of the health")]
    public float hitPoints = 10;

    private bool moving = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Stop the enemy's movement
    /// </summary>
    public void FreezeMovement()
    {
        moving = false;
    }

    /// <summary>
    /// Update the amount of health remaining
    /// </summary>
    /// <param name="hp"></param>
    public void UpdateHitPoints(float hp)
    {
        Debug.Log(gameObject.name + " took damage.");
        hitPoints -= hp;

        if (hitPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
