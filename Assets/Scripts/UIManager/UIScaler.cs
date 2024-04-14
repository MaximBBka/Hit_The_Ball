using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIScaler : MonoBehaviour
{

    private void OnEnable()
    {
        transform.localScale = Vector3.one * (1f + PlayerPrefs.GetFloat("UIScale"));
    }
}
