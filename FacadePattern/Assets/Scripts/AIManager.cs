/*
 * Ashton Lively
 * AIManager.cs
 * Assignment 11
 * Manage the properties of the AI shared amongst all AI.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{ 
    private List<AI> ai = new List<AI>();

    [Tooltip("Red prefab")]
    public GameObject reds;
    [Tooltip("Blue prefab")]
    public GameObject blues;

    private LayerMask redMask;
    private LayerMask blueMask;

    private GameController gc;

    // Start is called before the first frame update
    void Start()
    {
        blueMask = LayerMask.NameToLayer("Blue");
        redMask = LayerMask.NameToLayer("Red");

        // Spawn set number of ais and add to list 
        gc = FindObjectOfType<GameController>();
        
    }

    /// <summary>
    /// Create ai's for the team
    /// </summary>
    /// <param name="playerTeam">Team the player is on</param>
    public void CreateAIs(GameController.TeamColor playerTeam)
    {
        int redAdv = 0;
        int blueAdv = 0;

        if (playerTeam == GameController.TeamColor.RED)
        {
            redAdv++;
        }
        else
        {
            blueAdv++;
        }

        // Create red enemies
        for(int i = 0 + redAdv; i < 25; i++)
        {
            GameObject red = Instantiate(reds);
            AI redAI = red.GetComponent<AI>();

            redAI.SetValues(GameController.TeamColor.RED, gc.red, blueMask, redMask);

            ai.Add(redAI);
        }

        // Create blue enemies
        for (int i = 0 + blueAdv; i < 25; i++)
        {
            GameObject blue = Instantiate(blues);
            AI blueAI = blue.GetComponent<AI>();
            blueAI.SetValues(GameController.TeamColor.BLUE, gc.blue, redMask, blueMask);

            ai.Add(blueAI);
        }

        StartCoroutine(RespawnWaves());
    }

    /// <summary>
    /// Change the targetting location for AI
    /// </summary>
    public void RerouteAI()
    {
        foreach(AI ai in ai)
        {
            ai.SetTarget();
        }
    }

    /// <summary>
    /// Respawn all ai
    /// </summary>
    public void RespawnAI()
    {
        foreach (AI ai in ai)
        {
            if(ai.GetDeathStatus())
            {
                ai.Respawn();
            }
        }
    }

    /// <summary>
    /// Countdown to next respawn
    /// </summary>
    /// <param name="respawnDelay">Time until next respawn</param>
    public IEnumerator RespawnWaves()
    {
        while (true)
        {
            // Respawn inactive npc every x seconds
            yield return new WaitForSeconds(20);

            RespawnAI();

            yield return null;
        }
    }

}
