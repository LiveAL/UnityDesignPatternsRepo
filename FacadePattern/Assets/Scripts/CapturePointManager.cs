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

    /// <summary>
    /// Blue has captured the point
    /// </summary>
    public void AdvanceBlue()
    {
        if (!capture.IsPreviousTerminus())
        {
            capture.activePoint = false;
            capture.GetComponent<SpriteRenderer>().color = Color.black;

            capture = capture.previous;
            capture.GetComponent<SpriteRenderer>().color = Color.white;
            capture.activePoint = true;
            StartCoroutine(capture.AdvanceProgress());
        }
        else
        {
            // blue wins
            gc.GameOver(GameController.TeamColor.BLUE);
        }
    }

    /// <summary>
    /// Red has captured the point
    /// </summary>
    public void AdvanceRed()
    {
        if (!capture.IsNextTerminus())
        {
            capture.activePoint = false;
            capture.GetComponent<SpriteRenderer>().color = Color.black;

            capture = capture.next;
            capture.GetComponent<SpriteRenderer>().color = Color.white;
            capture.activePoint = true;
            StartCoroutine(capture.AdvanceProgress());
        }         
        else
        {
            // red wins
            gc.GameOver(GameController.TeamColor.RED);
        }
    }

    /// <summary>
    /// Get the next location to target
    /// </summary>
    public Vector3 GetCaptureTarget()
    {
        return capture.GetLocation();
    }
}
