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

    public GameObject reds;
    public GameObject blues;

    public LayerMask redMask;
    public LayerMask blueMask;

    private GameController gc;

    // Start is called before the first frame update
    void Start()
    {
        // Spawn set number of ais and add to list 
        gc = FindObjectOfType<GameController>();
        
    }
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

            redAI.SetValues(GameController.TeamColor.RED, gc.red, blueMask);

            ai.Add(redAI);

            redAI.Respawn();
        }

        // Create blue enemies
        for (int i = 0 + blueAdv; i < 25; i++)
        {
            GameObject blue = Instantiate(blues);
            AI blueAI = blue.GetComponent<AI>();
            blueAI.SetValues(GameController.TeamColor.BLUE, gc.blue, redMask);

            ai.Add(blueAI);

            blueAI.Respawn();
        }
    }

    public void RerouteAI()
    {
        foreach(AI ai in ai)
        {
            ai.SetTarget();
        }
    }

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

    public IEnumerator RespawnWaves(float respawnDelay)
    {
        while (true)
        {
            // Respawn inactive npc every x seconds
            yield return new WaitForSeconds(respawnDelay);

            RespawnAI();

            yield return null;
        }
    }

}
