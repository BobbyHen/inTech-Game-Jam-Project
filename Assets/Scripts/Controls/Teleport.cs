using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

[DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
public class Teleport : MonoBehaviour
{
    //controller input to activate the teleport
    public GameObject input;
    public GameObject player;
    Renderer rend;
    Color c;

    /*
    A custome function that teleports the player an X amount of space 

    look into refrencing the controller to attach the teleportation

    A custome function to jump behind the opponent and doew some kind of attack
    */

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        c = rend.material.color;
    }


        //the action of teleporting
    IEnumerable input()
    {

        player.transform.position = new Vector2(Input.transform.positon.x);
    }
    void OnTriggerEnter2D()
    {
        //when enemy colider is x far away while dash active port behind it. 
        if()
        {
            //teleport
        }
    }


    // Update is called once per frame
    void Update()
    {
                //veriables
        //float yAxis = Input.GetAxis("Vertical");
        float xAxis = Input.GetAxis("Horizontal");
        Vector2 position = transform.position;

        //to debug the movement
        //Debug.Log(x);
        //Debug.Log(y);
        

        //controls 
        position.x = position.x + 1.0f * xAxis * Time.deltaTime;
        transform.position = position;
        
        /*
        first make an invincible veriable return true on dash
        */
        
        //invincibility
        if (invincible_ = false){
            // and the dash happens
            intstance_destroy(other);
            invincible_ = true;
            // game_get_speed(gamespeed_fps);
        }
    }

    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}