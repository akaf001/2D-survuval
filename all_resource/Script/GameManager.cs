using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   public static GameManager instance;

   [SerializeField] private GameObject[] Characters;

    private int _charIndex;
    public int CharIndex
    {
        get { return _charIndex; }
        set { _charIndex = value; }
    }

    private void Awake()
    {
        if (instance == null) { 
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    private void OnLevelFinishedLoading(Scene scene,LoadSceneMode mode)
    {
        if(scene.name=="Main Game")
        {
            Instantiate(Characters[CharIndex]);
        }
    }
}
