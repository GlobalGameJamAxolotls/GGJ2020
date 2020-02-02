using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPartsPrefabsHolder : MonoBehaviour
{
    public GameObject PickableLimbPrefab;

    public static BodyPartsPrefabsHolder Instance;

    public List<GameObject> _angryPrefabs;
    public List<GameObject> _sadPrefabs;

    private void Awake()
    {
        Instance = this;
    }

    internal GameObject GetPrefabFromCombination(EBodyLimb limb, EBodySide side, EAxolotl color)
    {
        switch (color)
        {
            case (EAxolotl.ANGRY):
                return _angryPrefabs[BodyPartsHelper.GetIntFromPair(limb, side)];
            case EAxolotl.SAD:
                return _sadPrefabs[BodyPartsHelper.GetIntFromPair(limb, side)];
            default:
                Debug.Log("ERROR: returning null");
                return null;
        }
    }
}
