using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPartsPrefabHolder : MonoBehaviour
{
    [SerializeField] private List<GameObject> _angryAxolotlBodyPartsPrefabs;
    [SerializeField] private List<GameObject> _sadAxolotlBodyPartsPrefabs;

     public GameObject GetPrefabFromBodyPart(BodyPart bodyPart)
    {
        switch (bodyPart.Axolotl)
        {
            case EAxolotl.ANGRY:
                return _angryAxolotlBodyPartsPrefabs[BodyPartsHelper.GetIntFromPair(new BodyPartCombinations(bodyPart.Part, bodyPart.Side))];
            case EAxolotl.SAD:
                return _sadAxolotlBodyPartsPrefabs[BodyPartsHelper.GetIntFromPair(new BodyPartCombinations(bodyPart.Part, bodyPart.Side))];
            default:
                Debug.Log("Couldnt find axolotl " + bodyPart.Axolotl + ". Returning null");
                return null;

        }
    }
}
