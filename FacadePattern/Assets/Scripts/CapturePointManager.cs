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

    private GameController gc;

    private void Start()
    {
        gc = FindObjectOfType<GameController>();
    }

    public void AdvanceBlue()
    {
        if (capture.IsPreviousTerminus())
            capture = capture.previous;
        else
        {
            // blue wins
            gc.GameOver(GameController.TeamColor.BLUE);
        }
    }

    public void AdvanceRed()
    {
        if (!capture.IsNextTerminus())
            capture = capture.next;
        else
        {
            // red wins
            gc.GameOver(GameController.TeamColor.RED);
        }
    }

    public Vector3 GetCaptureTarget()
    {
        return capture.GetLocation();
    }
}
