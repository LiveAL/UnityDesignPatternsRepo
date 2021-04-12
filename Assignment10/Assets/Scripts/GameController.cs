/*
 * Ashton Lively
 * GameController.cs
 * Assignment 10 
 * Manage the game. 
 */

using UnityEngine;

public class GameController : MonoBehaviour
{
    [Tooltip("Crosshair graphic.")]
    public Texture2D normReticle;
    [Tooltip("Reticle when shot fired.")]
    public Texture2D shotReticle;

    // Start is called before the first frame update
    void Start()
    {
        SetReticleType(false);
    }

    /// <summary>
    /// Change the reticle to display a crosshair.
    /// </summary>
    /// <param name="on">Did the player shoot?</param>
    public void SetReticleType(bool shot)
    {
        if (shot)
            Cursor.SetCursor(shotReticle, Vector2.zero, CursorMode.ForceSoftware);
        else
            Cursor.SetCursor(normReticle, Vector2.zero, CursorMode.ForceSoftware);
    }
}
