/*
 * Ashton Lively
 * HoverController.cs
 * Assignment 5
 * Behavior for when a horse button is hovered over
 */
using UnityEngine;

public class HoverController : MonoBehaviour
{
    private GameController gc;

    /// <summary>
    /// Object last hovered over
    /// </summary>
    public static GameObject currentHover;

    // Start is called before the first frame update
    void Awake()
    {
        GameObject.Find("GameController").GetComponent<GameController>();
    }

    /// <summary>
    /// Set the hovered item as the currently hovered
    /// </summary>
    /// <param name="hoverItem"></param>
    public void SetCurrentHover(GameObject hoverItem)
    {
        currentHover = hoverItem;
    }

    /// <summary>
    /// Nullify the current hover
    /// </summary>
    public void DeleteCurrentHover()
    {
        currentHover = null;
    }
}
