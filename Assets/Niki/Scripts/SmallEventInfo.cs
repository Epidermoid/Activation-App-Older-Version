using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallEventInfo : MonoBehaviour
{
    public GameObject linkedMarker;

    public GameObject linkedInfo;

    private MenuManager menuManager;

    // Start is called before the first frame update
    void Start()
    {
        menuManager = GameObject.Find("Canvas").GetComponent<MenuManager>();

        linkedMarker = GameObject.Find(linkedMarker.name + "(Clone)");
    }

    public void SmallGoButton()
    {

        StartCoroutine(wait());
        
    }

    IEnumerator wait()
    {
        var curInfo = Instantiate(linkedInfo, GameObject.Find("PaikatList").transform);

        var eInfo = curInfo.GetComponent<EventInfo>();
        yield return new WaitForSeconds(0.1f);
        eInfo.GoButton();
        Debug.Log(":)");
    }
}
