using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialiseBodyParts : MonoBehaviour
{
    [SerializeField] private Body _angry;
    [SerializeField] private Body _sad;

    private void Start()
    {
        _angry.TryRecieve(EBodyLimb.ARM, EAxolotl.ANGRY);
        _angry.TryRecieve(EBodyLimb.ARM, EAxolotl.ANGRY);
        _angry.TryRecieve(EBodyLimb.LEG, EAxolotl.ANGRY);

        _sad.TryRecieve(EBodyLimb.ARM, EAxolotl.SAD);
        _sad.TryRecieve(EBodyLimb.LEG, EAxolotl.SAD);
        _sad.TryRecieve(EBodyLimb.LEG, EAxolotl.SAD);

    }
}
