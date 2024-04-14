using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrajectoryRender : MonoBehaviour
{


    private void Start()
    {
        //PlayerPrefs.SetString("LevelList", JsonUtility.ToJson(new List<LevelStatus>(25)));
        foreach (var i in JsonUtility.FromJson<List<LevelStatus>>(PlayerPrefs.GetString("LevelList")))
        {
            Debug.Log($"{i.status} ++++++ {i.index}");
        }
    }

}
[System.Serializable]
public class LevelStatus
{
    public int index;
    public bool status;
    public float stars;
}
    
