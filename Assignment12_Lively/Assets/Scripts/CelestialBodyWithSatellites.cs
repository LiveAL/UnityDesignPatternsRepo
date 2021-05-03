/*
 * Ashton Lively
 * CelestialBodyWithSatellites.cs
 * Assignment 12
 * Celestial body with other celestial bodies orbiting it.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelestialBodyWithSatellites : CelestialBody
{
    [Tooltip("Celestial bodies orbiting this object.")]
    public List<CelestialBody> objInOrbit = new List<CelestialBody>();

    // Orbit around the axis object
    public override IEnumerator Orbit()
    {
        IterateOrbitingStatus(objInOrbit, true);

        while (orbiting)
        {
            if (rotateRate != 0)
            {
                transform.Rotate(0, 0, 1 * rotateRate * Time.deltaTime);
                body.transform.Rotate(0, 0, 1 * -rotateRate * Time.deltaTime);
            }
                
            yield return null;
        }

        IterateOrbitingStatus(objInOrbit, false);
    }

    /// <summary>
    /// Start or stop orbiting object's orbit
    /// </summary>
    /// <param name="objInOrbit">Orbiting objects</param>
    /// <param name="orbit">Is the object orbiting?</param>
    private void IterateOrbitingStatus(IEnumerable<CelestialBody> objInOrbit, bool orbit)
    {
        IEnumerator<CelestialBody> enumerator = objInOrbit.GetEnumerator();

        while(enumerator.MoveNext())
        {
            CelestialBody body = enumerator.Current;

            body.SetOrbiting(orbit);

            if (true)
            {
                body.StartCoroutine("Orbit");
            }
        }
    }

    // Show the name of the body
    public override void ShowName(bool show)
    {
        titleText.SetActive(show);
        IterateNameTags(objInOrbit, show);
    }

    /// <summary>
    /// Show or hide name text
    /// </summary>
    /// <param name="objInOrbit">Orbiting objects</param>
    /// <param name="show">Is the text shown?</param>
    private void IterateNameTags(IEnumerable<CelestialBody> objInOrbit, bool show)
    {
        IEnumerator<CelestialBody> enumerator = objInOrbit.GetEnumerator();

        while (enumerator.MoveNext())
        {
            CelestialBody body = enumerator.Current;

            body.ShowName(show);
        }
    }

    ///<summary>
    /// Add new orbiting object
    ///</summary>
    public void AddChild(CelestialBody body)
    {
        objInOrbit.Add(body);
    }
}
