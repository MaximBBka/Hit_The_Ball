using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateGameObect : MonoBehaviour
{
    [SerializeField] private GameObject win;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            win.SetActive(true);
        }
    }
}
