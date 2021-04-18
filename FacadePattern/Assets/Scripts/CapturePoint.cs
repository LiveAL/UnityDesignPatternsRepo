/*
 * Ashton Lively
 * CapturePoint.cs
 * Assignment 11
 * Control point the player/AI are trying to capture.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapturePoint : MonoBehaviour
{
    [Tooltip("Is this the last point to capture?")]
    public bool terminal;

    [Tooltip("Previous capture point.")]
    public CapturePoint previous;
    [Tooltip("Next capture point.")]
    public CapturePoint next;

    private Vector3 location;

    // Start is called before the first frame update
    void Start()
    {
        location = transform.position;
    }

    public Vector3 GetLocation()
    {
        return location;
    }

    private int blueProgress = 0;
    private int redProgress = 0;

    // List of teams on the point

    // Record entering and exiting events. Begin capture if only one team. 
}
