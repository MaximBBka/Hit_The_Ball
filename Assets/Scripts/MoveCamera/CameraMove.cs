using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Camera freeCamera;
    [SerializeField] private Explorer explorer;
    [SerializeField] private FixedJoystick joystickMove;
    [SerializeField] private FixedJoystick joystickRotation;
    public float moveSpeed = 5f;
    public float rotateSpeed = 3f;
    private Vector3 StartPos;
    public Vector3 Offset;
    private void Start()
    {
        StartPos = transform.position;
    }
    void Update()
    {
        LockCursorInPC();
        if (transform.position.x > Offset.x || transform.position.y > Offset.y || transform.position.z > Offset.z || transform.position.x < -Offset.x || transform.position.y < -0.5 || transform.position.z < -Offset.z)
        {
            transform.position = StartPos;
        }

        // ѕеремещение камеры
        float horizontalInput = !explorer.isMobile ? Input.GetAxis("Horizontal") : joystickMove.Horizontal;
        float verticalInput = !explorer.isMobile ? Input.GetAxis("Vertical") : joystickMove.Vertical;

        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput);
        moveDirection.Normalize(); // Ќормализуем вектор, чтобы движение в диагональных направлени€х не было быстрее

        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        // ѕоворот камеры

        float mouseX = !explorer.isMobile ? Input.GetAxis("Mouse X") : joystickRotation.Horizontal;
        float mouseY = !explorer.isMobile ? Input.GetAxis("Mouse Y") : joystickRotation.Vertical;

        Vector3 rotation = new Vector3(-mouseY, mouseX, 0) * rotateSpeed; // ѕоворачиваем камеру по ос€м X и Y
        transform.eulerAngles += rotation; // ѕримен€ем поворот к текущей ориентации камеры
    }
    public void LockCursorInPC()
    {
        if(!explorer.isMobile)
        {
            bool isMove = Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f;
            Cursor.lockState = isMove ? CursorLockMode.Locked : CursorLockMode.None;
        }
    }
    public void OnEnable()
    {
        if (explorer.isMobile)
        {
            joystickMove.transform.parent.gameObject.SetActive(freeCamera.gameObject.activeSelf);
        }
    }
    public void OnDisable()
    {
        joystickMove.transform.parent.gameObject.SetActive(false);
    }
}
