using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    private Rigidbody2D playerRb;
    public Animator playerAnim;


    private GameObject firePoint;
    public GameObject projectilePrefab;
    public float projectileSpeed = 40;


    float horizontalMovement;
    public int Health = 50;
    public float playerSpeed = 10.00f;
    public float gravityModifier;
    public float jumpForce = 10.00f;
    

    
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
        firePoint = GameObject.Find("FirePoint");
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

        Crouch();
        Flip();
        Jump();
        Dash();
        //Fire();
    }


    void FixedUpdate()
    {
        Move();
    }


    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
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
        if (horizontalMovement < 0)
        {
            characterScale.x = -0.177421f;
            firePoint.transform.Rotate(0, 180, 0);
            
            
        }

        if (horizontalMovement > 0)
        {
            characterScale.x = 0.177421f;
            firePoint.transform.Rotate(0, 0, 0);

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
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            playerAnim.SetBool("isJumping", false);

            playerRb.velocity = Vector2.zero;
            //Debug.Log("OnCollisionEnter2D Called");
        }
    }

    public void PlayerDamage(int damage)
    {
        Health -= damage;
        //Kockback player
        //playerRb.AddForce(new Vector2(0,0), ForceMode2D.Impulse);
        if(Health<=0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
   








// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PlayerController : MonoBehaviour
// {
//     public float speed;
//     private Rigidbody2D rb;
//     private Vector2 moveVelocity;
//     public Animator animator;
//     public float jumpForce;
//     public bool isJumping, isCrouching;
//     float horizontalMove = 0f;
//     public SpriteRenderer spriteR;
//     // public Sprite idle, run, crouch, crouch_walk, jump;
    
//     private void Awake()
//     {

//     }

//     // Start is called before the first frame update
//     void Start()
//     {
//         rb = GetComponent<Rigidbody2D>();
//     }

//     // Update is called once per frame
//     private void Update()
//     {
//         Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), 0f);
//         moveVelocity = moveInput.normalized * speed;

//         horizontalMove = Input.GetAxisRaw("Horizontal") * speed;
//         animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

//         // if(Input.GetKeyDown("d") || Input.GetButtonDown("a"))
//         // {   
//         //     this.GetComponent<SpriteRenderer>().sprite = run;
//         // }
//         Crouch();
//         Flip();
//         Jump();
//     }

//     void FixedUpdate()
//     {
//         rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
//     }


//     void Jump()
//     {
//         if(Input.GetButtonDown("Jump") && !isJumping)
//         {   
//             isJumping = true;
//             animator.SetBool("isJumping", true);
//             // rb.AddForce(new Vector2(rb.velocity.x, jumpForce));
//             rb.AddForce(Vector2.up * jumpForce);
//             Debug.Log("Space key was pressed");
//         }
//     }

//     void Flip()
//     {
//         // Flip character sprite when going backwards
//         Vector2 characterScale = transform.localScale;
//         if(Input.GetAxisRaw("Horizontal") < 0)
//         {
//             characterScale.x = -0.177421f;
//         }

//         if(Input.GetAxisRaw("Horizontal") > 0)
//         {
//             characterScale.x = 0.177421f;
//         }
//         transform.localScale = characterScale;
//     }

//     // Crouch
//     void Crouch()
//     {
//         if(Input.GetKey("s")) 
//         {
//             animator.SetBool("isCrouch", true);
//             Debug.Log("S was pressed");
//         }
//         else
//         {
//             animator.SetBool("isCrouch", false);
//         }
//     }

//     void OnCollisionEnter2D(Collision2D other)
//     {
//         if(other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Platform") ){
//             isJumping = false;
//             animator.SetBool("isJumping", false);

//             rb.velocity = Vector2.zero;
//         }

//         if(other.gameObject.CompareTag("Platform")) 
//         {
//             this.transform.parent = other.transform;
//         }
//     }

//     void OnCollisionExit2D(Collision2D other)
//     {
//         if(other.gameObject.CompareTag("Platform")){
//             this.transform.parent = null;
//         }
//     }

// }
   