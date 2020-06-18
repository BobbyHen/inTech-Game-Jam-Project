using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    

    private Rigidbody2D playerRb;
    public Animator playerAnim;
    float horizontalMovement;
    public float playerSpeed = 10.00f;
    public float gravityModifier;
    public float jumpForce = 10.00f;
    public float dashForce = 0.00f;


    private Vector2 moveVelocity;

    public bool isJumping, isCrouching;

    public SpriteRenderer spriteR;

    // public Sprite idle, run, crouch, crouch_walk, jump;
    
    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        Physics2D.gravity *= gravityModifier;
    }

    // Update is called once per frame
    private void Update()
    {

        

        //using this to move player velocity
        //Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), 0f);
        //moveVelocity = moveInput.normalized * playerSpeed;
        //horizontalMovement = Input.GetAxisRaw("Horizontal") * playerSpeed;
        //animation for player.
        //playerAnim.SetFloat("Speed", Mathf.Abs(horizontalMovement));
        // if(Input.GetKeyDown("d") || Input.GetButtonDown("a"))
        // {   
        //     this.GetComponent<SpriteRenderer>().sprite = run;
        // }

        //Added move method.
        Move();
        Crouch();
        Flip();
        Jump();
        Dash();
    }

  /* 
    void FixedUpdate()
    {
        playerRb.MovePosition(playerRb.position + moveVelocity * Time.fixedDeltaTime);
    }
  */

    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isJumping = true;
            playerAnim.SetBool("isJumping", true);
            // rb.AddForce(new Vector2(rb.velocity.x, jumpForce));
            
            Debug.Log("Space key was pressed");
        }
    }
    
    void Move()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        if (horizontalMovement > 0.00f)
        {
            playerRb.velocity = new Vector2(horizontalMovement * playerSpeed, playerRb.velocity.y);
            playerAnim.SetFloat("Speed", Mathf.Abs(horizontalMovement));
        }
        else if (horizontalMovement < 0.00f)
        {
            playerRb.velocity = new Vector2(horizontalMovement * playerSpeed, playerRb.velocity.y);
            playerAnim.SetFloat("Speed", Mathf.Abs(horizontalMovement));
        }
        else
        {
            playerRb.velocity = new Vector2(0, playerRb.velocity.y);
        }


    }

    void Flip()
    {
        // Flip character sprite when going backwards
        Vector2 characterScale = transform.localScale;
        if(Input.GetAxisRaw("Horizontal") < 0)
        {
            characterScale.x = -0.177421f;
        }

        if(Input.GetAxisRaw("Horizontal") > 0)
        {
            characterScale.x = 0.177421f;
        }
        transform.localScale = characterScale;
    }

    // Crouch
    void Crouch()
    {
        if (Input.GetKey(KeyCode.S))
        {
            playerAnim.SetBool("isCrouch", true);
            Debug.Log("S was pressed");
        }
        else
        {
            playerAnim.SetBool("isCrouch", false);
        }
    }

    void Dash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
           
            playerRb.AddForce(Vector2.right * 25, ForceMode2D.Impulse);
            playerAnim.SetBool("Dash_Bool", true);
            Debug.Log("Shift Is Pressed Character Dashing");
            

        }
    }    

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground")){
            isJumping = false;
            playerAnim.SetBool("isJumping", false);

            playerRb.velocity = Vector2.zero;
            Debug.Log("OnCollisionEnter2D Called");
        }
    }
}
