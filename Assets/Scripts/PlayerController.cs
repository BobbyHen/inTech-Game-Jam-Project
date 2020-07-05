using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    public Animator animator;
    public SpriteRenderer spriteR;

    // the movement veriables
    public float speed;
    public float jumpForce;
    public bool isJumping, isCrouching;
    float horizontalMove = 0f;

    [Header("Dash")]
    public float dashSpd = 2750f;
    private float dashTm;
    public float strtDashTm = 0.02f;
    private int direction;

    // public Sprite idle, run, crouch, crouch_walk, jump;
    
    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), 0f);
        moveVelocity = moveInput.normalized * speed;

        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        // if(Input.GetKeyDown("d") || Input.GetButtonDown("a"))
        // {   
        //     this.GetComponent<SpriteRenderer>().sprite = run;
        // }
        Crouch();
        Flip();
        Jump();
        Dash();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }


    void Jump()
    {
        if(Input.GetButtonDown("Jump") && !isJumping)
        {   
            isJumping = true;
            animator.SetBool("isJumping", true);
            // rb.AddForce(new Vector2(rb.velocity.x, jumpForce));
            rb.AddForce(Vector2.up * jumpForce);
            Debug.Log("Space key was pressed");
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
        if(Input.GetKey("s")) 
        {
            animator.SetBool("isCrouch", true);
            Debug.Log("S was pressed");
        }
        else
        {
            animator.SetBool("isCrouch", false);
        }
    }

    void Dash()
    {
        // player is not dashing as default
        if (direction == 0)
        {
            if(Input.GetKeyDown(KeyCode.LeftShift))
            {
                if(horizontalMove < 0f)
                {
                    direction = 1;
                }
                else if(horizontalMove > 0f)
                {
                    direction = 2;
                }
                Debug.Log("left shift was pressed");
            }
        }
        else
        {        
                if(dashTm <= 0)
                {
                    direction = 0;
                    dashTm = strtDashTm;
                    rb.velocity = Vector2.zero;
                    // rb.position = rb.AddForce(Vector2.right * 100.0f);
                    // rb.AddForce(Vector2.right * 125f);
                }
                else
                {
                    // if the player can dash, they dash either left or right
                    dashTm -= Time.deltaTime;
                    dashSpd *= 1f;
                    if (direction == 1)
                    {
                        rb.AddForce(Vector2.left * dashSpd);
                    }
                    else if (direction == 2)
                    {
                        rb.AddForce(Vector2.right * dashSpd);
                    }
                    /*
                    transform.position = rb.AddForce(Vector2.right * 100.0f);
                    rb.position = transform.position;
                    //rb.AddForce(Vector2.left * 125f);
                    */
                }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Platform") ){
            isJumping = false;
            animator.SetBool("isJumping", false);

            rb.velocity = Vector2.zero;
        }

        if(other.gameObject.CompareTag("Platform")) 
        {
            this.transform.parent = other.transform;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Platform")){
            this.transform.parent = null;
        }
    }

}