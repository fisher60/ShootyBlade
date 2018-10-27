using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove2d : MonoBehaviour {

    private Rigidbody2D myRigidBody;
    private float horizontal = 0f;
    
    [SerializeField]
    private float speed = 10f;

    [SerializeField]
    private Transform[] groundPoints;

    [SerializeField]
    private float groundRadius = 0f;

    [SerializeField]
    private LayerMask whatIsGround;

    private bool isGrounded;

    private bool jump;

    [SerializeField]
    private float jumpForce;

    private float jumpStart = 0f;
 
    

    private void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();


    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
            jumpStart = Time.fixedDeltaTime;
        }
        isGrounded = IsGrounded();
        horizontal = Input.GetAxis("Horizontal");
        
        
        HandleMovement(horizontal);
        
    }

    private void FixedUpdate()
    {
        if (jump)
        {
            JumpFun();
        }
        ResetValues();
    }

    private void JumpFun()
    {
        Debug.Log(Time.fixedDeltaTime);
        Debug.Log(jumpStart);
        
        if (isGrounded)
        {
            isGrounded = false;

            myRigidBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            Debug.Log(isGrounded);
            //ResetValues();
            
        }
    }
    private void HandleMovement(float horizontal)
    {
        
       myRigidBody.velocity = new Vector2(horizontal * speed, 0);
    
    }

    private bool IsGrounded()
    {
        if (myRigidBody.velocity.y < 0.5)
        {
            foreach (Transform point in groundPoints)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGround);
                for (int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i].gameObject != gameObject)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }
    private void ResetValues()
    {
        jump = false;
    }
}
