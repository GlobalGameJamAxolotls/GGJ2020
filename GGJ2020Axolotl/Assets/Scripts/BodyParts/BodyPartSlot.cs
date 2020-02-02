using UnityEngine;

public class BodyPartSlot : MonoBehaviour
{
    [HideInInspector]
    public EAxolotl Axolotl;

    private MeshRenderer _associatedLimb;

    private bool isVisible;

    public bool IsVisible { get => isVisible; }

    public void Show(EBodyLimb limb, EBodySide side, EAxolotl color)
    {
        if(_associatedLimb == null)
        {
            _associatedLimb = transform.GetChild(0).GetComponent<MeshRenderer>();
        }
        Axolotl = color;
        _associatedLimb.materials = BodyPartsMaterialsHolder.GetListForAxolotl(color);
        isVisible = true;
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        Axolotl = EAxolotl.NONE;
        isVisible = false;
        gameObject.SetActive(false);
    }
}

public enum EAxolotl
{
    NONE, 
    ANGRY,
    SAD
}