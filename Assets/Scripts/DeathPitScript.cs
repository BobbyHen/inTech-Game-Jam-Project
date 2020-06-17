using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathPitScript : MonoBehaviour
{
   void OnCollisionEnter2D(Collision2D other)
     {
         if (other.gameObject.CompareTag("Player"))
         {
             SceneManager.LoadScene(1);
             Debug.Log("Comparason accured");
         }
     }
}
