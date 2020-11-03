using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class IndicatorPlacement : MonoBehaviour
{
    public GameObject ringIndicator;
    public ARRaycastManager raycastManager;
    [HideInInspector] public Vector3 hitPosition;

    Vector2 screenCenter;

    // Start is called before the first frame update
    void Start()
    {
        screenCenter = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        List<ARRaycastHit> hits = new List<ARRaycastHit>();

        if (raycastManager.Raycast(screenCenter, hits, TrackableType.Planes))
        {
            if (!ringIndicator.activeSelf)
            {
                ringIndicator.SetActive(true);
                EventBroker.FireShowMainUIEvent();
            }

            hitPosition = hits[0].pose.position;

            ringIndicator.transform.localPosition = hitPosition;
        }
        else
        {
            if (ringIndicator.activeSelf)
            {
                ringIndicator.SetActive(false);
            }
        }
    }
}
