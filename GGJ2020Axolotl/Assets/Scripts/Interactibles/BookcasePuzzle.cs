using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class BookcasePuzzle : MonoBehaviour
{
    public Lever[] levers;

    bool solved = false;
    public bool[] canOpen = new[] { false, false };


    private void OnEnable()
    {

        levers[0].Interacted += CheckOk;
        levers[1].Interacted += CheckOk;
        levers[0].ResetPuzzle += () => { canOpen[0] = false; };
        levers[1].ResetPuzzle += () => { canOpen[0] = false; };

    }
    private void OnDisable()
    {
        levers[0].Interacted -= CheckOk;
        levers[1].Interacted -= CheckOk;

    }

    Coroutine check = null;
    private void CheckOk(GameObject obj)
    {
        if (solved)
            return;
        if (check != null)
            StopCoroutine(check);

        check = StartCoroutine(Timer());

        if (canOpen[0])
            canOpen[1] = true;
        else
        {
            canOpen[0] = true;
        }

        if(canOpen[1])
        {
            PuzzleSolved();
        }
    }

    float time = 0;
    IEnumerator Timer()
    {
        time = 0;
        yield return null;
        while (time < 2)
        {
            time += Time.deltaTime;
            yield return null;
        }


        foreach (Lever l in levers)
        {
            l.Reset();
        }
        canOpen = new[] { false, false };
        check = null;
    }

    public void PuzzleSolved()
    {
        Debug.Log("Solved");
        transform.DOMoveY(10, 1.5f);
        Camera.main.DOShakePosition(1.5f);
    }
}
