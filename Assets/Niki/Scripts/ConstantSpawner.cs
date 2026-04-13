using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantSpawner : MonoBehaviour
{
    public int ammountActive;

    public GameObject spawn;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ConstantSpawns());
    }



    IEnumerator ConstantSpawns()
    {
        yield return new WaitForSeconds(30f);
        if (ammountActive < 5 )
        {
            var randomX = UnityEngine.Random.Range(-30, 30);
            var randomZ = UnityEngine.Random.Range(-30, 30);

            var playerX = GameObject.Find("PlayerTarget").transform.position.x;
            var playerZ = GameObject.Find("PlayerTarget").transform.position.z;

            var cSpawn = Instantiate(spawn, new Vector3(playerX + randomX, 5f, playerZ + randomZ), gameObject.transform.rotation);

            ammountActive++;
        }
        StartCoroutine(ConstantSpawns());
    }
}
