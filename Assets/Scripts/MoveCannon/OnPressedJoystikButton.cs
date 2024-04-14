using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnPressedJoystikButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] ControllerCannon controllerCannon;
    [Header("0-верх, 1-низ, 2-право,3-лево")]
    public int index;
    private Vector2[] directions = new Vector2[4] { Vector2.up, Vector2.down, Vector2.right, Vector2.left };
    private bool pressed = false;
    private bool down = false;
    public void FingerEnter()
    {
        pressed = true;
    }
    public void FingerExit()
    {
        pressed = false;
    }
    public void FingerDown()
    {
        down = true;

    }
    public void FingerUp()
    {
        down = false;
    }
    private void Update()
    {
        if (pressed && down)
        {
            controllerCannon.Move(directions[index]);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        FingerEnter();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        FingerExit();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        FingerDown();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        FingerUp();
    }
}
