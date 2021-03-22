/*
 * Ashton Lively
 * NoCommand.cs
 * Assignment 7
 * Command for no movement in the camera
 */

public class NoCommand : ICommand
{
    /// <summary>
    /// Camera doesn't move
    /// </summary>
    public float execute()
    {
        return 0;
    }

    /// <summary>
    /// Camera doesn't move
    /// </summary>
    public float undo()
    {
        return 0;
    }
}
