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
    /// <summary>
    /// Is this the last point to capture?
    /// </summary>
    private bool nextTerminus = false;
    private bool previousTerminus = false;

    [Tooltip("Previous capture point.")]
    public CapturePoint previous;
    [Tooltip("Next capture point.")]
    public CapturePoint next;

    public bool activePoint = false;

    private Vector3 location;

    private Color redColor = new Color(0.8584906f, 0.3361071f, 0.3361071f, 1);
    private Color blueColor = new Color(0.244304f, 0.5851645f, 0.8490566f, 1);

    // Start is called before the first frame update
    void Start()
    {
        location = transform.position;

        if(previous == false)
        {
            previousTerminus = true;
        }
        else if (next == false)
        {
            nextTerminus = true;
        }
    }

    public bool IsNextTerminus()
    {
        return nextTerminus;
    }

    public bool IsPreviousTerminus()
    {
        return previousTerminus;
    }

    public Vector3 GetLocation()
    {
        return location;
    }

    private int blueProgress = 0;
    private int redProgress = 0;

    // List of teams on the point

    // Record entering and exiting events. Begin capture if only one team. 
    // Lerp color towards the team capture
}
