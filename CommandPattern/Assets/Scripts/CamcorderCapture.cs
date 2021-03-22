/*
 * Ashton Lively
 * CamcorderCapture.cs
 * Assignment 7
 * Assign which data is saved. 
 */

using UnityEngine;

public class CamcorderCapture : MonoBehaviour
{
    private CameraProperties properties;

    public int currentSlot = 0;

    private float lastCamPos;
    private float lastCamDist;

    public CamcorderCapture(float camPos, float camDist)
    {
        properties = new CameraProperties();
        lastCamPos = camPos;
        lastCamDist = camDist;
    }

    public void AddCommand(float camPos, float camDist)
    {
        ICommand distCommand;
        ICommand posCommand;

        if (lastCamPos == camPos) // No movement
        {
            posCommand = new NoCommand();
        }
        else if (lastCamPos < camPos) // Moved right
        {
            posCommand = new CameraMoveRight();
        }
        else // Moved left
        {
            posCommand = new CameraMoveLeft();
        }

        if (lastCamDist == camDist) // No movement 
        {
            distCommand = new NoCommand();
        }
        else if (lastCamDist < camDist) // Zoomed out
        {
            distCommand = new CameraForward();
        }
        else // Zoomed in
        {
            distCommand = new CameraBackward();
        }

        properties.SetCommands(currentSlot, posCommand, distCommand);
        currentSlot++;
    }
}
