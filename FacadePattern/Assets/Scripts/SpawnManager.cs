/*
 * Ashton Lively
 * SpawnManager.cs
 * Assignment 11
 * Manage the current active spawn and the next active.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Tooltip("Color of this spawn's team.")]
    public GameController.TeamColor thisTeam;

    [Tooltip("Currently active spawn. Should start with the first active spawn.")]
    public SpawnPoint spawn;

    /// <summary>
    /// Move to last point
    /// </summary>
    public void Retreat()
    {
        spawn = spawn.retreatPoint;
        // Change visuals for the active
    }

    /// <summary>
    /// Move to next point
    /// </summary>
    public void Advance()
    {
        spawn = spawn.advancePoint;
        // Change visuals for the active
    }

    public Vector3 GetPosition()
    {
        return spawn.GetLocation();
    }
}
