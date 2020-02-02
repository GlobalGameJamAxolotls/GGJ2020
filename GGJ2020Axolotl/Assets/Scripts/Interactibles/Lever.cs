using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class Lever : InteractableObject
{
    [SerializeField] GameObject lever;

    public event Action ResetPuzzle;

    public void Reset()
    {
        lever.transform.DOLocalRotate(new Vector3(0, 0, 0), 0.5f).OnComplete(() => { interactable = true; });
    }
    protected override void Interaction(GameObject _go)
    {
        interactable = false;
        lever.transform.DOLocalRotate(new Vector3(90, 0, 0), 0.5f);
    }

    //public void Reset()
    //{
    //  
    //}


    void OnTriggerExit(Collider _col)
    {
        if (_col.gameObject.tag == "Player")
        {
            Reset();
            ResetPuzzle?.Invoke();
        }
    }

}
