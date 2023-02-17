using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float movementSpeed = 1f;
    public float jumpForce = 1f;
    float horizontalMovement;

    private Rigidbody2D rigidBody;

    private Animator animator;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }   

    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        animator.SetFloat("Horizontal", horizontalMovement);

        transform.position += new Vector3(horizontalMovement, 0,0) * Time.deltaTime * movementSpeed;
    
        if(Input.GetKeyDown(KeyCode.UpArrow) && Mathf.Abs(rigidBody.velocity.y) < 0.1f)
        {
            rigidBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
        else{
        }

       
    }

    private void FixedUpdate() {
         if(horizontalMovement < 0)
        {
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale; 
        }
        else if(horizontalMovement >= 1)
        {
            Vector3 scale = transform.localScale;
            scale.x *= 1;
            transform.localScale = scale; 
        }
    }
}
