using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Audio;

public class LevelChanger : MonoBehaviour
{

    public static LevelChanger instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }

        instance = this;
    }

    Animator anim;

    int levelToLoad;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void FadeToLevel(int sceneIndex)
    {
        levelToLoad = sceneIndex;
        anim.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game and saving prefs");
        Application.Quit();
    }
}
