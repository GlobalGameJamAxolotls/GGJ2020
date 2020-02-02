using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    [Tooltip("0: left arm - 1: right arm - 2: left leg - 3: right leg - 4: held arm - 5: held leg")]
    [SerializeField]
    private List<BodyPartSlot> _bodyParts = new List<BodyPartSlot>();

    private int _numberOfLegs;
    private int _numberOfArms;
    private bool _isHolding;

    [SerializeField]
    private Body _otherBody;

    public bool TryRecieve(EBodyLimb partSimplified, EAxolotl color)
    {
        // if you have an available slot for the given part
        for (int i = 0; i < _bodyParts.Count; i++)
        {
            var combination = BodyPartsHelper.GetPairFromInt(i);
            if (combination.Limb == partSimplified && !_bodyParts[i].IsVisible)
            {
                // Instantiate body part with same axolotl as available part but with my side 
                ShowBodyPart(partSimplified, combination.Side, color);
                return true;
            }
        }
        return false;
    }

    public void Send(EBodyLimb part, ThrowParabola parabola = null)
    {
        if (NumberOfLimbs(part) > 0)
        {
            for (int i = 0; i < _bodyParts.Count; i++)
            {
                var combination = BodyPartsHelper.GetPairFromInt(i);
                if (combination.Limb == part && _bodyParts[i].IsVisible)
                {
                    if (parabola != null)
                    {
                        parabola.ThrowObject(Instantiate(BodyPartsPrefabsHolder.Instance.PickableLimbPrefab).GetComponent<PickableBodyPart>().Initialise(combination.Limb, combination.Side, _bodyParts[BodyPartsHelper.GetIntFromPair(combination.Limb, combination.Side)].Axolotl));
                        RemoveBodyPart(combination.Limb, combination.Side);
                        break;
                    }

                    if (_otherBody.TryRecieve(combination.Limb, _bodyParts[i].Axolotl))
                    {
                        RemoveBodyPart(combination.Limb, combination.Side);
                    }
                }
            }
        }
    }

    private void ShowBodyPart(EBodyLimb limb, EBodySide side, EAxolotl color)
    {
        ModifyNumberOfParts(limb, 1);

        _bodyParts[BodyPartsHelper.GetIntFromPair(limb, side)].Show(limb, side, color);
    }

    private void RemoveBodyPart(EBodyLimb limb, EBodySide side)
    {
        ModifyNumberOfParts(limb, -1);
        _bodyParts[BodyPartsHelper.GetIntFromPair(limb, side)].Hide();
    }

    private void ModifyNumberOfParts(EBodyLimb partType, int modifier)
    {
        if (partType == EBodyLimb.ARM)
        {
            _numberOfArms += modifier;
        } else if (partType == EBodyLimb.LEG)
        {
            _numberOfLegs += modifier;
        }
        else
        {
            Debug.Log("Couldn fint body part.");
        }
        _isHolding = _numberOfArms > 2 || _numberOfLegs > 2;
    }

    private int NumberOfLimbs(EBodyLimb partType)
    {
        if (partType == EBodyLimb.ARM)
        {
            return _numberOfArms;
        } else if (partType == EBodyLimb.LEG)
        {
            return _numberOfLegs;
        }
        Debug.Log("Couldnt find body part " + partType + ". Returning 0");
        return 0;
    }
}
