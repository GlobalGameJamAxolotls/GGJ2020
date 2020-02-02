
using System.Collections.Generic;

public static class BodyPartsHelper
{
    public static Dictionary<BodyPartCombinations, int> _combinationsToInt = new Dictionary<BodyPartCombinations, int>()
    {
        { new BodyPartCombinations(){ Limb = EBodyLimb.ARM, Side = EBodySide.LEFT}, 0 },
        { new BodyPartCombinations(){ Limb = EBodyLimb.ARM, Side = EBodySide.RIGHT}, 1 },
        { new BodyPartCombinations(){ Limb = EBodyLimb.LEG, Side = EBodySide.LEFT}, 2 },
        { new BodyPartCombinations(){ Limb = EBodyLimb.LEG, Side = EBodySide.RIGHT}, 3 },
        { new BodyPartCombinations(){ Limb = EBodyLimb.ARM, Side = EBodySide.HELD}, 4 },
        { new BodyPartCombinations(){ Limb = EBodyLimb.ARM, Side = EBodySide.HELD}, 5 }
    };

    public static int GetIntFromPair(BodyPartCombinations pair)
    {
        if (_combinationsToInt.ContainsKey(pair))
        {
            return _combinationsToInt[pair];
        }
        else
        {
            return -1;
        }
    }
}
