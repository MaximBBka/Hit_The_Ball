using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ControllerCannon : MonoBehaviour
{
    [SerializeField] private Camera mainCamera_stay;
    [SerializeField] private Explorer explorer;
    [SerializeField] private Transform Joystick;
    [SerializeField] private MoveCannonSystem moveCannonSystem;
    public void Move(Vector2 direction)
    {
        if (moveCannonSystem != null)
        {
            if (direction == Vector2.up)
            {
                moveCannonSystem.CannonUp();
            }
            if (direction == Vector2.down)
            {
                moveCannonSystem.CannonDown();
            }
            if (direction == Vector2.left)
            {
                moveCannonSystem.AllCannonLeft();
            }
            if (direction == Vector2.right)
            {
                moveCannonSystem.AllCannonRight();
            }
        }
    }
    private void Update()
    {
        ChekMobileVersion();
        if (!Joystick.gameObject.activeSelf)
        {
            if (Input.GetKey(KeyCode.A))
            {
                Move(Vector2.left);
            }
            if (Input.GetKey(KeyCode.D))
            {
                Move(Vector2.right);
            }
            if (Input.GetKey(KeyCode.W))
            {
                Move(Vector2.up);
            }
            if (Input.GetKey(KeyCode.S))
            {
                Move(Vector2.down);
            }
        }
    }
    public void ChekMobileVersion()
    {
        if (explorer.isMobile)
        {
            Joystick.gameObject.SetActive(mainCamera_stay.gameObject.activeSelf);
        }
    }
    public void Start()
    {
        Joystick.gameObject.SetActive(explorer.isMobile);
    }
}
