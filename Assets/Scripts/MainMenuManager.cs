using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void OnPressPlay()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OnPressExit()
    {
        Application.Quit();
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        Screen.SetResolution(1920, 1080, FullScreenMode.Windowed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
