/*
 * Ashton Lively
 * SunnyState.cs
 * Assignment 9
 * The weather is sunny. 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunnyState : WeatherState 
{
    private WeatherManager weatherManager;

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
        Debug.Log("The skies are already clear.");
        if (weatherManager.ready)
        {
            weatherManager.ChangeWeather();
        }
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

        // Disable the sun
        sun.GetComponent<SpriteRenderer>().enabled = false;

        // Start cloud transition
        weatherManager.ready = false;
        waitingForClouds = true;
        StartCoroutine(RollCloudsIn());

        while (waitingForClouds)
        {
            yield return null;
        }

        // Switch the state
        weatherManager.currentState = weatherManager.cloudyState;

        // Transition is over
        weatherManager.ready = true;
        weatherManager.ChangeWeather();
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

        // Disable the sun
        sun.GetComponent<SpriteRenderer>().enabled = false;

        // Start cloud transition
        weatherManager.ready = false;
        waitingForClouds = true;
        StartCoroutine(RollCloudsIn());
        
        while (waitingForClouds)
        {
            yield return null;
        }

        // Start drizzle
        ps.Play();

        // Switch state
        weatherManager.currentState = weatherManager.rainingState;

        // Transition over
        weatherManager.ready = true;
        weatherManager.ChangeWeather();
        yield break;
    }
}
