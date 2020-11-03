using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExecutionOrder : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("Awake Called");
    }

    private void OnEnable()
    {
        Debug.Log("OnEnable Called");
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start Called");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update Called");
    }

    private void OnDisable()
    {
        Debug.Log("OnDisable Called");
    }

    private void OnDestroy()
    {
        Debug.Log("OnDestroy Called");
    }
}
