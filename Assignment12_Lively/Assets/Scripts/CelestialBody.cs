/*
 * Ashton Lively
 * CelestialBody.cs
 * Assignment 12
 * Behavior for celestial bodies.
 */
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public abstract class CelestialBody : MonoBehaviour
{
    // Rate of the rotation around the parent object
    public float rotateRate;

    // Text displaying the object's name
    public GameObject titleText;
    public Transform body;

    // Is the object orbiting?
    public bool orbiting = true;

    /// <summary>
    /// Set the values of the celestial object
    /// </summary>
    /// <param name="orbitTime">Time to orbit in days</param>
    /// <param name="title">Name of the celestial body</param>
    /// <param name="distanceFromAxis">Distance from the parent</param>
    public virtual void SetValues(float orbitTime, string title, float distanceFromAxis, Sprite sprite)
    {
        body = transform.Find("Object");
        body.GetComponent<SpriteRenderer>().sprite = sprite;

        Vector2 startLocation = transform.localPosition;
        distanceFromAxis = distanceFromAxis / 25f;
        startLocation.x += distanceFromAxis;
        body.localPosition = startLocation;

        if (orbitTime != 0)
            rotateRate = (5 / orbitTime) * 1000;
        else
            rotateRate = 0;

        titleText = body.Find("Canvas").Find("Name").gameObject;
        titleText.GetComponent<Text>().text = title;
    }

    /// <summary>
    /// Is orbiting turn on?
    /// </summary>
    public virtual void SetOrbiting(bool orbiting)
    {
        this.orbiting = orbiting;

        if (orbiting)
            StartCoroutine("Orbit");
    }

    /// <summary>
    /// Orbit the parent body.
    /// </summary>
    /// <returns></returns>
    public virtual IEnumerator Orbit()
    {
        while (orbiting)
        {
            if (rotateRate != 0)
            {
                transform.Rotate(0, 0, 1 * rotateRate * Time.deltaTime);
                body.transform.Rotate(0, 0, 1 * -rotateRate * Time.deltaTime);
            }
                

            yield return null;
        }
    }

    /// <summary>
    /// Show the name of the celestial body.
    /// </summary>
    public virtual void ShowName(bool show)
    {
        titleText.SetActive(show);
    }
}
