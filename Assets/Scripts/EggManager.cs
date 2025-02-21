using NodeCanvas.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggManager : MonoBehaviour
{

    public GameObject eggPrefab;
    public GameObject Turtle;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Blackboard turtleBlackboard = Turtle.GetComponent<Blackboard>();

        if (turtleBlackboard.GetVariableValue<bool>("spawnEgg"))
        {
            Instantiate(eggPrefab, Turtle.transform.position, transform.rotation);

            turtleBlackboard = Turtle.GetComponent<Blackboard>();
            turtleBlackboard.SetVariableValue("spawnEgg", false);
        }
    }
}
