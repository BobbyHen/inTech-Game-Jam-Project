using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    public Animator animator;
    public float jumpForce;
    public bool isJumping, isCrouching;
    float horizontalMove = 0f;
    public SpriteRenderer spriteR;
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

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground")){
            isJumping = false;
            animator.SetBool("isJumping", false);

            rb.velocity = Vector2.zero;
            Debug.Log("OnCollisionEnter2D Called");
        }
    }
}
