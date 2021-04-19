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

    public AIManager ai;

    public SpawnManager red;
    public SpawnManager blue;

    public LayerMask blueMask;
    public LayerMask redMask;

    public PlayerBehavior player;
    private bool chosenTeam;
    private TeamColor playerTeam;
    private SpawnManager playerSpawn;
    private LayerMask enemy;
    private LayerMask team;

    IEnumerator Start()
    {
        player = FindObjectOfType<PlayerBehavior>();

        // Wait for player to select team
        while (!chosenTeam)
        {
            yield return null;
        }

        player.SetValues(playerTeam, playerSpawn, enemy, team);
        player.Respawn();

        ai.CreateAIs(playerTeam);
    }

    /// <summary>
    /// Set the team the player uses
    /// </summary>
    /// <param name="color"></param>
    public void SetPlayerTeam(string color)
    {
        if (color == "red")
        {
            playerTeam = TeamColor.RED;
            playerSpawn = red;
            enemy = blueMask;
            team = redMask;
        }
        else
        {
            playerTeam = TeamColor.BLUE;
            playerSpawn = blue;
            enemy = redMask;
            team = blueMask;
        }

        chosenTeam = true;
    }

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

        StopCoroutine(ai.RespawnWaves(30));
        ai.RespawnAI();
        StartCoroutine(ai.RespawnWaves(30));
        ai.RerouteAI();

        StopCoroutine(player.WaitForRespawn());
        player.Respawn();
    }

    public void GameOver(TeamColor winner)
    {
        StopCoroutine(ai.RespawnWaves(30));

        StopCoroutine(player.Interact());
    }
}
