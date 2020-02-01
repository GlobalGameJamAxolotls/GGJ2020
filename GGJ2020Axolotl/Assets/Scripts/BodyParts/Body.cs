﻿using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    private List<BodyPart> _bodyParts = new List<BodyPart>();

    private int _numberOfLegs;
    private int _numberOfArms;
    private bool _isHolding;

    [SerializeField]
    private Body _otherBody;

    private bool CanRecieve(EBodyParts partToSend)
    {
        return NumberOfLimbs(partToSend) < 2 || !_isHolding;
    }

    public bool Recieve(BodyPart partToSend)
    {
        if (CanRecieve(partToSend.Type))
        {
            AddBodyPart(partToSend);
            return true;
        }
        return false;
    }

    public void Send(EBodyParts typeToSend)
    {
        BodyPart toSend = GetFirstBodyPartOfType(typeToSend);
        if (toSend != null && _otherBody.Recieve(toSend))
        {
            RemoveBodyPart(toSend);
        }
    }

    private void AddBodyPart(BodyPart part)
    {
        _bodyParts.Add(part);
        ModifyNumberOfParts(part.Type, 1);
    }

    private void RemoveBodyPart(BodyPart toRemove)
    {
        ModifyNumberOfParts(toRemove.Type, -1);
        _bodyParts.Remove(toRemove);
    }

    private BodyPart GetFirstBodyPartOfType(EBodyParts toRemove)
    {
        foreach (BodyPart part in _bodyParts)
        {
            if (part.Type == toRemove)
            {
                return part;
            }
        }
        Debug.Log("Couldnt find body part. Returning null");
        return null;
    }

    private void ModifyNumberOfParts(EBodyParts partType, int modifier)
    {
        switch (partType)
        {
            case EBodyParts.ARM:
                _numberOfArms += modifier;
                break;
            case EBodyParts.LEG:
                _numberOfLegs += modifier;
                break;
            default:
                Debug.Log("Couldn fint body part.");
                break;
        }
    }

    private int NumberOfLimbs(EBodyParts partType)
    {
        switch (partType)
        {
            case EBodyParts.LEG:
                return _numberOfLegs;
            case EBodyParts.ARM:
                return _numberOfArms;
            default:
                Debug.Log("Couldnt find body part " + partType + ". Returning 0");
                return 0;
        }
    }
}
