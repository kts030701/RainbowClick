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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
