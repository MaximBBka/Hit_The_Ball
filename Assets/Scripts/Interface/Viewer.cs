using UnityEngine;

public interface IViewer
{
    public void Show(GameObject uipanel);

    public void Hide(GameObject uipanel);
}
public class Viewer : MonoBehaviour, IViewer
{
    public virtual void Hide(GameObject uipanel)
    {
        uipanel.SetActive(false);
    }

    public virtual void Show(GameObject uipanel)
    {
        uipanel.SetActive(true);
    }

}
