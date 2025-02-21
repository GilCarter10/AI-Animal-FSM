using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    private float lifespanTimer = 0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifespanTimer += Time.deltaTime;
        if (lifespanTimer > 5)
        {
            Destroy(gameObject);
        }
    }
}
