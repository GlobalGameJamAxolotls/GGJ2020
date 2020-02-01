using UnityEngine;

[RequireComponent(typeof(Body), typeof(PlayerCTR))]
public class BodyPartsInputController : MonoBehaviour
{
    private Body _associatedBody;
    
    private EInputState _currentState;
    private KeyCode _currentlyPressed;

    private float _pressingDuration;
    private const float _switchModeThreshold = .8f;

    EBodyParts bodyPart;

    private PlayerCTR _playerController;

    private void Awake()
    {
        _associatedBody = GetComponent<Body>();
        _playerController = GetComponent<PlayerCTR>();
    }

    private void Update()
    {
        // If we are already pressing, we add the length of the current frame
        if (_currentState.ToString().Contains("PRESSING"))
        {
            _pressingDuration += Time.deltaTime;
        }

        // If we have been pressing for long enough to trigger the parabole mode
        if(_pressingDuration >= _switchModeThreshold && _currentState != EInputState.PARABOLE)
        {
            StartRotating();
        }

        // If we start pressing the arm button 
        if (Input.GetKeyDown(_playerController.InputSystem.Arm))
        {
            // The current state is pressing arm
            _currentState = EInputState.PRESSING_ARM;
        } else if (Input.GetKeyUp(_playerController.InputSystem.Arm)) // If we are releasing the arm button 
        {
            if(_currentState == EInputState.PARABOLE)
            {
                StopRotating();
            }
            _pressingDuration = 0f;
            _currentState = EInputState.NONE;
        }

        if (Input.GetKeyDown(_playerController.InputSystem.Leg))
        {
            _currentState = EInputState.PRESSING_LEG;
        }
        else if (Input.GetKeyUp(_playerController.InputSystem.Leg))
        {
            if (_currentState == EInputState.PARABOLE)
            {
                StopRotating();
            }
            _pressingDuration = 0f;
            _currentState = EInputState.NONE;
        }
    }

    private KeyCode InterestingKeyPressed()
    {
        if (Input.GetKey(_playerController.InputSystem.Arm))
        {
            return _playerController.InputSystem.Arm;
        } else if (Input.GetKey(_playerController.InputSystem.Leg))
        {
            return _playerController.InputSystem.Leg;
        }
        else
        {
            return KeyCode.None;
        }
    }

    private EBodyParts GetBodyPartFromKeyCode(KeyCode keyCode)
    {
        if(keyCode == _playerController.InputSystem.Arm)
        {
            return EBodyParts.ARM;
        }
        else if(keyCode == _playerController.InputSystem.Leg)
        {
            return EBodyParts.LEG;
        }
        else
        {
            return EBodyParts.NONE;
        }
    }

    private void StartRotating()
    {
        // Ask parabole to show
        _currentState = EInputState.PARABOLE;
        _playerController.Move = false;
    }

    private void StopRotating()
    {
        // Ask parabole to stop showing and to throw the object
        _currentState = EInputState.NONE;
        _playerController.Move = true;
    }
}

public enum EInputState
{
    NONE,
    PRESSING_LEG,
    PRESSING_ARM,
    PARABOLE
}
