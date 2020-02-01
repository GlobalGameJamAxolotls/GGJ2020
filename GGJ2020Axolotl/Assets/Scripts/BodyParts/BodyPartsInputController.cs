using UnityEngine;

[RequireComponent(typeof(Body))]
public class BodyPartsInputController : MonoBehaviour
{
    private Body _associatedBody;

    [SerializeField] private KeyCode _throwArm;
    [SerializeField] private KeyCode _throwLeg;

    private KeyCode _pressedLastFrame;
    private KeyCode _currentlyPressed;

    private float _pressingDuration;
    private const float _switchModeThreshold = .8f;

    EBodyParts bodyPart;

    private void Awake()
    {
        _associatedBody = GetComponent<Body>();
    }

    private void Update()
    {
        _currentlyPressed = InterestingKeyPressed();

        if (CurrentPressedChanged())
        {
            bodyPart = GetBodyPartFromKeyCode(_currentlyPressed);
            if (_currentlyPressed != KeyCode.None)
            {
                _associatedBody.Send(bodyPart);
            }
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

    private EBodyParts GetBodyPartFromKeyCode(KeyCode keyCode)
    {
        if(keyCode == _throwArm)
        {
            return EBodyParts.ARM;
        }
        else if(keyCode == _throwLeg)
        {
            return EBodyParts.LEG;
        }
        else
        {
            return EBodyParts.NONE;
        }
    }
}
