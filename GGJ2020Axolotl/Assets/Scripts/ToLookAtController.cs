using UnityEngine;

public class ToLookAtController : MonoBehaviour
{
    private InputSystem _inputSystem;

    private bool _isInitialised;

    private Vector3 _desiredPosition;
    private Vector3 _startPosition;
    private Vector3 _pivot;

    private float _speed = 5f;
    private float _movement;

    private const float _distance = 1.5f;

    public void Init(InputSystem inputs, Transform target)
    {
        transform.position = target.forward * _distance;
        
        _inputSystem = inputs;
        _isInitialised = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isInitialised)
            return;

        _desiredPosition = transform.position;
        _movement = _speed * Time.deltaTime;

        if (Input.GetKey(_inputSystem.Up))
        {
            _desiredPosition.x += _movement;
        }

        if (Input.GetKey(_inputSystem.Down))
        {
            _desiredPosition.x -= _movement;
        }

        if (Input.GetKey(_inputSystem.Left))
        {
            _desiredPosition.z += _movement;
        }

        if (Input.GetKey(_inputSystem.Right))
        {
            _desiredPosition.z -= _movement;
        }

        transform.position = _desiredPosition;
    }
}
