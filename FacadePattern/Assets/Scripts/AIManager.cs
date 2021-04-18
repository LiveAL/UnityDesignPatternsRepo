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
    private List<AI> ai;

    // Start is called before the first frame update
    void Start()
    {
        // Spawn set number of ais and add to list 

        foreach(AI ai in FindObjectsOfType<AI>())
        {
            this.ai.Add(ai);
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
}
