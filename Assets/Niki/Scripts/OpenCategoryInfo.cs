using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCategoryInfo : MonoBehaviour
{
    [SerializeField] private GameObject info;


    public void OpenInfo()
    {
        var _info = Instantiate(info, GameObject.Find("PaikatList").transform);
    }
}
