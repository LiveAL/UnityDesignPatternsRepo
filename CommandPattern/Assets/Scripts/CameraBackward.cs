/*
 * Ashton Lively
 * CameraBackward.cs
 * Assignment 7
 * Command for the camera moving away.
 */
public class CameraBackward : ICommand
{
    /// <summary>
    /// Camera zooms out
    /// </summary>
    public float execute()
    {
        return 0.4f;
    }

    /// <summary>
    /// Camera zooms in
    /// </summary>
    public float undo()
    {
        return (-0.4f);
    }
}
