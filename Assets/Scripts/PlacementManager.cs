using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace CarAR
{

    public class PlacementManager : MonoBehaviour
    {
        public GameObject ringIndicator;
        public ARRaycastManager raycastManager;

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
                }

                Pose hitPose = hits[0].pose;
                ringIndicator.transform.position = hitPose.position;
            }
            else
            {
                if (ringIndicator.activeSelf)
                {
                    ringIndicator.SetActive(false);
                }
            }
        }

        public void PlaceCar(GameObject obj)
        {
            obj.transform.position = ringIndicator.transform.position;
            obj.SetActive(true);
        }
    }
}
