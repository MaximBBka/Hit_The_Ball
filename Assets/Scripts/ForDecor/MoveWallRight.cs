using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWallRight : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float moveDistance;
    private Vector3 startPosition;
    private Vector3 distance = Vector3.right;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        transform.Translate(distance * moveSpeed * Time.deltaTime);
        if (Vector3.Distance(startPosition, transform.position) >= moveDistance)
        {
            distance = -distance;
        }
    }
}
