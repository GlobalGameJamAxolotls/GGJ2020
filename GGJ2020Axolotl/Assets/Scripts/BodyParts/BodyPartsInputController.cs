﻿using UnityEngine;

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
        _distance = DISTANCE_RESET_VALUE;
    }
}

public enum EInputState
{
    NONE,
    PRESSING_LEG,
    PRESSING_ARM,
    PARABOLE
}
