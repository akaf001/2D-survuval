using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManuController : MonoBehaviour
{
 
    public void PlayGame()
    {
        int SelectedCharacter =
            int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

        GameManager.instance.CharIndex = SelectedCharacter;
        SceneManager.LoadScene("Main Game");
    }
}
