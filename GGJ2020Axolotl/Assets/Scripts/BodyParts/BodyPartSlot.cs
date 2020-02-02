using UnityEngine;

public class BodyPartSlot : MonoBehaviour
{
    public EAxolotl Axolotl;

    private GameObject _associatedGO;

    private bool isVisible;

    public bool IsVisible { get => isVisible; }

    public void Switch()
    {
        isVisible = !isVisible;
        gameObject.SetActive(isVisible);
    }

    public void CreateGameObject(EBodyLimb limb, EBodySide side, EAxolotl color)
    {
        _associatedGO = Instantiate(BodyPartsPrefabHolder.GetPrefab(limb, side, color));
    }

    public void DestroyGameObject()
    {
        Axolotl = EAxolotl.NONE;
        Destroy(_associatedGO);
    }
}

public enum EAxolotl
{
    NONE, 
    ANGRY,
    SAD
}