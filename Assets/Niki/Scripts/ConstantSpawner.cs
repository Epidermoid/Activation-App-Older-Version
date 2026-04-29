using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantSpawner : MonoBehaviour
{
    public int ammountActive;

    public GameObject[] spawn;

    

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

            var randomBerryInt = Random.Range(0, 100);
            var rBerry = 0;
            if (randomBerryInt <= 20 && randomBerryInt >= 1)
            {
                rBerry = 1;
            }

            var cSpawn = Instantiate(spawn[rBerry], new Vector3(playerX + randomX, 5f, playerZ + randomZ), gameObject.transform.rotation);

            Debug.Log(randomBerryInt);

            ammountActive++;
        }
        StartCoroutine(ConstantSpawns());
    }
}
