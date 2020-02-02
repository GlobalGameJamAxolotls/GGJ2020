using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialiseBodyParts : MonoBehaviour
{
    [SerializeField] private Body _axo;
    [SerializeField] private Body _lotl;

    private void Awake()
    {
        _axo.TryRecieve(EBodyLimb.ARM, );
        _axo.Recieve(_arm2);
        _lotl.Recieve(_arm3);
        _axo.Recieve(_arm4);

        _axo.Recieve(_leg1);
        _lotl.Recieve(_leg2);
        _lotl.Recieve(_leg3);

    }
}
