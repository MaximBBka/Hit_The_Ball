using UnityEngine;
using YG;

public class WindowLevelSelected : MonoBehaviour
{
    [SerializeField] private ButtonLevelSelected prefabButton;
    [SerializeField] private Transform content;
    [SerializeField] private int lastOpenLevel;
    [SerializeField] private Explorer explorer;

    private void Start()
    {
        if (PlayerPrefs.HasKey("LastOpenLevelIndex"))
        {
            lastOpenLevel = PlayerPrefs.GetInt("LastOpenLevelIndex");
        }
        Load();
        for (int i = 0; i < lastOpenLevel; i++)
        {
            ButtonLevelSelected button = Instantiate(prefabButton, content);
            button.SetText($"Уровень {(i + 1).ToString()}");
            int index = i + 1;
            button.SelfButton.onClick.AddListener(()=>explorer.GoTo(index));
        }

    }
    private void Load()
    {
        YandexGame.LoadProgress();
        lastOpenLevel = YandexGame.savesData.LastOpenLevelIndex;
    }
}
