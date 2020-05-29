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
        player.transform.position = new Vector2(input.transform.positon.x);
    }

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
