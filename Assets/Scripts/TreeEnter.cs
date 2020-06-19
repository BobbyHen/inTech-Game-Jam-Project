using UnityEngine;
using UnityEngine.SceneManagement;

public class TreeEnter : MonoBehaviour
{
   private GameObject player;  

   void OnCollisionEnter2D(Collision2D other)
   {
        player = GameObject.FindGameObjectWithTag("Player");

        if (other.gameObject.CompareTag("Player"))
        {
            player.transform.position = new Vector3(2.18f, 26.59f, -12.34044f);
        //  SceneManager.LoadScene(2);
        //  Debug.Log("Collision");

        }
    }
}
