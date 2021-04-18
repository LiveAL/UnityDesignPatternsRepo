/*
 * Ashton Lively
 * AI.cs
 * Assignment 11
 * Behavior for non playable characters to capture control points and
 * attack enemy opponents. 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    private Vector3 target;

    private CapturePointManager capturePoint;

    private bool dead = false;

    void Awake()
    {
        SetTarget();
    }

    public bool GetDeathStatus()
    {
        return dead;
    }

    public void SetTarget()
    {
        target = capturePoint.GetCaptureTarget();
    }

    public void Respawn()
    {

    }

    private IEnumerator Move()
    {
        // Move towards 
        yield break;
    }

    private IEnumerator Attack()
    {
        yield break;
    }

    private IEnumerator TakeDamage()
    {
        yield break;
    }
}
