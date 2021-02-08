/* 
 * Ashton Lively
 * EnemyBehavior.cs
 * Assignment 2
 * Contains the behavior for the enemies in game for movement and status.
 */
using UnityEngine;
using UnityEngine.UI;

public class EnemyBehavior : MonoBehaviour
{
    [Tooltip("Amount of the health")]
    public float hitPoints = 10;

    private bool moving = true;

    [Tooltip("Hit points text")]
    public Text hitPointsText;

    // Start is called before the first frame update
    void Awake()
    {
        hitPointsText.text = "Hit Points: " + hitPoints;
    }

    private Vector3 moveDirection = Vector3.left;
    private float timeElapsedOnMovement = 0;

    // Update is called once per frame
    void Update()
    {
        /*
        if (moving)
        {
            // Move in direction
            timeElapsedOnMovement += Time.deltaTime;
            transform.position += moveDirection * 0.8f * Time.deltaTime;

            // Switch move direction
            if (timeElapsedOnMovement >= 5f)
            {
                timeElapsedOnMovement = 0;
                moveDirection = new Vector3(moveDirection.x * -1, moveDirection.y, moveDirection.z);
            }
        }*/
        
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
        hitPoints -= hp;

        Debug.Log(gameObject.name + " took damage.");
        hitPointsText.text = "Hit Points: " + hitPoints;
        

        if (hitPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
