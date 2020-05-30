using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    //controller input to activate the teleport
    public GameObject input;
    public GameObject player;

    
    //A custome function that teleports the player an X amount of space 
    
    /*look into refrencing the controller to attach the teleportation
    */
    
    //A custome function to jump behind the opponent
    /*
        use some kind of attack function
    */
    //the action of teleporting
    IEnumerable input()
    {
        yield return new WaitForSeconds(1);
        player.transform.position = new Vector2(Input.transform.positon.x);
    }

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
                //veriables
        float xAxis = Input.GetAxis("Horizontal");
        //float yAxis = Input.GetAxis("Vertical");
        Vector2 position = transform.position;

        //to debug the movement
        /*
            Debug.Log(x);
            Debug.Log(y);
        */

        //controls 
        position.x = position.x + 3.0f * xAxis;
        transform.position = position;
        
        /*
        first make an invincible veriable set to false 
        second make turn on on dash and teleport
        */
        
        //invincibility
        if (invincible_ = false){
            // and the dash happens
            intstance_destroy(other);
            invincible_ = true;
            // game_get_speed(gamespeed_fps);
        }
    }
}
