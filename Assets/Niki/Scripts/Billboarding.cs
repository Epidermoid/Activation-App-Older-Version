using UnityEngine;

public class Billboarding : MonoBehaviour
{
    

    private Transform myTransform;

    private GameObject cameraOb;
    private Transform cameraTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myTransform = GetComponent<Transform>();
        cameraOb = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        cameraTransform = cameraOb.transform;
        myTransform.forward = cameraTransform.forward;
    }


}
