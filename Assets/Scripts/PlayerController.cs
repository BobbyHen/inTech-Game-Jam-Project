using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private BoxCollider2D bc;

    private Rigidbody2D playerRb;

    private Animator playerAnim;

    private float horizontalMovement;

    private float verticalMovement;

    public float gravityModifier;

    public float jumpForce = 10;
    

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        Physics2D.gravity *= gravityModifier;

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Testing");
        horizontalMovement = Input.GetAxis("Horizontal");


        
        if(horizontalMovement > 0f)
        {
            
            playerRb.velocity = new Vector2(horizontalMovement * 5, playerRb.velocity.y);
            playerAnim.SetFloat("Speed_f", horizontalMovement);
            playerRb.transform.localScale = new Vector2(0.75f, 0.75f);

        }
        else if(horizontalMovement < 0f)
        {
            
            playerRb.velocity = new Vector2(horizontalMovement * 5, playerRb.velocity.y);
            
            // set player animation for moving left
            playerRb.transform.localScale = new Vector2(-0.75f, 0.75f);
            playerAnim.SetFloat("Speed_f", horizontalMovement);

        }
        else
        {
            playerRb.velocity = new Vector2(0, playerRb.velocity.y);
        }

        if(Input.GetKey(KeyCode.S))
        {
            playerAnim.SetBool("Crouch_Bool", true);
            playerAnim.SetTrigger("Crouch_Trigger");
        }
        else{
            playerAnim.SetBool("Crouch_Bool", false);
        }

        if(Input.GetKey(KeyCode.Space))
        {
            //Make the character Jump
        }

        if(Input.GetKeyDown(KeyCode.J))
        {
            //Character Attack
            playerAnim.SetTrigger("Attack_Trigger");
            
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            playerAnim.SetTrigger("Jump_Trigger");
            playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        
        


        /*
        if(Input.GetKey(KeyCode.D))
        {
            playerAnim.SetFloat("Speed_f", 1);
            playerRb.transform.Translate(Vector3.right * Time.deltaTime * 5);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            playerAnim.SetFloat("Speed_f", 0);
        }
        if(Input.GetKeyDown(KeyCode.J))
        {
            playerAnim.SetTrigger("Attack_Trigger");
        }
        */

    }
    private void OnCollisionEnter(Collider2D collision)
    {


        if (collision.gameObject.CompareTag("Instructions"))
        {
            Debug.Log("Press Space to Jump");
            //isOnGround = true;
            //dirtParticle.Play();
        }
        /*
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("GameOver");
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);



        }
        */

    }

}
