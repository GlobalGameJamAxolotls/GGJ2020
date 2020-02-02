using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPartsMaterialsHolder : MonoBehaviour
{
    [SerializeField]
    private Material[] _angryMaterials;
    [SerializeField]
    private Material[] _sadMaterials;

    public static Material[] AngryMat;
    public static Material[] SadMat;

    private void Awake()
    {
        AngryMat = _angryMaterials;
        SadMat = _sadMaterials;
    }


    public static Material[] GetListForAxolotl(EAxolotl color)
    {
        switch (color)
        {
            case EAxolotl.ANGRY:
                return AngryMat;
            case EAxolotl.SAD:
                return SadMat;
            default:
                Debug.Log("Couldnt find color " + color.ToString() + "returning null");
                return null;
        }
    }
}
