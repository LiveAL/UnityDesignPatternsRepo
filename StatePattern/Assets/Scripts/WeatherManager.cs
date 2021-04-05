/*
 * Ashton Lively
 * WeatherManager.cs
 * Assignment 9
 * Manage what weather is used. 
 */
using System.Collections;
using UnityEngine;

public class WeatherManager : MonoBehaviour
{
    [Tooltip("Sun Object.")]
    public Transform sun;
    
    [Tooltip("Rain particles.")]
    public ParticleSystem ps;

    [Tooltip("Sky color object.")]
    public SpriteRenderer sky;
    [Tooltip("Color of the sky during the day.")]
    public Color day;
    [Tooltip("Color of the sky when its overcast.")]
    public Color cloudy;

    [Tooltip("One of the clouds that may roll in and out.")]
    public Transform cloud1;
    [Tooltip("0 position is rolled in.")]
    public Vector2[] cloud1Pos;
    [Tooltip("The other cloud that may roll in and out.")]
    public Transform cloud2;
    [Tooltip("0 position is rolled in.")]
    public Vector2[] cloud2Pos;

    public enum States { SUNNY, CLOUDY, RAIN }

    public WeatherState sunnyState { get; set; }
    public WeatherState cloudyState { get; set; }
    public WeatherState rainingState { get; set; }

    public WeatherState currentState {get; set;}

    [HideInInspector]
    /// <summary>
    /// Is the state ready to change? 
    /// </summary>
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

        ChangeWeather();
    }

    public void Drizzle() { currentState.Drizzle(); }
    public void CloudOver() { currentState.CloudOver(); }
    public void ClearSkies() { currentState.ClearSkies(); }

    /// <summary>
    /// Change the current weather
    /// </summary>
    public void ChangeWeather()
    {
        StopAllCoroutines();
        StartCoroutine(WaitForChangeWeather());
        blockPanel.SetActive(false); // Make buttons uninteractable
    }

    private IEnumerator WaitForChangeWeather()
    {
        float timeUntilWeatherChange;
        States state;

        // Randomize time until next weather shift
        timeUntilWeatherChange = Random.Range(10, 15);

        yield return new WaitForSeconds(timeUntilWeatherChange);

        // Randomize the state
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

    [Tooltip("Panel that blocks buttons during transitions.")]
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

    /// <summary>
    /// Make it cloudy. 
    /// </summary>
    public void MakeCloudy()
    {
        if (ready)
        {
            currentState.StartClouding();
            blockPanel.SetActive(true);
        }
    }

    /// <summary>
    /// Make it rain. 
    /// </summary>
    public void MakeRain()
    {
        if(ready)
        {
            currentState.StartRaining();
            blockPanel.SetActive(true);
        }
    }     
}
