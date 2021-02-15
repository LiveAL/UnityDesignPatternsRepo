/*
 * Ashton Lively
 * GuardBehavior.cs
 * Assignment 3
 * Contains behavior methods for patrol guards. Behavior changes based on the player. 
 */

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GuardBehavior : MonoBehaviour, IObserver
{
    /// <summary>
    /// Is the player sneaking?
    /// </summary>
    private bool playerSneaking = false;

    /// <summary>
    /// Is the player in shadow?
    /// </summary>
    private bool playerInShadow = false;

    /// <summary>
    /// Speed of the player
    /// </summary>
    private float playerSpeed;

    [Tooltip("The player object.")]
    public GameObject player;

    [Tooltip("UI game object above the guard.")]
    public GameObject statusUI;

    [Tooltip("The status text above the guard.")]
    public Text statusText;

    [Tooltip("Patrol points")]
    public List<Vector3> patrolPoints;

    public void UpdateData(bool playerInShadow, bool playerSneaking, float playerSpeed)
    {
        if (this.playerSneaking != playerSneaking)
        {
            this.playerSneaking = playerSneaking;
            ChangeConeOfVisionSize(playerSneaking);
        }

        if (this.playerInShadow != playerInShadow)
        {
            this.playerInShadow = playerInShadow;
        }

        this.playerSpeed = playerSpeed;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Add to observer list
        player.GetComponent<PlayerBehavior>().RegisterObserver(this);

        // Set status text to on patrol
        statusText.text = "On Patrol";
    }

    // Update is called once per frame
    void Update()
    {
        if (!pursuing)
        {
            Patrol();
            SearchInListeningArea();
        }
        else
        {
            Pursue();
        }
    }

    /// <summary>
    /// Move towards destination
    /// </summary>
    /// <param name="destination">Destination of the movement</param>
    private void Move(Vector3 destination)
    {
        // Rotate to face destination
        transform.up = destination - transform.position;

        // Move towards destination point 
        transform.position = Vector3.MoveTowards(transform.position, destination, 1.5f * Time.deltaTime);

        // Move label with the enemy
        statusUI.transform.position = new Vector3(transform.position.x, transform.position.y + .5f, 0);
    }

    [Tooltip("The cone of vision for the guard.")]
    public GameObject cone; 

    /// <summary>
    /// Size of the cone of vision when player is sneaking
    /// </summary>
    private Vector3 sneakingConeSize = new Vector3(0.47f, 0.62f, 0);
    /// <summary>
    /// Size of cone of visiomn when player is not sneaking
    /// </summary>
    private Vector3 regularConeSize = new Vector3(1, 1, 1);

    /// <summary>
    /// Change the size of the cone of vision
    /// </summary>
    /// <param name="sneaking">Is the player sneaking?</param>
    private void ChangeConeOfVisionSize(bool sneaking)
    {
        if (sneaking)
        {
            cone.transform.localScale = sneakingConeSize;
        }
        else
        {
            cone.transform.localScale = regularConeSize;
        }
    }

    /// <summary>
    /// Handles behavior when player has been detected in vision
    /// </summary>
    public void PlayerDetectedInCone()
    {
        // Check if in shadow
        if (!playerInShadow) // and how much movement took place
        {
            // Remove from observer list
            player.GetComponent<PlayerBehavior>().RemoveObserver(this);

            // Set cone to inactive 
            cone.SetActive(false);

            // Set status to alerted
            statusText.text = "Alerted";

            timeLeft = countdown;

            // Pursue player 
            pursuing = true;
        }
    }

    /// <summary>
    /// The current patrol point in patrolPoints
    /// </summary>
    private int patrolIndex = 0;

    /// <summary>
    /// Guard moves between set points
    /// </summary>
    private void Patrol()
    {
        // Move towards current patrol index
        Move(patrolPoints[patrolIndex]);

        // If point reached, start moving towards the next one
        if (patrolPoints[patrolIndex] == transform.position)
        {
            patrolIndex++;
            
            if (patrolIndex > patrolPoints.Count - 1)
            {
                patrolIndex = 0;
            }
        }
    }

    /// <summary>
    /// How many seconds 
    /// </summary>
    private float countdown = 1f;
    /// <summary>
    /// How much time is left in the countdown
    /// </summary>
    private float timeLeft;

    /// <summary>
    /// Is the guard pursuing the player?
    /// </summary>
    private bool pursuing = false;

    /// <summary>
    /// Pursue the player
    /// </summary>
    private void Pursue()
    {
        // Move towards player
        Move(player.transform.position);

        // Restart if player is reached
        if (transform.position == player.transform.position)
        {
            SceneManager.LoadScene(0);
        }

        // If player is out of range for long enough, stop pursuing 
        if (!Physics2D.OverlapCircle(transform.position, 2f, playerLayer))
        {
            timeLeft -= Time.deltaTime;

            if (timeLeft <= 0)
            {
                pursuing = false;

                // Add from observer list
                player.GetComponent<PlayerBehavior>().RegisterObserver(this);

                // Set cone to inactive 
                cone.SetActive(true);

                statusText.text = "On Patrol";
            }
        }
        else if (timeLeft != countdown)
        {
            timeLeft = countdown;
        }
    }

    [Tooltip("The player layer.")]
    public LayerMask playerLayer;

    /// <summary>
    /// Detect player in area the guard can hear in
    /// </summary>
    private void SearchInListeningArea()
    {
        if (!playerSneaking && playerSpeed > 0)
        {
            // Get overlapping player
            if (Physics2D.OverlapCircle(transform.position, 2f, playerLayer))
            {
                // Remove from observer list
                player.GetComponent<PlayerBehavior>().RemoveObserver(this);

                // Set cone to inactive 
                cone.SetActive(false);

                // Set status to alerted
                statusText.text = "Alerted";

                timeLeft = countdown;

                // Pursue player 
                pursuing = true;
            }
        }
    }
}
