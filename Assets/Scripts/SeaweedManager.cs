using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaweedManager : MonoBehaviour
{

    public GameObject seaweed;
    public static bool spawned = false;

    public float spawnRadius;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space") && !spawned)
        {
            Vector3 spawnPosition = Random.insideUnitSphere * spawnRadius + transform.position;
            spawnPosition.y = 0;
            seaweed.transform.position = spawnPosition;
            spawned = true;
        }
    }
}
