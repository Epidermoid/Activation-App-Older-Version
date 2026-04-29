using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBerry : MonoBehaviour
{
    [SerializeField] private string type;
    private ConstantSpawner constantSpawner;

    [SerializeField] private GameObject die;
    private void Start()
    {
        constantSpawner = GameObject.Find("-ConstantSpawner").GetComponent<ConstantSpawner>();
    }

    private void OnMouseDown()
    {
        var ins = Instantiate(die, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(ins, 1f);
        constantSpawner.ammountActive--;
        PlayerPrefs.SetInt(type, PlayerPrefs.GetInt(type) + 1);
        Destroy(gameObject);
    }
}
