using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class PlayerCTR : MonoBehaviour
{
    private float movementSpeed = 20f;

    private float jumpForce = 5f;

    private Rigidbody rb;

    private bool _isjumping;

    public InputSystem InputSystem;

    public Vector3 _target;

    [HideInInspector]
    public bool Move;

    private bool _pressedSomething;    

    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        _isjumping = false;
        Move = true;
    }
    void Update()
    {
        _target = Vector3.zero;
        _pressedSomething = false;

        if (Input.GetKey(InputSystem.Down))
        {
            _target.x++;
            _pressedSomething = true;
        }

        if (Input.GetKey(InputSystem.Up))
        {
            _target.x--;
            _pressedSomething = true;
        }

        if (Input.GetKey(InputSystem.Right))
        {
            _target.z++;
            _pressedSomething = true;
        }

        if (Input.GetKey(InputSystem.Left))
        {
            _target.z--;
            _pressedSomething = true;
        }

        if (Move)
        {
            Movement();
        }

        if (_pressedSomething)
        {
       //     Rotation();
        }
        Jump();
    }


    void Movement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); float moveVertical = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(moveHorizontal, 0, moveVertical);
        anim?.SetBool("Walking", move != Vector3.zero);

        if (moveHorizontal == 0 && moveVertical == 0) return;

        Vector3 movement = new Vector3(-moveHorizontal, 0f, -moveVertical); transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15F);

        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement.normalized), 0.2f);
        }



        transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);

        //    anim.SetBool("Walking", _target != Vector3.zero);
        //    transform.Translate(_target * movementSpeed * Time.deltaTime, Space.Self);
    }

    //private void Rotation()
    //{
    //    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_target), 0.15F);

    //    if (_target != Vector3.zero)
    //    {
    //        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_target.normalized), 0.2f);
    //    }
    //}

    void Jump()
    {
        if(Input.GetKey(KeyCode.Space) && _isjumping == false) 
        {
            rb.AddForce(new Vector3(0, jumpForce, 0),ForceMode.Impulse);
            _isjumping = true;
        }            
    }

    private void OnCollisionEnter(Collision collision)
    {
        _isjumping = false;
    }

}
