/*
 * Ashton Lively
 * PlayerBehavior.cs
 * Assignment 10 
 * Manage game controls and player input.
 */

using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerBehavior : MonoBehaviour
{
    [Tooltip("Sound that plays when gun is fired.")]
    public AudioClip gunshot;

    private ObjectPooler pooler;
    private GameController gc;
    private AudioSource audioSource;

    /// <summary>
    /// Delay between shots.
    /// </summary>
    private float fireDelay = 0.2f;

    /// <summary>
    /// X offset of cursor to middle of reticle.
    /// </summary>
    private float mouseOffsetX = 0.22f;
    /// <summary>
    /// Y offset of cursor to middle of reticle.
    /// </summary>
    private float mouseOffsetY = -0.22f;

    // Start is called before the first frame update
    void Start()
    {
        pooler = ObjectPooler.instance;
        gc = FindObjectOfType<GameController>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            pooler.ClearActiveObjects();
        }
    }

    /// <summary>
    /// Allow player to start shooting.
    /// </summary>
    public void AllowPlayerGunFire()
    {
        StartCoroutine(ManageGunFire());
    }

    /// <summary>
    /// Manage player gunfire.
    /// </summary>
    private IEnumerator ManageGunFire()
    {
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                gc.SetReticleType(true);
                audioSource.PlayOneShot(gunshot);

                // Get position of mouse at click
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                // Account for offset of reticle graphic
                mousePos = new Vector3(mousePos.x + mouseOffsetX, mousePos.y + mouseOffsetY, mousePos.z);

                // Get ends of the raycast
                Vector3 origin = new Vector3(mousePos.x, mousePos.y, -10);
                Vector3 end = new Vector3(mousePos.x, mousePos.y, 10);

                // Detect first hit object
                RaycastHit2D hit = Physics2D.Raycast(origin, end);

                // Place at correct distance in space
                Vector3 hitPos = new Vector3(mousePos.x, mousePos.y, hit.collider.transform.position.z);

                // Spawn bullet hole for surface
                switch (hit.collider.gameObject.tag)
                {
                    case ("Wood"):
                        pooler.SpawnFromPool("Wood", hitPos);
                        break;
                    case ("Metal"):
                        pooler.SpawnFromPool("Metal", hitPos);
                        break;
                    case ("Concrete"):
                        pooler.SpawnFromPool("Concrete", hitPos);
                        break;
                }

                yield return new WaitForSeconds(fireDelay);

                gc.SetReticleType(false);
            }

            yield return null;
        }
    }
}
