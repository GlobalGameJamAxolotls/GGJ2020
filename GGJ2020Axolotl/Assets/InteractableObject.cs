using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractableObject : MonoBehaviour
{
    public Animation ani;
    public event Action<GameObject> Interacted;

    protected bool interactable = true;

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
        //do something
    }


    protected virtual void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Interacted?.Invoke(gameObject);
        }
    }


}
