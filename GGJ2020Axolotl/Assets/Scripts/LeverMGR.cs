using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverMGR : MonoBehaviour
{
    public DoorMGR doorManager;
 
    private void OnTriggerEnter(Collider other)
    {
        if (this.gameObject.name == "Lever1")
        {
            doorManager.lever1 = true;
        }
        else if (this.gameObject.name == "Lever2")
        {
            doorManager.lever2 = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(this.gameObject.name == "Lever1")
        {
            doorManager.lever1 = false;
        }
        else if(this.gameObject.name == "Lever2")
        {
            doorManager.lever2 = false;
        }
    }
}
