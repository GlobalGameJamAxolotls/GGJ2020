using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPartsPrefabHolder : MonoBehaviour
{
    [SerializeField] private List<GameObject> _angryAxolotlBodyPartsPrefabs;
    [SerializeField] private List<GameObject> _sadAxolotlBodyPartsPrefabs;

     public GameObject GetPrefabFromBodyPart(EBodyLimb limb, EBodySide side, EAxolotl color)
    {
        switch (color)
        {
            case EAxolotl.ANGRY:
                return _angryAxolotlBodyPartsPrefabs[BodyPartsHelper.GetIntFromPair(limb, side)];
            case EAxolotl.SAD:
                return _sadAxolotlBodyPartsPrefabs[BodyPartsHelper.GetIntFromPair(limb, side)];
            default:
                Debug.Log("Couldnt find axolotl " + color.ToString() + ". Returning null");
                return null;

        }
    }

    internal static GameObject GetPrefab(EBodyLimb limb, EBodySide side, EAxolotl color)
    {
        throw new NotImplementedException();
    }
}
