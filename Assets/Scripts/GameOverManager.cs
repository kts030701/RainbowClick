using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI bestText;

    public void OnPressRe()
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
        timeText.text = GameManager.time.ToString("F2");
        bestText.text = GameManager.bestTime.ToString("F2");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
