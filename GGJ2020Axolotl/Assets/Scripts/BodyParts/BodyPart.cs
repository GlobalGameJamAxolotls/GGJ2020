using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart : MonoBehaviour
{
    public EBodyLimb Part;
    public EBodySide Side;

    private bool isVisible;

    public bool IsVisible { get => isVisible; }

    public void Switch()
    {
        isVisible = !isVisible;
        gameObject.SetActive(isVisible);
    }

    public void AttachToBody(Body body)
    {
        transform.parent = body.transform;
    }
}
