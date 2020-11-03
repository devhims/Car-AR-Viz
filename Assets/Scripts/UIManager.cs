using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider slider;
    public GameObject mainUI;
    public GameObject handUI;
    public GameObject colorUI;

    Vector3 carRot;
    float yRot;

    private void OnEnable()
    {
        EventBroker.CarSelectedByUser += CarRotation;
        EventBroker.ShowMainUI += ShowMainUI;
        EventBroker.ShowMainUI += HideHandUI;
        EventBroker.ShowHandUI += ShowHandUI;
    }

    private void Start()
    {
        mainUI.gameObject.SetActive(false);
        colorUI.gameObject.SetActive(false);
        HideHandUI();
    }

    public void OnSlide(float val)
    {
        if (CarPlacement.selectedCar)
        {
            yRot = carRot.y;
            yRot += val;
            CarPlacement.selectedCar.transform.eulerAngles = new Vector3(carRot.x, yRot, carRot.z);
        }
    }

    void CarRotation(GameObject obj)
    {
        CarPlacement.selectedCar = obj;
        carRot = CarPlacement.selectedCar.transform.localEulerAngles;
        slider.value = 0f;
    }


    public void PlaceOnPlane()
    {
        if (CarPlacement.selectedCar != null)
        {
            CarPlacement.selectedCar = null;
        }
    }

    void ShowMainUI()
    {
        mainUI.gameObject.SetActive(true);
        colorUI.gameObject.SetActive(true);
    }

    void ShowHandUI()
    {
        handUI.gameObject.SetActive(true);
    }

    void HideHandUI()
    {
        handUI.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        EventBroker.CarSelectedByUser += CarRotation;
        EventBroker.ShowMainUI -= ShowMainUI;
        EventBroker.ShowMainUI -= HideHandUI;
        EventBroker.ShowHandUI -= ShowHandUI;
    }

    public void SetColor(Image image)
    {
        if (CarPlacement.selectedCar)
        {
            MeshRenderer[] meshes = CarPlacement.selectedCar.GetComponentsInChildren<MeshRenderer>();

            foreach (var mesh in meshes)
            {
                //if (mesh.transform.CompareTag("Body"))
                //{

  
                //}

                foreach (Material mat in mesh.materials)
                {
                    if (mat.name == "Body (Instance)")
                    {
                        mat.color = image.color;
                    }
                }
            }
        }
    }

    public void ShowColorPalette()
    {
        Animator anim = colorUI.GetComponentInChildren<Animator>();
        anim.speed = 1.5f;
        anim.SetTrigger("changestate");
    }
}
