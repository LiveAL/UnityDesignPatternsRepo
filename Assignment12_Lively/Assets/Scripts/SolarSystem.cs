/*
 * Ashton Lively
 * SolarSystem.cs
 * Assignment 12
 * Manage celestial bodies in the solar system.
 */
using UnityEngine;
using UnityEngine.SceneManagement;

public class SolarSystem : MonoBehaviour
{
    [Tooltip("Prefab for celestial bodies")]
    public GameObject celestialBody;

    public Sprite sunSpr;
    public Sprite mercurySpr;
    public Sprite venusSpr;
    public Sprite earthSpr;
    public Sprite marsSpr;
    public Sprite moonSpr;

    // The sun
    private CelestialBodyWithSatellites sun;

    private void Start()
    {
        // Create sun 
        GameObject sunObj = Instantiate(celestialBody, transform);
        sun = sunObj.AddComponent<CelestialBodyWithSatellites>();
        sun.SetValues(0, "Sun", 0, sunSpr);

        // Create Mercury 
        GameObject mercuryObj = Instantiate(celestialBody, sun.transform);
        CelestialBody mercury = mercuryObj.AddComponent<CelestialBodyWithoutSatellites>();
        mercury.SetValues(88, "Mercury", 28.5f, mercurySpr);
        sun.AddChild(mercury);

        // Create Venus
        GameObject venusObj = Instantiate(celestialBody, sun.transform);
        CelestialBody venus = venusObj.AddComponent<CelestialBodyWithoutSatellites>();
        venus.SetValues(243, "Venus", 67.2f, venusSpr);
        sun.AddChild(venus);

        // Create Earth
        GameObject earthObj = Instantiate(celestialBody, sun.transform);
        CelestialBodyWithSatellites earth = earthObj.AddComponent<CelestialBodyWithSatellites>();
        earth.SetValues(365, "Earth", 93f, earthSpr);
        sun.AddChild(earth);

        // Create Earth's moon
        GameObject moonObj = Instantiate(celestialBody, earth.transform.Find("Object"));
        CelestialBody moon = moonObj.AddComponent<CelestialBodyWithoutSatellites>();
        // Numbers fudged a bit for visuals
        moon.SetValues(90, "Moon", 15f, moonSpr);
        earth.AddChild(moon);

        // Create Mars
        GameObject marsObj = Instantiate(celestialBody, sun.transform);
        CelestialBodyWithSatellites mars = marsObj.AddComponent<CelestialBodyWithSatellites>();
        mars.SetValues(687, "Mars", 143f, marsSpr);
        sun.AddChild(mars);

        // Create Mars moons
        GameObject deimosObj = Instantiate(celestialBody, mars.transform.Find("Object"));
        CelestialBody deimos = deimosObj.AddComponent<CelestialBodyWithoutSatellites>();
        // Numbers fudged a bit for visuals
        deimos.SetValues(90f, "Deimos", 15f, moonSpr);
        mars.AddChild(deimos);

        GameObject phobosObj = Instantiate(celestialBody, mars.transform.Find("Object"));
        CelestialBody phobos = phobosObj.AddComponent<CelestialBodyWithoutSatellites>();
        // Numbers fudged a bit for visuals
        phobos.SetValues(120f, "Phobos", 30f, moonSpr);
        mars.AddChild(phobos);

        sun.SetOrbiting(orbiting);
    }

    private bool orbiting = true;
    private bool showNames = false;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            orbiting = !orbiting;
            sun.SetOrbiting(orbiting);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            showNames = !showNames;
            sun.ShowName(showNames);
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }
}
