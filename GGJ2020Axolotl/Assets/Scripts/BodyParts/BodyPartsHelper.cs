
using System.Collections.Generic;
using System.Linq;

public static class BodyPartsHelper
{
    public static Dictionary<BodyPartCombinations, int> _combinationsToInt = new Dictionary<BodyPartCombinations, int>()
    {
        { new BodyPartCombinations(EBodyLimb.ARM, EBodySide.LEFT), 0 },
        { new BodyPartCombinations(EBodyLimb.ARM, EBodySide.RIGHT), 1 },
        { new BodyPartCombinations(EBodyLimb.LEG, EBodySide.LEFT), 2 },
        { new BodyPartCombinations(EBodyLimb.LEG, EBodySide.RIGHT), 3 }
        //{ new BodyPartCombinations(EBodyLimb.ARM, EBodySide.HELD), 4 },
        //{ new BodyPartCombinations(EBodyLimb.LEG, EBodySide.HELD), 5 }
    };

    public static int GetIntFromPair(EBodyLimb limb, EBodySide side)
    {
        foreach(KeyValuePair<BodyPartCombinations, int> pair in _combinationsToInt)
        {
            if(pair.Key.Limb == limb && pair.Key.Side == side)
            {
                return pair.Value;
            }
        }
        return -1;
    }

    public static BodyPartCombinations GetPairFromInt(int position)
    {
        return _combinationsToInt.FirstOrDefault(x => x.Value == position).Key;
    }
}
