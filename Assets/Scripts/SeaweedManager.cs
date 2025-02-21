using NodeCanvas.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SeaweedManager : MonoBehaviour
{

    public GameObject seaweedPrefab;

    public float spawnRadius;
    public List<GameObject> spawnedSeaweed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Vector3 spawnLocation = Random.insideUnitSphere * spawnRadius + transform.position;
            spawnLocation.y = 0;
            GameObject newSeaweed = Instantiate(seaweedPrefab, spawnLocation, transform.rotation);
            spawnedSeaweed.Add(newSeaweed);
        }

        for (int i = 0; i < spawnedSeaweed.Count; i++)
        {
            Blackboard seaweedBlackboard = spawnedSeaweed[i].GetComponent<Blackboard>();
            if (seaweedBlackboard.GetVariableValue<bool>("eaten"))
            {
                Destroy(spawnedSeaweed[i]);
                spawnedSeaweed.Remove(spawnedSeaweed[i]);
            }

        }
    }
    
}
