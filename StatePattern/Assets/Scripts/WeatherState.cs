/*
 * Ashton Lively
 * WeatherState.cs
 * Assignment 9
 * Abstract class for the different states the weather may be in. 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeatherState : MonoBehaviour
{
    /// <summary>
    /// Start the weather transition
    /// </summary>
    public virtual void StartRaining()
    {
        StartCoroutine(Drizzle());
    }
    public abstract IEnumerator Drizzle();

    /// <summary>
    /// Start the cloudy transition
    /// </summary>
    public virtual void StartClouding()
    {
        StartCoroutine(CloudOver());
    }
    public abstract IEnumerator CloudOver();

    /// <summary>
    /// Start the sunny transition.
    /// </summary>
    public virtual void StartClearing()
    {
        StartCoroutine(ClearSkies());
    }
    public abstract IEnumerator ClearSkies();

    /// <summary>
    /// One of the clouds that may roll in and out.
    /// </summary>
    public Transform cloud1;
    /// <summary>
    /// 0 position is rolled in.
    /// </summary>
    public Vector2[] cloud1Pos;
    /// <summary>
    /// The other cloud that may roll in and out.
    /// </summary>
    public Transform cloud2;
    /// <summary>
    /// 0 position is rolled in.
    /// </summary>
    public Vector2[] cloud2Pos;

    /// <summary>
    /// Rain particles.
    /// </summary>
    public ParticleSystem ps;

    /// <summary>
    /// Sun Object.
    /// </summary>
    public GameObject sun;

    /// <summary>
    /// Sky color object.
    /// </summary>
    public SpriteRenderer sky;
    /// <summary>
    /// Color of the sky during the day.
    /// </summary>
    public Color day;
    /// <summary>
    /// Color of the sky when its overcast.
    /// </summary>
    public Color cloudy;

    /// <summary>
    /// Is the app waiting for the clouds to roll in or out?
    /// </summary>
    public bool waitingForClouds = false;

    /// <summary>
    /// Roll clouds in
    /// </summary>
    /// <returns></returns>
    public virtual IEnumerator RollCloudsIn()
    {
        // Roll clouds in
        while ((cloud1Pos[0].x != cloud1.position.x) && (cloud2Pos[0].x != cloud2.position.x) && sky.color != cloudy)
        {
            if (cloud1Pos[0].x != cloud1.position.x) // Move cloud 1
            {
                float cloudPos = cloud1.position.x - (6f * Time.deltaTime);
                cloudPos = Mathf.Clamp(cloudPos, cloud1Pos[0].x, cloud1Pos[1].x);
                cloud1.position = new Vector2(cloudPos, cloud1.position.y);
            }
            if (cloud2Pos[0].x != cloud2.position.x) // Move cloud 2
            {
                float cloudPos = cloud2.position.x + (6f * Time.deltaTime);
                cloudPos = Mathf.Clamp(cloudPos, cloud2Pos[1].x, cloud2Pos[0].x);
                cloud2.position = new Vector2(cloudPos, cloud2.position.y);
            }

            if (sky.color != cloudy) // Make sky grey
            {
                sky.color = Color.Lerp(sky.color, cloudy, (Time.deltaTime * 6f));
            }

            yield return null;
        }

        waitingForClouds = false;
        yield break;
    }

    /// <summary>
    /// Roll clouds out
    /// </summary>
    /// <returns></returns>
    public virtual IEnumerator RollCloudsOut()
    {
        // Roll clouds out
        while ((cloud1Pos[1].x != cloud1.position.x) && (cloud2Pos[1].x != cloud2.position.x) && sky.color != day)
        {
            if (cloud1Pos[1].x != cloud1.position.x) // Move cloud 1
            {
                float cloudPos = cloud1.position.x + (6f * Time.deltaTime);
                cloudPos = Mathf.Clamp(cloudPos, cloud1Pos[0].x, cloud1Pos[1].x);
                cloud1.position = new Vector2(cloudPos, cloud1.position.y);
            }
            if (cloud2Pos[1].x != cloud2.position.x) // Move cloud 2
            {
                float cloudPos = cloud2.position.x - (6f * Time.deltaTime);
                cloudPos = Mathf.Clamp(cloudPos, cloud2Pos[1].x, cloud2Pos[0].x);
                cloud2.position = new Vector2(cloudPos, cloud2.position.y);
            }

            if (sky.color != day) // Make sky blue
            {
                sky.color = Color.Lerp(sky.color, day, (Time.deltaTime * 6f));
            }

            yield return null;
        }

        waitingForClouds = false;
        yield break;
    }
}
