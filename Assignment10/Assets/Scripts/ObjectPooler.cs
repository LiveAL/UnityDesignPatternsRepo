using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    public static ObjectPooler instance;

    private ObjectPooler() { }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject SpawnFromPool(string tag, Vector2 position)
    {
        // Prefab to spawn
        GameObject objectToSpawn = poolDictionary[tag].Dequeue();
        
        // Move to position and set active
        objectToSpawn.transform.position = position;
        objectToSpawn.SetActive(true);

        poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
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
