using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowSettings : MonoBehaviour
{
    [SerializeField] private Slider music;
    [SerializeField] private Slider sound;
    [SerializeField] private Toggle fullScreen;
    private void OnEnable()
    {
        sound.value = SoundManager.Instance.SoundSource.volume;
        sound.onValueChanged.AddListener(SetSoundVolume);
        music.value = Audio.Instance.Music.volume;
        music.onValueChanged.AddListener(SetMusicVolume);
        fullScreen.onValueChanged.AddListener(SetFullScreen);
    }
    private void OnDisable()
    {
        sound.onValueChanged.RemoveListener(SetSoundVolume);
        music.onValueChanged.RemoveListener(SetMusicVolume);
        fullScreen.onValueChanged.RemoveListener(SetFullScreen);
    }
    public void SetMusicVolume(float value)
    {
        Audio.Instance.Music.volume = value;
        PlayerPrefs.SetFloat("MusicValue", value);
    }
    public void SetFullScreen(bool value)
    {
        Screen.fullScreenMode = value ? FullScreenMode.FullScreenWindow: FullScreenMode.Windowed;     
    }
    public void SetSoundVolume(float value)
    {
        SoundManager.Instance.SoundSource.volume = value;
        PlayerPrefs.SetFloat("SoundVolume", value);
    }

}
