using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class LevelSave : MonoBehaviour
{
    [SerializeField] private int level;
    private void Start()
    {
        level = SceneManager.GetActiveScene().buildIndex;
        if (PlayerPrefs.HasKey("LastOpenLevelIndex"))
        {
            int lastlevel = PlayerPrefs.GetInt("LastOpenLevelIndex");
            if (lastlevel > level)
            {
                return;
            }
        }
        PlayerPrefs.SetInt("LastOpenLevelIndex", level);
        Save();
    }
    public void Load()
    {
        YandexGame.LoadProgress();
    }
    public void Save()
    {
        YandexGame.savesData.LastOpenLevelIndex = level;
        YandexGame.SaveProgress();
    }
}
