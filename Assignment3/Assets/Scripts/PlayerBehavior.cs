/*
 * Ashton Lively
 * PlayerBehavior.cs
 * Assignment 3
 * Contains methods for using player input and broadcasts stealth data to observers. 
 */

using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour, ISubject
{
    /// <summary>
    /// Observers in scene
    /// </summary>
    private List<IObserver> observers = new List<IObserver>();

    /// <summary>
    /// Is the player sneaking?
    /// </summary>
    private bool sneaking = false;

    /// <summary>
    /// Is the player in the shadows?
    /// </summary>
    private bool inShadow = false;

    /// <summary>
    /// Last position the player was in
    /// </summary>
    private Vector3 lastPos;

    public void NotifyObservers()
    {
        foreach (IObserver observer in observers)
        {
            observer.UpdateData(inShadow, sneaking, MovementAmount());
        }
    }

    public void RegisterObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        if (observers.Contains(observer))
        {
            observers.Remove(observer);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        lastPos = transform.position;
    }

    [Tooltip("Instructions panel.")]
    public GameObject instructions;

    [Tooltip("How to show instructions text.")]
    public GameObject openInstructionsPrompt;

    // Update is called once per frame
    void Update()
    {
        Move();
        Sneak();

        // Show or hide the instructions panel
        if (Input.GetKeyDown(KeyCode.Space))
        {
            openInstructionsPrompt.SetActive(false);
            instructions.SetActive(true);
            Time.timeScale = 0;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            openInstructionsPrompt.SetActive(true);
            instructions.SetActive(false);
            Time.timeScale = 1;
        }
    }

    /// <summary>
    /// Speed of movement
    /// </summary>
    private float speed = 2f;
    /// <summary>
    /// Speed of movement when sneaking
    /// </summary>
    private float sneakSpeed = 1.2f;
    /// <summary>
    /// Speed of movement when walking normally
    /// </summary>
    private float walkSpeed = 2f;
    /// <summary>
    /// Current movement distance
    /// </summary>
    private float lastRecordedMovement = 0;

    /// <summary>
    /// Player moves
    /// </summary>
    private void Move()
    {
        lastPos = transform.position;

        // Get inputted movement
        float xMove = Input.GetAxis("Horizontal");
        float yMove = Input.GetAxis("Vertical");

        // Get new position
        Vector3 move = new Vector3(xMove, yMove, 0);
        move *= Time.deltaTime * speed;

        transform.position += move;

        // Keep player in the camera's view
        float xClamp = Mathf.Clamp(transform.position.x, -8.69f, 8.69f);
        float yClamp = Mathf.Clamp(transform.position.y, -4.84f, 4.84f);

        transform.position = new Vector3(xClamp, yClamp, 0);

        // Check for speed increases to 0 or higher than 0
        if ((lastRecordedMovement == 0 && MovementAmount() != 0) || (lastRecordedMovement != 0 && MovementAmount() == 0))
        {
            lastRecordedMovement = MovementAmount();

            // Notify observers of movement
            NotifyObservers();
        }
    }

    /// <summary>
    /// Get the amount the player is moving
    /// </summary>
    /// <returns></returns>
    private float MovementAmount()
    {
        return Vector3.Distance(lastPos, transform.position);
    }

    /// <summary>
    /// Player sneaks
    /// </summary>
    private void Sneak()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !sneaking)
        {
            sneaking = true;
            GetComponent<SpriteRenderer>().transform.localScale = new Vector3(1.5f, 1, 1);
            speed = sneakSpeed;

            // Notify observers
            NotifyObservers();
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) && sneaking)
        {
            sneaking = false;
            GetComponent<SpriteRenderer>().transform.localScale = new Vector3(1.5f, 1.5f, 1);
            speed = walkSpeed;

            // Notify observers
            NotifyObservers();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Shadow")
        {
            // Set in shadow to true 
            inShadow = true;

            // Notify observers
            NotifyObservers();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Shadow")
        {
            // Set in shadow to false
            inShadow = false;

            // Notify observers
            NotifyObservers();
        }
    }
}
