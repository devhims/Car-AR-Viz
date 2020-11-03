using System;
using UnityEngine;

public class EventBroker 
{
    public static event Action<GameObject> CarSelectedByUser;
    public static event Action ShowMainUI;
    public static event Action ShowHandUI;
    public static event Action HideHandUI;

    public static void OnCarSelected()
    {
        CarSelectedByUser?.Invoke(CarPlacement.selectedCar);
    }

    public static void FireShowMainUIEvent()
    {
        ShowMainUI?.Invoke();
    }

    public static void FireShowHandUIEvent()
    {
        ShowHandUI?.Invoke();
    }

    public static void FireHideHandUIEvent()
    {
        HideHandUI?.Invoke();
    }

}
