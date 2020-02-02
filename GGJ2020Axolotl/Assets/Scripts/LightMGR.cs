using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMGR : MonoBehaviour
{
    private new Light light;
    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();  
    }

    // Update is called once per frame
    void Update()
    {
        if (Random.value > 0.97) //a random chance
        {
            if (light.enabled == true) //if the light is on...
            {
                light.enabled = false; //turn it off
            }
            else
            {
                light.enabled = true; //turn it on
            }
        }
    }
}

