using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    [Header("Movement")]
    public float movementSpeed = 1f;
    public float jumpForce = 1f;
    float horizontalMovement;

    bool lookingRight = true;

    private Rigidbody2D rigidBody;

    private Animator animator;

    private bool inFloor = true;

    [SerializeField] private LayerMask isFloor;
    [SerializeField] private Transform floorController;
    [SerializeField] private Vector3 boxDimensions;


    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }   

    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        animator.SetFloat("Horizontal", Mathf.Abs(horizontalMovement));

        if(horizontalMovement < 0 && lookingRight)
        {
            Girar();
        }
        else if(horizontalMovement > 0 && !lookingRight)
        {
            Girar();
        }
        transform.position += new Vector3(horizontalMovement, 0,0) * Time.deltaTime * movementSpeed;
    
        if(Input.GetKeyDown(KeyCode.UpArrow) && Mathf.Abs(rigidBody.velocity.y) < 0.1f)
        {
            inFloor = false;
            rigidBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
        
       
    }

    private void FixedUpdate() {
        inFloor = Physics2D.OverlapBox(floorController.position, boxDimensions, 0f, isFloor);
        animator.SetBool("inFloor", inFloor); 
    }

    private void Girar()
    {
        lookingRight = !lookingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(floorController.position, boxDimensions);
    }
}
