using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FixedJoystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    RectTransform rect;
    Vector2 touch = Vector2.zero;
    public RectTransform handle;

    float widthHalf;

    public PlayerControllerExample playerControllerExample;

    private void Start()
    {
        rect = GetComponent<RectTransform>();
        widthHalf = rect.sizeDelta.x * 0.5f;
    }

    public void OnDrag(PointerEventData eventData)
    {
        touch = (eventData.position - rect.anchoredPosition) / widthHalf;

        if(touch.magnitude > 1)
        {
            touch = touch.normalized;
        }
        handle.anchoredPosition = touch * widthHalf;
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("touch : " + handle.anchoredPosition);

        //위에 x -15 ~ 15 y >= 75
        if(handle.anchoredPosition.x <= 15 && handle.anchoredPosition.x >= -15 && handle.anchoredPosition.y  >= 75)
        {
            playerControllerExample.OnUpAttack();
            //Debug.Log("위");
        }
        //아래 x -15 ~ 15 y  <=-75
        else if (handle.anchoredPosition.x <= 15 && handle.anchoredPosition.x >= -15 && handle.anchoredPosition.y <= -75)
        {
            Debug.Log("아래");
        }
        //왼쪽 x <=-75 y -15 ~ 15
        else if (handle.anchoredPosition.y <= 15 && handle.anchoredPosition.y >= -15 && handle.anchoredPosition.x <= -75)
        {
            Debug.Log("왼쪽");
        }
        //오른쪽 x >=75 y -15 ~ 15
        else if (handle.anchoredPosition.y <= 15 && handle.anchoredPosition.y >= -15 && handle.anchoredPosition.x >= 75)
        {
            playerControllerExample.OnFrontAttack();
            //Debug.Log("오른쪽");
        }
        else
        {
            playerControllerExample.OnComboAttackUp();
            //Debug.Log("공격");
        }
        handle.anchoredPosition = Vector2.zero;
    }
}
