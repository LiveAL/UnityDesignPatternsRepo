/*
 * Ashton Lively
 * CloudyState.cs
 * Assignment 9
 * The skies are cloudy. 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudyState : WeatherState
{
    private WeatherManager weatherManager;

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

        // Enable the sun
        sun.GetComponent<SpriteRenderer>().enabled = true;

        // Roll out the clouds
        weatherManager.ready = false;
        waitingForClouds = true;

        StartCoroutine(RollCloudsOut());

        while (waitingForClouds)
        {
            yield return null;
        }

        // Switch the current state
        weatherManager.currentState = weatherManager.sunnyState;

        // Transition is over
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
        Debug.Log("It is already cloudy.");
        if (weatherManager.ready)
        {
            weatherManager.ChangeWeather();
        }
        yield break;
    }

    /// <summary>
    /// Transition into rain
    /// </summary>
    /// <returns></returns>
    public override IEnumerator Drizzle()
    {
        if  (!weatherManager.ready)
        {
            Debug.Log("State is already transitioning to another.");
            yield break;
        }

        // Start rain 
        ps.Play();

        // Switch the active state
        weatherManager.currentState = weatherManager.rainingState;

        // Transition is over
        weatherManager.ready = true;
        weatherManager.ChangeWeather();
        yield break;
    }
}
