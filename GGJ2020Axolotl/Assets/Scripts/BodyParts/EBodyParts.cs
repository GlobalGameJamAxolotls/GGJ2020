
using System.Collections.Generic;

public enum EBodySide
{
    NONE,
    LEFT,
    RIGHT,
    HELD
}

public enum EBodyLimb
{
    NONE,
    ARM,
    LEG
}

public struct BodyPartCombinations
{
    public EBodyLimb limb;
    public EBodySide side;
}

public static class BodyPartsHelper
{
    public static Dictionary<BodyPartCombinations, int> _combinationsToInt = new Dictionary<BodyPartCombinations, int>()
    {
        { new BodyPartCombinations(){ limb = EBodyLimb.ARM, side = EBodySide.LEFT}, 0 },
        { new BodyPartCombinations(){ limb = EBodyLimb.ARM, side = EBodySide.RIGHT}, 1 },
        { new BodyPartCombinations(){ limb = EBodyLimb.LEG, side = EBodySide.LEFT}, 2 },
        { new BodyPartCombinations(){ limb = EBodyLimb.LEG, side = EBodySide.RIGHT}, 3 },
        { new BodyPartCombinations(){ limb = EBodyLimb.ARM, side = EBodySide.HELD}, 4 },
        { new BodyPartCombinations(){ limb = EBodyLimb.ARM, side = EBodySide.HELD}, 5 }
    };

    public static int GetIntFromPair(BodyPartCombinations pair)
    {
        if(_combinationsToInt.ContainsKey(pair))
    }
}
