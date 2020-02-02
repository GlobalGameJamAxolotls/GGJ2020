using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractableObject : MonoBehaviour
{
    public event Action<GameObject> Interacted;

   public bool interactable = true;

    public bool Interactable => interactable;


    protected virtual void OnEnable()
    {
        Interacted += Interaction;
    }

    protected virtual void OnDisable()
    {
        Interacted -= Interaction;
    }

    protected virtual void Interaction(GameObject _go)
    {
        
    }


    protected virtual void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Interacted?.Invoke(gameObject);
        }
    }


}
