using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WindowNotification : MonoBehaviour
{
    [SerializeField] private Image stars;
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private Button next;

    public void SetTitle(string text)
    {
        title.SetText(text);
    }
    public void SetStars(float value) 
    {
        stars.fillAmount = value;
    }
    public void ShowNext()
    {
        next.gameObject.SetActive(true);
    }
}
