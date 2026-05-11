using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CategoryInfo : MonoBehaviour
{

    public void Close()
    {
        AudioManager.PlayPop();
        Destroy(gameObject);
    }
}
