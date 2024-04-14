using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class AdsProvider : MonoBehaviour
{
    public static AdsProvider Instance { get; private set; }
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
    private float timer = 0f;
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 300f)
        {
            ShowAds();
            timer = 0f;
        }
    }
    public void SkipRewarded()
    {
        YandexGame.RewVideoShow(0);
    }
    public void ShowAds()
    {
        YandexGame.FullscreenShow();
    }
    public void Next()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
