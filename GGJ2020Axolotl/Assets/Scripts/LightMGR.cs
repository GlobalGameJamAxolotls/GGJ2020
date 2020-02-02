using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMGR : MonoBehaviour
{
    private new Light light;
    [Range(0.9f,1.0f)]
    public float eventThreshold;
    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>(); 
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Random.value > eventThreshold) //UNSTABLE. The slightest change and it goes haywire. Keep it >0.9 <0.99
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

