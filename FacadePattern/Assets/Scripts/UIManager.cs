/*
 * Ashton Lively
 * UIManager.cs
 * Assignment 11
 * Manage UI events
 */

using System.Collections;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Tooltip("Panel for win state.")]
    public GameObject winScreen;
    [Tooltip("Text for a red win.")]
    public GameObject redWin;
    [Tooltip("Text for a blue win.")]
    public GameObject blueWin;

    [Tooltip("Panel for a capture state.")]
    public GameObject captured;

    /// <summary>
    /// Display that the point was captured
    /// </summary>
    /// <returns></returns>
    public IEnumerator DisplayCaptured()
    {
        captured.SetActive(true);

        yield return new WaitForSeconds(2f);

        captured.SetActive(false);
    }

    /// <summary>
    ///  Display a blue victory
    /// </summary>
    public void BlueWin()
    {
        Time.timeScale = 0;

        blueWin.SetActive(true);
        winScreen.SetActive(true);
    }

    /// <summary>
    ///  Display a red victory
    /// </summary>
    public void RedWin()
    {
        Time.timeScale = 0;

        redWin.SetActive(true);
        winScreen.SetActive(true);
    }

    /// <summary>
    /// Determine who won
    /// </summary>
    /// <param name="winner">The team that won</param>
    public void DetermineWinner(GameController.TeamColor winner)
    {
        if (winner == GameController.TeamColor.RED)
            RedWin();
        else
            BlueWin();
    }
}
