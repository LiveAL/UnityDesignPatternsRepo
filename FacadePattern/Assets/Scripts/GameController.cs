/*
 * Ashton Lively
 * GameController.cs
 * Assignment 11
 * Controls the capture points and spawn behavior of players.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public enum TeamColor { RED, BLUE }

    private CapturePointManager capturePoint;

    private AIManager ai;

    public SpawnManager red;
    public SpawnManager blue;

    /// <summary>
    /// One team has successfully captured the active point.
    /// </summary>
    /// <param name="teamColor">Color of the team that captured the point.</param>
    public void PointCaptured(TeamColor teamColor)
    {
        switch (teamColor)
        {
            case (TeamColor.RED):
                red.Advance();
                blue.Retreat();
                capturePoint.AdvanceRed();
                break;

            case (TeamColor.BLUE):
                blue.Advance();
                red.Retreat();
                capturePoint.AdvanceBlue();
                break;
        }

        ai.RespawnAI();
        ai.RerouteAI();
    }
}
