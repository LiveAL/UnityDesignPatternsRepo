﻿/*
 * Ashton Lively
 * SpawnPoint.cs
 * Assignment 11
 * Behavior for player spawners and information on its type. 
 */

using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [Tooltip("Color of this spawn's team.")]
    public GameController.TeamColor thisTeam;

    [Tooltip("Previous spawn point.")]
    public SpawnPoint retreatPoint;
    [Tooltip("Next spawn point.")]
    public SpawnPoint advancePoint;

    private Vector3 location;

    // Start is called before the first frame update
    void Start()
    {
        location = transform.position;
    }

    /// <summary>
    /// Get location on the spawn
    /// </summary>
    public Vector3 GetLocation()
    {
        return location;
    }
}
