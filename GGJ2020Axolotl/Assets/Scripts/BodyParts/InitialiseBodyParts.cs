using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialiseBodyParts : MonoBehaviour
{
    [SerializeField] private Body _axo;
    [SerializeField] private Body _lotl;

    [SerializeField] private BodyPart _arm1;
    [SerializeField] private BodyPart _arm2;
    [SerializeField] private BodyPart _arm3;
    [SerializeField] private BodyPart _arm4;

    [SerializeField] private BodyPart _leg1;
    [SerializeField] private BodyPart _leg2;
    [SerializeField] private BodyPart _leg3;

    private void Awake()
    {
        _axo.Recieve(_arm1);
        _axo.Recieve(_arm2);
        _lotl.Recieve(_arm3);
        _axo.Recieve(_arm4);

        _axo.Recieve(_leg1);
        _lotl.Recieve(_leg2);
        _lotl.Recieve(_leg3);

    }
}
