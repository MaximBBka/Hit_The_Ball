using UnityEngine;
using UnityEngine.SceneManagement;

public class Explorer : MonoBehaviour
{
    public bool isMobile = false;
    private void Awake()
    {
        isMobile = Application.isMobilePlatform;
    }
    public void Next()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    public void Repit()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void GoTo(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void SkipLevel()
    {
        if (AdsProvider.Instance != null)
        {
            AdsProvider.Instance.SkipRewarded();
        }
    }
}
