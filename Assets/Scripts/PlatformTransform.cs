using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTransform : MonoBehaviour
{
    public GameObject player;
//    private void OnCollisionEnter2D(Collision2D other)
//     {
//        if(other.gameObject.CompareTag("Player")) 
//        {
//            Vector2 characterScale = transform.localScale;
//             // this.transform.parent = other.transform;
//             other.collider.transform.SetParent(transform);
//        }
//     }

//     void OnCollisionExit2D(Collision2D other)
//     {
//         if(other.gameObject.CompareTag("Player")){
//             other.collider.transform.SetParent(null);
//         }
//     }


    private void OnTriggerEnter2D(Collider2D other)
    {
       if(other.gameObject.CompareTag("Platform")) 
       {
        //    Vector2 characterScale = transform.localScale;
            // this.transform.parent = other.transform;
            player.transform.parent = other.gameObject.transform;
       }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Platform")){
            player.transform.parent = null;
        }
    }
}
