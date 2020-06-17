using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
   public void SceneSwitch()
   {
       SceneManager.LoadScene(0);
   }
}
