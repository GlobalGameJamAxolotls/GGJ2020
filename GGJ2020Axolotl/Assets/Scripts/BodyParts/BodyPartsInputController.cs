using UnityEngine;

[RequireComponent(typeof(Body))]
public class BodyPartsInputController : MonoBehaviour
{
    private Body _associatedBody;

    [SerializeField] private InputSystem _inputSystem;

    private EInputState _currentState;
    private KeyCode _currentlyPressed;

    private float _pressingDuration;
    private const float _switchModeThreshold = .8f;

    EBodyParts bodyPart;

    private Transform _transformToLookAt;
    [SerializeField] private GameObject _thingToLookAtPrefab;



    private void Awake()
    {
        _associatedBody = GetComponent<Body>();
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

        if (_currentState == EInputState.PARABOLE)
        {
            transform.LookAt(_transformToLookAt);
            // Give distance to curve
        }

        // If we start pressing the arm button 
        if (Input.GetKeyDown(_inputSystem.Arm))
        {
            // The current state is pressing arm
            _currentState = EInputState.PRESSING_ARM;
        } else if (Input.GetKeyUp(_inputSystem.Arm)) // If we are releasing the arm button 
        {
            if(_currentState == EInputState.PARABOLE)
            {
                StopRotating();
            }
            _pressingDuration = 0f;
            _currentState = EInputState.NONE;
        }

        if (Input.GetKeyDown(_inputSystem.Leg))
        {
            _currentState = EInputState.PRESSING_LEG;
        }
        else if (Input.GetKeyUp(_inputSystem.Leg))
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
        if (Input.GetKey(_inputSystem.Arm))
        {
            return _inputSystem.Arm;
        } else if (Input.GetKey(_inputSystem.Leg))
        {
            return _inputSystem.Leg;
        }
        else
        {
            return KeyCode.None;
        }
    }

    private EBodyParts GetBodyPartFromKeyCode(KeyCode keyCode)
    {
        if(keyCode == _inputSystem.Arm)
        {
            return EBodyParts.ARM;
        }
        else if(keyCode == _inputSystem.Leg)
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
        _transformToLookAt = Instantiate(_thingToLookAtPrefab).transform;
        _transformToLookAt.GetComponent<ToLookAtController>().Init(_inputSystem, transform);
    }

    private void StopRotating()
    {
        // Ask parabole to stop showing and to throw the object
        _currentState = EInputState.NONE;
        Destroy(_transformToLookAt.gameObject);
    }
}

public enum EInputState
{
    NONE,
    PRESSING_LEG,
    PRESSING_ARM,
    PARABOLE
}
