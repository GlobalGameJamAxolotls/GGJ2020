using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableBodyPart : MonoBehaviour
{
    private EBodyLimb _limb;
    private EBodySide _side;
    private EAxolotl _color;

    public GameObject Initialise(EBodyLimb limb, EBodySide side, EAxolotl color)
    {
        _limb = limb;
        _side = side;
        _color = color;

        return gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Body" && other.GetComponent<Body>().TryRecieve(_limb, _color))
        {
            Destroy(gameObject);

        }
    }
}
