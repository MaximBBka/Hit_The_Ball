using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinWallLeft : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    void Update()
    {
        transform.Rotate(Vector3.down, speed * Time.deltaTime);
    }
}
