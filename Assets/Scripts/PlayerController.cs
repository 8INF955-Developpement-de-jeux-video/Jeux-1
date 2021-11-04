using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    //
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    
    private float movementZ;
    private Vector3 velocity;



    [SerializeField] private bool isGrounded;
    [SerializeField] private float distanceFromGround;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity;
    [SerializeField] private float jumpHeight;

    //
    private CharacterController controller;
    private Animator anim;
    private Rigidbody rb;
    


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
    }

     void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementZ = movementVector.y;
    }

    
    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        isGrounded = Physics.CheckSphere(transform.position, distanceFromGround, groundMask);
        
        if (isGrounded && velocity.y < 0)
            velocity.y = -4f;



        movementZ = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(0, 0, movementZ);
        
        movement = transform.TransformDirection(movement);

        if(isGrounded)
        {
            if (movement != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
                Walk();

            else if (movement != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
                Run();

            else if (movement != Vector3.zero)
                Idle();

            movement *= moveSpeed;

            if (Input.GetKeyDown(KeyCode.Space))
                Jump();
        }

     
        //rb.AddForce(movement * speed);
        controller.Move(movement * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);


    }

    private void Walk()
    {
        moveSpeed = walkSpeed;
        //anim.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);

    }


    private void Run()
    {
        moveSpeed = runSpeed;
        //anim.SetFloat("Speed", 1, 0.1f, Time.deltaTime);
    }

    private  void Idle()
    {
        //anim.SetFloat("Speed", 0, 0.1f, Time.deltaTime);
    }
    
    private void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
    }
}
