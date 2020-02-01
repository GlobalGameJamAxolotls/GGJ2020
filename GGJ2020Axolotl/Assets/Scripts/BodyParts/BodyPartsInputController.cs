using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPartsInputController : MonoBehaviour
{
    [SerializeField] private Body _associatedBody;

    [SerializeField] private KeyCode _throwArm;
    [SerializeField] private KeyCode _throwLeg;

    private KeyCode _pressedLastFrame;
    private KeyCode _currentlyPressed;

    private float _pressingDuration;
    private const float _switchModeThreshold = 2f;

    private void Update()
    {
        _currentlyPressed = InterestingKeyPressed();

        if (CurrentPressedChanged())
        {
            _pressingDuration = 0f;
        }
        else if(_currentlyPressed != KeyCode.None)
        {
            _pressingDuration += Time.deltaTime;
        }

        if(_pressingDuration >= _switchModeThreshold)
        {
            Debug.Log("Target mode");
        }

        _pressedLastFrame = _currentlyPressed;
    }

    private KeyCode InterestingKeyPressed()
    {
        if (Input.GetKey(_throwArm))
        {
            return _throwArm;
        } else if (Input.GetKey(_throwLeg))
        {
            return _throwLeg;
        }
        else
        {
            return KeyCode.None;
        }
    }

    private bool CurrentPressedChanged()
    {
        return _currentlyPressed != _pressedLastFrame;
    }
}
