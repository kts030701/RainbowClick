using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClearManager : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI bestText;
    public AudioClip clear;
    public AudioClip bestClear;
    public AudioSource audioSource;

    public Image clearOrBest;
    public Sprite clearSprite;
    public Sprite bestSprite;
    float bestTime;

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

        bestTime = PlayerPrefs.GetFloat("Best");
        bestText.text = bestTime.ToString("F2");

        if (GameManager.isBestClear == false)
        {
            clearOrBest.sprite = clearSprite;
            audioSource.PlayOneShot(clear);
        }
        else
        {
            clearOrBest.sprite = bestSprite;
            audioSource.PlayOneShot(bestClear);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
