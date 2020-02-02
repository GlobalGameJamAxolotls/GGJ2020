using UnityEngine;

public class BodyPart : MonoBehaviour
{
    public EBodyLimb Part;
    public EBodySide Side;
    public EAxolotl Axolotl;

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

public enum EAxolotl
{
    NONE, 
    ANGRY,
    SAD
}