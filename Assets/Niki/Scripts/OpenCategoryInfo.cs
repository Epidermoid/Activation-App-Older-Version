using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCategoryInfo : MonoBehaviour
{
    [SerializeField] private GameObject info;

    private AudioManager audioManager;
    public void OpenInfo()
    {
        audioManager = GameObject.Find("-AudioManager").GetComponent<AudioManager>();
        var _info = Instantiate(info, GameObject.Find("PaikatList").transform);
    }
}
