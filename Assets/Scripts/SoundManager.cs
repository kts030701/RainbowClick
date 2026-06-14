using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public AudioSource bgm;
    public AudioSource sfx;

    public Slider bgmSlider;
    public Slider sfxSlider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bgm.volume = PlayerPrefs.GetFloat("BGMVolume", 1f);
        sfx.volume = PlayerPrefs.GetFloat("SFXVolume", 1f);

        bgmSlider.value = bgm.volume;
        sfxSlider.value = sfx.volume;

    }
    public void SetBGMVolume(float value)
    {
        bgm.volume = value;
        PlayerPrefs.SetFloat("BGMVolume", value);
    }

    public void SetSFXVolume(float value)
    {
        sfx.volume = value;
        PlayerPrefs.SetFloat("SFXVolume", value);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
