using UnityEngine;

public class TargetWin : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            MainUI.Instance.Win();
            MainUI.Instance.SetDefaultBall();
        }
    }
}
