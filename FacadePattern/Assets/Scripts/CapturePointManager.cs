/*
 * Ashton Lively
 * CapturePointManager.cs
 * Assignment 11
 * Manage the current capture point and the next active.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapturePointManager : MonoBehaviour
{
    [Tooltip("The currently active capture point.")]
    public CapturePoint capture;

    public void AdvanceBlue()
    {
        capture = capture.previous;
        //Update visual 

        // Set to active and enabled
    }

    public void AdvanceRed()
    {
        capture = capture.previous;
        //Update visual 

        // Set to active and enabled
    }

    public Vector3 GetCaptureTarget()
    {
        return capture.GetLocation();
    }
}
