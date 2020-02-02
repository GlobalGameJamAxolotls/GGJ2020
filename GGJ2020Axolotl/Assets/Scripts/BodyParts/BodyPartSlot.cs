using UnityEngine;

public class BodyPartSlot : MonoBehaviour
{
    [HideInInspector]
    public EAxolotl Axolotl;

    private SkinnedMeshRenderer _associatedLimb;

    private bool isVisible;

    public bool IsVisible { get => isVisible; }

    public void Show(EBodyLimb limb, EBodySide side, EAxolotl color)
    {
        if(_associatedLimb == null)
        {
            _associatedLimb = GetComponent<SkinnedMeshRenderer>();
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