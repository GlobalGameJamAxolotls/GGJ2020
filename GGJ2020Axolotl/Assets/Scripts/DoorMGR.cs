using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMGR : MonoBehaviour
{
    public bool lever1, lever2;
    // Start is called before the first frame update
    void Start()
    {
        lever1 = false;
        lever2 = false;
    }

    // Update is called once per frame
    void Update()
    {
       if(lever1 == true && lever2 == true)
        {
            Destroy(this.gameObject);
        } 
    }
}
