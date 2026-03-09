using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtBillboarding : MonoBehaviour
{
    private Transform myTransform;
    private GameObject cameraOb;

    // Start is called before the first frame update
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
