/*
 * Ashton Lively
 * CameraProperties.cs
 * Assignment 7
 * Set the commands for the proprties of the camera during recording.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraProperties : MonoBehaviour
{
    /// <summary>
    /// List of positions when the camera moves.
    /// </summary>
    private ICommand[] positionCommands;
    /// <summary>
    /// List of zoom distances when the camera zooms. 
    /// </summary>
    private ICommand[] distanceCommands;

    public CameraProperties()
    {
        positionCommands = new ICommand[400];
        distanceCommands = new ICommand[400];
    }

    /// <summary>
    /// Set the next position of the camera. 
    /// </summary>
    /// <param name="slot"></param>
    /// <param name="posCommand"></param>
    /// <param name="distCommand"></param>
    public void SetCommands(int slot, ICommand posCommand, ICommand distCommand)
    {
        positionCommands[slot] = posCommand;
        distanceCommands[slot] = distCommand;
    }
}
