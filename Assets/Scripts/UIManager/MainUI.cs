using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using UnityEngine.Playables;

public class MainUI : Viewer
{
    public bool IsWin = false;
    [SerializeField] private Canvas window;
    [SerializeField] private Camera m_Camera;
    [SerializeField] private Camera stay_Camera;
    [SerializeField] private Camera free_Camera;
    [SerializeField] private Image starsImage;
    [SerializeField] private Text counterTex;
    [SerializeField] private Slider slider;
    [SerializeField] private CinemachineVirtualCamera VirtualCamera;
    [SerializeField] private WindowNotification notification;
    [SerializeField] private Transform defaultBall;
    private int totaltry;
    public static MainUI Instance { get; set;}
    private void Awake()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void UpdateCounterBall(int count)
    {
        counterTex.text = $"{count}";
        totaltry = count;
    }
    public void UpdateSliderPoint(float count) 
    { 
        slider.value = count;
    }
    public void SetTarget(Transform target)
    {
        VirtualCamera.Follow = target;
        VirtualCamera.LookAt = target;
        stay_Camera.gameObject.SetActive(false);
        m_Camera.gameObject.SetActive(true);
    }
    public void SetDefaultBall()
    {
        SetTarget(defaultBall);
        stay_Camera.gameObject.SetActive(true);
        m_Camera.gameObject.SetActive(false);

    }
    public void Win()
    {
        IsWin = true;
        notification.SetTitle("Ты победил!");
        notification.SetStars(1f / 3f * (totaltry + 1f));
        Show(notification.gameObject);
        notification.ShowNext();
    }
    public void Lose()
    {
        if (totaltry <= 0 && !IsWin)
        {
            notification.SetTitle("Ты проиграл!");
            notification.SetStars(0f);
            Show(notification.gameObject);
        }
    }
    public void SwitchCamera()
    {
        if (stay_Camera.gameObject.activeSelf)
        {
            window.worldCamera = stay_Camera;
        }
        else if (free_Camera.gameObject.activeSelf)
        {
            window.worldCamera = free_Camera;
        }
    }
}
