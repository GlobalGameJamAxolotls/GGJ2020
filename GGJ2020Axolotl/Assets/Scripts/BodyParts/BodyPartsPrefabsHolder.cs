using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPartsPrefabsHolder : MonoBehaviour
{
    public GameObject PickableLimbPrefab;

    public static BodyPartsPrefabsHolder Instance;

    private void Awake()
    {
        Instance = this;
    }

}
