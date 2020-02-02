using UnityEngine;

[RequireComponent(typeof(Body), typeof(PlayerCTR))]
public class BodyPartsInputController : MonoBehaviour
{
    private Body _associatedBody;
    
    private EInputState _currentState;
    private KeyCode _currentlyPressed;

    private float _pressingDuration;
    private const float _switchModeThreshold = .8f;

    private PlayerCTR _playerController;

    [SerializeField] private ThrowParabola _parabola;

    private float _distance;
    private float _speedDistance = 1f;
    private const float DISTANCE_RESET_VALUE = 1.5f;

    private void Awake()
    {
        _associatedBody = GetComponent<Body>();
        _playerController = GetComponent<PlayerCTR>();
        _distance = DISTANCE_RESET_VALUE;
    }

    private void Update()
    {
        // If we are already pressing, we add the length of the current frame
        if (_currentState.ToString().Contains("PRESSING"))
        {
            _pressingDuration += Time.deltaTime;
        }

        if (_currentState == EInputState.PARABOLE)
        {
            if (Input.GetKeyDown(_playerController.InputSystem.Up))
            {
                _distance += _speedDistance * Time.deltaTime;
                _parabola.Show(_distance);
            }
            else if (Input.GetKeyDown(_playerController.InputSystem.Down))
            {
                _distance -= _speedDistance * Time.deltaTime;
                _parabola.Show(_distance);
            }

        }

        // If we have been pressing for long enough to trigger the parabole mode
        if (_pressingDuration >= _switchModeThreshold && _currentState != EInputState.PARABOLE)
        {
            StartRotating();
        }

        // If we start pressing the arm button 
        if (Input.GetKeyDown(_playerController.InputSystem.Arm))
        {
            // The current state is pressing arm
            _currentState = EInputState.PRESSING_ARM;
        } 
        else if (Input.GetKeyUp(_playerController.InputSystem.Arm)) // If we are releasing the arm button 
        {
            StopRotating(EBodyLimb.ARM, _currentState == EInputState.PARABOLE);
        }

        if (Input.GetKeyDown(_playerController.InputSystem.Leg))
        {
            _currentState = EInputState.PRESSING_LEG;
        }
        else if (Input.GetKeyUp(_playerController.InputSystem.Leg))
        {
            StopRotating(EBodyLimb.LEG, _currentState == EInputState.PARABOLE);
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

    private void StartRotating()
    {
        // Ask parabole to show
        _currentState = EInputState.PARABOLE;
        _playerController.Move = false;
    }

    private void StopRotating(EBodyLimb limbToSEnd, bool askParabole)
    {
        // Ask parabole to stop showing and to throw the object
        _currentState = EInputState.NONE;
        _pressingDuration = 0f;
        _playerController.Move = true;
        _distance = DISTANCE_RESET_VALUE;
        if (askParabole)
        {
            _parabola.ThrowObject();
        }
        else
        {
            _associatedBody.Send(limbToSEnd);
        }
    }
}

public enum EInputState
{
    NONE,
    PRESSING_LEG,
    PRESSING_ARM,
    PARABOLE
}
