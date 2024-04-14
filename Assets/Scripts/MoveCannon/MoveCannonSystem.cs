using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCannonSystem : MonoBehaviour
{
    [SerializeField] private Vector2 vetricalLimit;
    [SerializeField] private Vector2 horizontallLimit;
    [SerializeField] private float speedHorizontal;
    [SerializeField] private float speedVertical;
    [SerializeField] private Transform cannon;
    public void AllCannonLeft()
    {

        // Получаем текущий поворот объекта
        Quaternion currentRotation = transform.rotation;

        // Вычисляем целевой поворот (например, влево на 90 градусов)
        Quaternion targetRotation = Quaternion.Euler(0, horizontallLimit.x, 0); // Измените угол на ваш выбор

        // Плавно вращаем объект к целевому повороту
        transform.rotation = Quaternion.RotateTowards(currentRotation, targetRotation, speedHorizontal * Time.deltaTime);
    }
    public void AllCannonRight()
    {

        // Получаем текущий поворот объекта
        Quaternion currentRotation = transform.rotation;

        // Вычисляем целевой поворот (например, влево на 90 градусов)
        Quaternion targetRotation = Quaternion.Euler(0, horizontallLimit.y, 0); // Измените угол на ваш выбор

        // Плавно вращаем объект к целевому повороту
        transform.rotation = Quaternion.RotateTowards(currentRotation, targetRotation, speedHorizontal * Time.deltaTime);
    }
    public void CannonUp()
    {
        if (cannon.rotation.x <= vetricalLimit.x)
        {
            return;
        }
        cannon.Rotate(Vector3.left, speedVertical * Time.deltaTime);

    }
    public void CannonDown()
    {
        if (cannon.rotation.x >= vetricalLimit.y)
        {
            return;
        }
        cannon.Rotate(Vector3.right, speedVertical * Time.deltaTime);
    }
}
