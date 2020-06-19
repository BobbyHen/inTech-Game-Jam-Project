using UnityEngine;
using UnityEngine.SceneManagement;

public class TreeExitLeft : MonoBehaviour
{
   private GameObject player;
   void OnCollisionEnter2D(Collision2D other)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (other.gameObject.CompareTag("Player"))
        {
            player.transform.position = new Vector3(28.3f, 4.04f, -12.34044f); 
        //  SceneManager.LoadScene(0);
        //  Debug.Log("Collision");
        }
    }
}