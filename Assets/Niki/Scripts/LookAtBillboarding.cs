using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtBillboarding : MonoBehaviour
{
    private Transform myTransform;
    private GameObject cameraOb;

    // Makes the object face the camera, but badly
    void Start()
    {
        myTransform = GetComponent<Transform>();
        cameraOb = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        myTransform.LookAt(cameraOb.transform);
    }
}
