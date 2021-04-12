/*
 * Ashton Lively
 * ObjectPooler.cs
 * Assignment 10 
 * Create pools and modify the game objects within.
 */

using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary 
        = new Dictionary<string, Queue<GameObject>>();

    public static ObjectPooler instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        FillPoolsWithInactiveObjects();
    }

    /// <summary>
    /// Add game objects to pools. 
    /// </summary>
    private void FillPoolsWithInactiveObjects()
    {
        foreach(Pool pool in pools)
        {
            Queue<GameObject> newPool = new Queue<GameObject>();

            for(int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                newPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.tag, newPool);
        }

        // Allow player to use pools 
        FindObjectOfType<PlayerBehavior>().AllowPlayerGunFire();
    }

    /// <summary>
    /// Set spawned objects in the scene inactive.
    /// </summary>
    public void ClearActiveObjects()
    {
        foreach(KeyValuePair<string, Queue<GameObject>> entry in poolDictionary)
        {
            // Add each object back into queue
            for(int i = 0; i < entry.Value.Count; i ++)
            {
                GameObject objectToSpawn = entry.Value.Dequeue();
                objectToSpawn.SetActive(false);
                
                entry.Value.Enqueue(objectToSpawn);
            }
        }
    }

    /// <summary>
    /// Spawn the next bullet hole.
    /// </summary>
    /// <param name="tag">Type of bullet hole.</param>
    /// <param name="position">Position the hole will be at.</param>
    public void SpawnFromPool(string tag, Vector2 position)
    {
        GameObject objectToSpawn = poolDictionary[tag].Dequeue();
        
        // Move to position and set active
        objectToSpawn.transform.position = position;
        objectToSpawn.SetActive(true);

        poolDictionary[tag].Enqueue(objectToSpawn);
    }

    /// <summary>
    /// Get the number of active bullet holes in the scene. 
    /// </summary>
    /// <param name="tag">Tag of the bullet hole type.</param>
    public int GetNumHoles(string tag)
    {
        return poolDictionary[tag].Count;
    }
}
