/*
 * Ashton Lively
 * CameraMForward.cs
 * Assignment 7
 * Command for the camera moving forward.
 */
public class CameraForward : ICommand
{
    /// <summary>
    /// Camera zooms in
    /// </summary>
    public float execute()
    {
        return (-0.4f);
    }

    /// <summary>
    /// Camera zooms out
    /// </summary>
    public float undo()
    {
        return 0.4f;
    }
}
