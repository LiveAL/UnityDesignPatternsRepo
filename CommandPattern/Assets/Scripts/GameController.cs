/*
 * Ashton Lively
 * GameController.cs
 * Assignment 7
 * Run the game.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    CamcorderCapture capture1;
    CamcorderCapture capture2;
    CamcorderCapture capture3;

    private bool captured1;
    private bool captured2;
    private bool captured3;

    public Camera cam;

    private int clip = 1;

    public Slider scrubber;
    public GameObject play;
    public GameObject pause;
    public GameObject record;
    public GameObject selectSave;

    // Start is called before the first frame update
    void Start()
    {
        capture1 = new CamcorderCapture(cam.transform.position.x, cam.orthographicSize);
        capture2 = new CamcorderCapture(cam.transform.position.x, cam.orthographicSize);
        capture3 = new CamcorderCapture(cam.transform.position.x, cam.orthographicSize);
    }

    private IEnumerator WaitForRecord()
    {
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartCoroutine(Capture());
                yield break;
            }
            yield return null;
        }
    }

    /// <summary>
    /// Select the clip to edit
    /// </summary>
    /// <param name="clipNum">Number of the clip in the menu.</param>
    public void SelectClip(int clipNum)
    {
        clip = clipNum;

        // Set values
        scrubber.value = 0;
        play.SetActive(false);
        pause.SetActive(false);
        scrubber.gameObject.SetActive(false);

        switch (clipNum)
        {
            case (1):
                if (captured1 == true) // already captured in this slot
                {
                    scrubber.gameObject.SetActive(true);
                    play.SetActive(true);
                    StartCoroutine(Scrub());
                    break;
                }
                StartCoroutine(WaitForRecord());
                break;
            case (2):
                if (captured2 == true) // already captured in this slot
                {
                    scrubber.gameObject.SetActive(true);
                    play.SetActive(true);
                    StartCoroutine(Scrub());
                    break;
                }
                StartCoroutine(WaitForRecord());
                break;
            case (3):
                if (captured3 == true) // already captured in this slot
                {
                    scrubber.gameObject.SetActive(true);
                    play.SetActive(true);
                    StartCoroutine(Scrub());
                    break;
                }
                StartCoroutine(WaitForRecord());
                break;
        }
    }

    /// <summary>
    /// Capture the scene normally.
    /// </summary>
    /// <returns></returns>
    private IEnumerator Capture()
    {
        float time = 0;
        record.SetActive(true);

        while (time < 20)
        {
            Debug.Log("We are recording.");
            yield return new WaitForSeconds(0.05f);
            time += 0.05f;

            Move();
            Zoom();

            switch (clip)
            {
                case (1):
                    capture1.AddCommand(cam.transform.position.x, cam.orthographicSize);
                    break;
                case (2):
                    capture2.AddCommand(cam.transform.position.x, cam.orthographicSize);
                    break;
                case (3):
                    capture3.AddCommand(cam.transform.position.x, cam.orthographicSize);
                    break;
            }

            yield return null;
        }

        record.SetActive(false);

        scrubber.gameObject.SetActive(true);
        play.SetActive(true);

        StartCoroutine(Scrub());

        yield break;
    }

    private void Move()
    {
        float xMove = Input.GetAxis("Horizontal");

        if (xMove > 0)
        {
            float newX = Mathf.Clamp(cam.gameObject.transform.position.x + 0.3f, -4, 4);
            cam.gameObject.transform.position = new Vector3(newX, 0, -10);
        }
        if (xMove > 0)
        {
            float newX = Mathf.Clamp(cam.gameObject.transform.position.x - 0.3f, -4, 4);
            cam.gameObject.transform.position = new Vector3(newX, 0, -10);
        }

    }

    private void Zoom()
    {
        float zoom = Input.GetAxis("Vertical");
        if (zoom > 0)
        {
            cam.orthographicSize = cam.orthographicSize - 0.4f;
        }
        if (zoom < 0)
        {
            cam.orthographicSize = cam.orthographicSize + 0.4f;
        }
    }

    IEnumerator Scrub()
    {
        while (true)
        {
            if (Input.GetKey(KeyCode.A))
            {
                scrubber.value -= 0.05f;
            }

            yield return null;
        }
    }
}
