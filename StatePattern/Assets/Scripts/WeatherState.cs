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
    public virtual void StartRaining()
    {
        StartCoroutine(Drizzle());
    }
    public abstract IEnumerator Drizzle();
    public virtual void StartClouding()
    {
        StartCoroutine(CloudOver());
    }
    public abstract IEnumerator CloudOver();
    public virtual void StartClearing()
    {
        StartCoroutine(ClearSkies());
    }
    public abstract IEnumerator ClearSkies();

    public Transform cloud1;
    public Vector2[] cloud1Pos;
    public Transform cloud2;
    public Vector2[] cloud2Pos;

    public ParticleSystem ps;

    public GameObject sun;

    public SpriteRenderer sky;
    public Color day;
    public Color cloudy;

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

            if (sky.color != cloudy)
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

            if (sky.color != day)
            {
                sky.color = Color.Lerp(sky.color, day, (Time.deltaTime * 6f));
            }

            yield return null;
        }

        waitingForClouds = false;
        yield break;
    }
}
