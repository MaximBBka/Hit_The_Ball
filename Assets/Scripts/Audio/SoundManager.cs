using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [field: SerializeField] public AudioSource SoundSource { get; private set; }
    public static SoundManager Instance { get; private set; }
    private void Awake()
    {
        if (!Instance)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
            return;
        }
        Destroy(gameObject);
    }
    private void Start()
    {
        float soundvolume = SoundManager.Instance.SoundSource.volume;
        if (PlayerPrefs.HasKey("SoundVolume"))
        {
            soundvolume = PlayerPrefs.GetFloat("SoundVolume");
        }
        PlayerPrefs.SetFloat("SoundVolume", soundvolume);
        SoundManager.Instance.SoundSource.volume = soundvolume;
    }
    public void PlayShot(AudioClip value)
    {
        SoundSource.PlayOneShot(value);
    }
}
