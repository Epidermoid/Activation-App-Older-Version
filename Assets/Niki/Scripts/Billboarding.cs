using UnityEngine;

public class Billboarding : MonoBehaviour
{
    

    private Transform myTransform;

    private GameObject cameraOb;
    private Transform cameraTransform;

    // Makes the object face the camera
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
