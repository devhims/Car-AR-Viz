using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CarPlacement : MonoBehaviour
{
    public static GameObject selectedCar;
    public IndicatorPlacement indicator;


    // Update is called once per frame
    void Update()
    {
        if (selectedCar != null)
        {
            selectedCar.transform.position = Vector3.Lerp(selectedCar.transform.position, indicator.hitPosition, Time.deltaTime * 2);
        }
    }

    public void SelectCar(GameObject obj)
    {
        selectedCar = obj;
        selectedCar.SetActive(true);

        Vector3 camForward = Camera.main.transform.forward;
        camForward = new Vector3(camForward.x, 0, camForward.z).normalized;
        Quaternion camRot = Quaternion.LookRotation(-camForward);
        selectedCar.transform.rotation = camRot;

        EventBroker.OnCarSelected();
    }

}
