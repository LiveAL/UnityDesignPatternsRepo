/*
 * Ashton Lively
 * RainState.cs
 * Assignment 9
 * It is raining.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainState : WeatherState
{
    WeatherManager weatherManager;

    // Start is called before the first frame update
    void Start()
    {
        weatherManager = gameObject.GetComponent<WeatherManager>();

        cloud1 = weatherManager.cloud1;
        cloud2 = weatherManager.cloud2;
        cloud1Pos = weatherManager.cloud1Pos;
        cloud2Pos = weatherManager.cloud2Pos;

        ps = weatherManager.ps;
        sun = weatherManager.sun.gameObject;

        day = weatherManager.day;
        cloudy = weatherManager.cloudy;
        sky = weatherManager.sky;
    }

    /// <summary>
    /// Transition to sunny
    /// </summary>
    /// <returns></returns>
    public override IEnumerator ClearSkies()
    {
        if (!weatherManager.ready)
        {
            Debug.Log("State is already transitioning to another.");
            yield break;
        }

        sun.GetComponent<SpriteRenderer>().enabled = true;

        weatherManager.ready = false;
        waitingForClouds = true;

        ps.Stop();
        StartCoroutine(RollCloudsOut());

        while (waitingForClouds)
        {
            yield return null;
        }

        
        weatherManager.currentState = weatherManager.sunnyState;
        weatherManager.ready = true;
        weatherManager.ChangeWeather();
        
        yield break;
    }

    /// <summary>
    /// Transition to cloudy
    /// </summary>
    /// <returns></returns>
    public override IEnumerator CloudOver()
    {
        if (!weatherManager.ready)
        {
            Debug.Log("State is already transitioning to another.");
            yield break;
        }

        weatherManager.ready = false;
        // Stop rain 
        ps.Stop();

        weatherManager.currentState = weatherManager.cloudyState;
        weatherManager.ready = true;
        weatherManager.ChangeWeather();
        yield break;
    }

    /// <summary>
    /// Transition to raining
    /// </summary>
    /// <returns></returns>
    public override IEnumerator Drizzle()
    {
        Debug.Log("It is already raining.");
        if (weatherManager.ready)
        {
            weatherManager.ChangeWeather();
        }
        yield break;
    }
}
