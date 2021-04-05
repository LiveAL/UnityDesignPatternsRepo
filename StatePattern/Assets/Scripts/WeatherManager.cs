/*
 * Ashton Lively
 * WeatherManager.cs
 * Assignment 9
 * Manage what weather is used. 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherManager : MonoBehaviour
{
    [Tooltip("Sun Object.")]
    public Transform sun;
    
    public ParticleSystem ps;

    public SpriteRenderer sky;
    public Color day;
    public Color cloudy;

    public Transform cloud1;
    public Vector2[] cloud1Pos;
    public Transform cloud2;
    public Vector2[] cloud2Pos;

    public enum States { SUNNY, CLOUDY, RAIN }
    public WeatherState sunnyState { get; set; }
    public WeatherState cloudyState { get; set; }
    public WeatherState rainingState { get; set; }

    public WeatherState currentState {get; set;}

    public bool ready = true;

    // Start is called before the first frame update
    void Start()
    {
        ps.Stop();

        sunnyState = gameObject.AddComponent<SunnyState>();
        cloudyState = gameObject.AddComponent<CloudyState>();
        rainingState = gameObject.AddComponent<RainState>();

        currentState = sunnyState;

        cloud1.position = cloud1Pos[1];
        cloud2.position = cloud2Pos[1];

        // StartCoroutine(TimeChange());
        ChangeWeather();
    }

    public void Drizzle() { currentState.Drizzle(); }
    public void CloudOver() { currentState.CloudOver(); }
    public void ClearSkies() { currentState.ClearSkies(); }

    public void ChangeWeather()
    {
        StopAllCoroutines();
        StartCoroutine(WaitForChangeWeather());
        blockPanel.SetActive(false);
    }

    private IEnumerator WaitForChangeWeather()
    {
        float timeUntilWeatherChange;
        States state;

        // Randomize time until next weather shift
        timeUntilWeatherChange = Random.Range(10, 15);

        yield return new WaitForSeconds(timeUntilWeatherChange);

        state = (States)Random.Range(0, 3);

        switch (state)
        {
            case States.SUNNY:
                currentState.StartClearing();
                break;
            case States.CLOUDY:
                currentState.StartClouding();
                break;
            case States.RAIN:
                currentState.StartRaining();
                break;
        }

        yield break;
    }

    public GameObject blockPanel;

    /// <summary>
    /// Make it sunny. 
    /// </summary>
    public void MakeSunny()
    {
        if (ready)
        {
            currentState.StartClearing();
            blockPanel.SetActive(true);
        }
            
    }

    public void MakeCloudy()
    {
        if (ready)
        {
            currentState.StartClouding();
            blockPanel.SetActive(true);
        }
           
    }

    public void MakeRain()
    {
        if(ready)
        {
            currentState.StartRaining();
            blockPanel.SetActive(true);
        }
    }
            
}
