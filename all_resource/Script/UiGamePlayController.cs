using UnityEngine;
using UnityEngine.SceneManagement;

public class UiGamePlayController : MonoBehaviour
{
   public void RestartGame()
   {
        //SceneManager.LoadScene("Main Game");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
   }
    
   public void Home()
   {
        SceneManager.LoadScene("MainManu");
   }
    
}
