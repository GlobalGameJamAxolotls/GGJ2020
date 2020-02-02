using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableBodyPart : MonoBehaviour
{
    private EBodyLimb _limb;
    private EBodySide _side;
    private EAxolotl _color;

    [SerializeField] private Collider _collider;

    public GameObject Initialise(EBodyLimb limb, EBodySide side, EAxolotl color)
    {
        _limb = limb;
        _side = side;
        _color = color;

        Invoke("ActivateCollider", 1.5f);
        return Instantiate(BodyPartsPrefabsHolder.Instance.GetPrefabFromCombination(limb, side, color), transform).transform.parent.gameObject;
    }

    private void ActivateCollider()
    {
        _collider.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        var body = other.GetComponent<Body>();
        if (other.tag == "Player" && body != null && body.TryRecieve(_limb, _color))
        {
            Destroy(gameObject);

        }
    }
}
