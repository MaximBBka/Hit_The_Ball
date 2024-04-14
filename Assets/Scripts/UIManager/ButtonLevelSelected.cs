using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLevelSelected : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] public Button SelfButton;

    public void SetText(string str)
    {
        text.SetText(str);
    }
}
