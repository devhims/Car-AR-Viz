using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class CarManager : MonoBehaviour
{
    public static Action OnCarTouched;

    //public void OnPointerClick(PointerEventData eventData)
    //{
    //    CarPlacement.selectedCar = transform.parent.gameObject;
    //    EventBroker.OnCarSelected();
    //}

    private void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            CarPlacement.selectedCar = transform.parent.gameObject;
            EventBroker.OnCarSelected();
        }

    }
}
