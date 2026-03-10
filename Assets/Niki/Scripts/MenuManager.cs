using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject paikat;

    [SerializeField] private GameObject karttaBottomBar;
    [SerializeField] private GameObject paikatBottomBar;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void karttaButton()
    {
        karttaBottomBar.SetActive(true);
        paikatBottomBar.SetActive(false);

        paikat.SetActive(false);
    }

    public void paikatButton()
    {
        karttaBottomBar.SetActive(false);
        paikatBottomBar.SetActive(true);

        paikat.SetActive(true);
    }

}
