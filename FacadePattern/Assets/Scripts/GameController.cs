﻿/*
 * Ashton Lively
 * GameController.cs
 * Assignment 11
 * Controls the capture points and spawn behavior of players.
 */
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public enum TeamColor { RED, BLUE }

    private CapturePointManager capturePoint;
    private AIManager ai;
    public SpawnManager red;
    public SpawnManager blue;
    private PlayerBehavior player;
    private UIManager ui;

    private LayerMask blueMask;
    private LayerMask redMask;

    // Values for the player set
    private bool chosenTeam;
    private TeamColor playerTeam;
    private SpawnManager playerSpawn;
    private LayerMask enemy;
    private LayerMask team;

    IEnumerator Start()
    {
        Time.timeScale = 1;

        blueMask = LayerMask.NameToLayer("Blue");
        redMask = LayerMask.NameToLayer("Red");

        player = FindObjectOfType<PlayerBehavior>();
        capturePoint = FindObjectOfType<CapturePointManager>();
        ai = FindObjectOfType<AIManager>();
        ui = FindObjectOfType<UIManager>();

        // Wait for player to select team
        while (!chosenTeam)
        {
            yield return null;
        }

        player.SetValues(playerTeam, playerSpawn, enemy, team);
        player.Respawn();

        ai.CreateAIs(playerTeam);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
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
        StartCoroutine(ui.DisplayCaptured());

        switch (teamColor)
        {
            case (TeamColor.RED):
                capturePoint.AdvanceRed();
                red.Advance();
                blue.Advance();
                break;

            case (TeamColor.BLUE):
                capturePoint.AdvanceBlue();
                blue.Retreat();
                red.Retreat();
                break;
        }

        StopCoroutine(ai.RespawnWaves());
        ai.RespawnAI();
        ai.RerouteAI();

        StopCoroutine(player.WaitForRespawn());
        player.Respawn();
    }

    /// <summary>
    /// End the game
    /// </summary>
    /// <param name="winner">Who won?</param>
    public void GameOver(TeamColor winner)
    {
        StopCoroutine(ai.RespawnWaves());

        StopCoroutine(player.Interact());

        ui.DetermineWinner(winner);
    }
}
