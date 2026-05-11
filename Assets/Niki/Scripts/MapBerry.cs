using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBerry : MonoBehaviour
{
    [SerializeField] private string type;
    private ConstantSpawner constantSpawner;

    private AudioManager audioManager;

    [SerializeField] private GameObject die;
    private void Start()
    {
        audioManager = GameObject.Find("-AudioManager").GetComponent<AudioManager>();
        constantSpawner = GameObject.Find("-ConstantSpawner").GetComponent<ConstantSpawner>();
    }

    private void OnMouseDown()
    {
        AudioManager.PlayPop();
        var ins = Instantiate(die, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(ins, 1f);
        constantSpawner.ammountActive--;
        PlayerPrefs.SetInt(type, PlayerPrefs.GetInt(type) + 1);
        if (type == "GoldBerry")
        {
            
        }
        Destroy(gameObject);
    }
}
