using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private ObjectPooler pooler; 

    // Start is called before the first frame update
    void Start()
    {
        pooler = ObjectPooler.instance;
        SetReticleType(false);
    }

    private void Update()
    {
        
    }

    [Tooltip("Crosshair graphic.")]
    public Texture2D normReticle;
    [Tooltip("Reticle when shot fired.")]
    public Texture2D shotReticle;

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

    public Text numWood;
    public Text numMetal;
    public Text numConcrete;

    /// <summary>
    /// Display the updated number of wood holes in the UI. 
    /// </summary>
    public void UpdateNumWood()
    {
        
    }

    /// <summary>
    /// Display the updated number of metal holes in the UI. 
    /// </summary>
    public void UpdateNumMetal()
    {

    }

    /// <summary>
    /// Display the updated number of concrete holes in the UI. 
    /// </summary>
    public void UpdateNumConcrete()
    {

    }
}
