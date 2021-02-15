/*
 * Ashton Lively
 * ConeOfVision.cs
 * Assignment 3
 * Contains behavior for the guards' cones of vision and detecting the player.
 */

using UnityEngine;

public class ConeOfVision : MonoBehaviour
{
    [Tooltip("The guard the cone is attached to.")]
    public GameObject guard;
    /// <summary>
    /// GuardBehavior script attached to the guard
    /// </summary>
    private GuardBehavior guardBehavior;

    private void Awake()
    {
        guardBehavior = guard.GetComponent<GuardBehavior>();     
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            guardBehavior.PlayerDetectedInCone();
        }
    }
}
