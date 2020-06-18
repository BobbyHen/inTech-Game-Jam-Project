using UnityEngine;
using UnityEngine.SceneManagement;

public class TreeEnter : MonoBehaviour
{
   void OnCollisionEnter2D(Collision2D other)
     {
         if (other.gameObject.CompareTag("Player"))
         {
             SceneManager.LoadScene(2);
             Debug.Log("Collision");
         }
     }
}
