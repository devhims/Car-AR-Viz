using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CubeManager : MonoBehaviour
{
    public static Action ObjectTouchHandler;

    private void OnMouseDown()
    {
        CubeRotator.selectedObj = this.gameObject;
        CubeRotator.selectedObjRot = transform.localEulerAngles;

        ObjectTouchHandler?.Invoke();

    }
}
