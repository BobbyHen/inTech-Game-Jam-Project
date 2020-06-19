using UnityEngine;
using UnityEngine.SceneManagement;

public class TreeExitRight : MonoBehaviour
{
   private GameObject player;
   void OnCollisionEnter2D(Collision2D other)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (other.gameObject.CompareTag("Player"))
        {
            player.transform.position = new Vector3(31.53f, 1.89f, -12.34044f); 
        //  SceneManager.LoadScene(0);
        //  Debug.Log("Collision");
        }
    }
}
