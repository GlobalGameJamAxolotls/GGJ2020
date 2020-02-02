using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    [Tooltip("0: left arm - 1: right arm - 2: left leg - 3: right leg - 4: held arm - 5: held leg")]
    private List<BodyPart> _bodyParts = new List<BodyPart>();

    private int _numberOfLegs;
    private int _numberOfArms;
    private bool _isHolding;

    [SerializeField]
    private Body _otherBody;

    public BodyPart TryRecieve(EBodyLimb partSimplified, List<EBodySide> availableParts)
    {
        // if you have an available slot for the given part
        foreach(BodyPart myBodyPart in _bodyParts)
        {
            if(myBodyPart.Part == partSimplified && !myBodyPart.IsVisible)
            {
                BodyPart matchingPart = BrowseMatchingPart(myBodyPart.Side);
                if (matchingPart != EBodySide.NONE)
                {
                    return matchingPart;
                }
            }
        }
        return null;

        BodyPart BrowseMatchingPart(EBodySide side)
        {
            foreach(EBodySide availablePart in availableParts)
            {
                if(availablePart == side)
                {
                    return myB;
                }
            }
            return EBodySide.NONE;
        }
    }

    public void Send(EBodyLimb part)
    {
        if (NumberOfLimbs(part) > 0)
        {
            // Make the list of body parts matching the value of part
            List<EBodySide> availableSides = new List<EBodySide>();
            foreach (BodyPart bodyPart in _bodyParts)
            {
                if (bodyPart.Part == part)
                {
                    availableSides.Add(bodyPart.Side);
                }
            }
            // Try to send it
            EBodySide chosenSide = _otherBody.TryRecieve(part, availableSides);
            if(chosenSide != EBodySide.NONE)
            {

            }
            // If the result is different from null then break the reference in the 
        }
    }

    private void AddBodyPart(BodyPart part)
    {
        _bodyParts.Add(part);
        ModifyNumberOfParts(part.Part, 1);
    }

    private void RemoveBodyPart(BodyPart toRemove)
    {
        ModifyNumberOfParts(toRemove.Part, -1);
        _bodyParts.Remove(toRemove);
    }

    private BodyPart GetFirstBodyPartOfType(EBodyLimb toRemove)
    {
        foreach (BodyPart part in _bodyParts)
        {
            if (part.Part == toRemove)
            {
                return part;
            }
        }
        Debug.Log("Couldnt find body part. Returning null");
        return null;
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
