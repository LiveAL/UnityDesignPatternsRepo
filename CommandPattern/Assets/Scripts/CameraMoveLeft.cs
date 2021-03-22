/*
 * Ashton Lively
 * CameraMoveLeft.cs
 * Assignment 7
 * Command for the camera moving left
 */

public class CameraMoveLeft : ICommand
{
    /// <summary>
    /// Camera moves to the left
    /// </summary>
    public float execute()
    {
        return (-0.3f);
    }

    /// <summary>
    /// Camera moves to the right
    /// </summary>
    public float undo()
    {
        return (0.3f);
    }
}
