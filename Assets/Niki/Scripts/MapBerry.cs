using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBerry : MonoBehaviour
{
    [SerializeField] private string type;
    private ConstantSpawner constantSpawner;

    private AudioManager audioManager;
    private AchievementManager achievementManager;

    [SerializeField] private GameObject die;
    private void Start()
    {
        audioManager = GameObject.Find("-AudioManager").GetComponent<AudioManager>();
        constantSpawner = GameObject.Find("-ConstantSpawner").GetComponent<ConstantSpawner>();
        achievementManager = GameObject.Find("-AchievementManager").GetComponent<AchievementManager>();
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
            if (PlayerPrefs.GetInt("A2Complete", 0) == 0 || PlayerPrefs.GetInt("A2Pending", 0) == 0)
            {
                PlayerPrefs.SetInt("A2Pending", 1);
                PlayerPrefs.SetInt("Unclaimed", PlayerPrefs.GetInt("Unclaimed", 0) + 1);

                achievementManager.CheckUncheckedNotifs();

                achievementManager.CheckPendingAndComplete();
            }
        }

        Destroy(gameObject);
    }
}
