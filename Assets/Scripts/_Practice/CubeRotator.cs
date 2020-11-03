using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeRotator : MonoBehaviour
{
    public GameObject cube;
    public Slider rotationSlider;

    float yRot;
    Vector3 cubeRot;

    public static GameObject selectedObj;
    public static Vector3 selectedObjRot;

    // Start is called before the first frame update
    void Start()
    {
        cubeRot = cube.transform.eulerAngles;
        rotationSlider.value = 0;

        CubeManager.ObjectTouchHandler += ResetSlider;
    }

    public void OnSlide(float val)
    {
        //yRot = cubeRot.y;
        //yRot += val;
        //cube.transform.localRotation = Quaternion.Euler(new Vector3(cubeRot.x, yRot, cubeRot.z));
        if (selectedObj != null)
        {
            yRot = selectedObjRot.y;
            yRot += val;
            selectedObj.transform.localRotation = Quaternion.Euler(new Vector3(selectedObjRot.x, yRot, selectedObjRot.z));
        }
    }

    public void ResetSlider()
    {
        rotationSlider.value = 0;
    }
}
