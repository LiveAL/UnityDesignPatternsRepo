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

    private SpriteRenderer sr;
    private GameController gc;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        gc = FindObjectOfType<GameController>();

        location = transform.position;

        if(previous == false)
        {
            previousTerminus = true;
        }
        else if (next == false)
        {
            nextTerminus = true;
        }

        StartCoroutine(AdvanceProgress());
    }

    /// <summary>
    /// Is this the last point on the advance?
    /// </summary>
    public bool IsNextTerminus()
    {
        return nextTerminus;
    }

    /// <summary>
    /// Is this the last point on the retreat?
    /// </summary>
    public bool IsPreviousTerminus()
    {
        return previousTerminus;
    }

    /// <summary>
    /// Get location of the point
    /// </summary>
    public Vector3 GetLocation()
    {
        return location;
    }

    private int redNum = 0;
    private int blueNum = 0;

    /// <summary>
    /// Add to the amount of players on the point
    /// </summary>
    /// <param name="color">Team the player is on</param>
    public void AddPlayer(GameController.TeamColor color)
    {
        if (color == GameController.TeamColor.RED)
            redNum++;
        else
            blueNum++;

    }

    /// <summary>
    /// Subtract from the amount of players on the point
    /// </summary>
    /// <param name="color">Team the player removed is on</param>
    public void RemovePlayer(GameController.TeamColor color)
    {
        if (color == GameController.TeamColor.RED)
            redNum--;
        else
            blueNum--;

    }

    /// <summary>
    /// Change the color of the point for player progresses
    /// </summary>
    public IEnumerator AdvanceProgress()
    {
        while (activePoint)
        {
            // Advance red progress
            if (redNum > 0 && blueNum == 0)
            {
                sr.color = Color.Lerp(sr.color, redColor, (Time.deltaTime * 10));

                if (sr.color == redColor)
                {
                    if(!nextTerminus)
                        gc.PointCaptured(GameController.TeamColor.RED);
                    else
                        gc.GameOver(GameController.TeamColor.RED);
                }
                    
            }
            // Advance blue progress
            else if (blueNum > 0 && redNum == 0)
            {
                sr.color = Color.Lerp(sr.color, blueColor, (Time.deltaTime * 10));

                if (sr.color == blueColor)
                {
                    if(!previousTerminus)
                        gc.PointCaptured(GameController.TeamColor.BLUE);
                    else
                        gc.GameOver(GameController.TeamColor.BLUE);
                }
                    
            }

            yield return null;
        }
    }
}
