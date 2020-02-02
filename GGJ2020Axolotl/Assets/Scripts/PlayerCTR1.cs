using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class PlayerCTR1 : MonoBehaviour
{
    [SerializeField]
    [Range(0,15)]
    private float movementSpeed;
    [SerializeField]
    [Range(0, 15)]
    private float jumpForce;
    private Rigidbody rb;
    public bool isjumping;
    private Animator anim;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        isjumping = false;
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        Movement();
        Jump();
      
    }


    void Movement()
    {
        {
            float moveHorizontal = Input.GetAxis("Horizontal2"); float moveVertical = Input.GetAxis("Vertical2");
            Vector3 move = new Vector3(moveHorizontal, 0, moveVertical);
            anim.SetBool("Walking", move != Vector3.zero);

            if (moveHorizontal == 0 && moveVertical == 0) return;

            Vector3 movement = new Vector3(-moveHorizontal, 0f, -moveVertical); transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15F);

            if (movement != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement.normalized), 0.2f);
            }


          
            transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);
          

        }
    }
    void Jump()
    {
        if(Input.GetKey(KeyCode.KeypadEnter) && isjumping == false) 
        {
           // anim.SetBool("Walking", false);
            rb.AddForce(new Vector3(0, jumpForce, 0),ForceMode.Impulse);
            isjumping = true;
        }            
    }
    private void OnCollisionEnter(Collision collision)
    {
        isjumping = false;
    }

}
