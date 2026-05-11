using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager Instance;

    [SerializeField] public static AudioSource audioSource;
    [SerializeField] public static AudioClip[] clips;


    [SerializeField] public AudioClip[] rclips;



    private void Awake()
    {
        if(Instance == null)
        {
           Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
        clips = rclips;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlayPop()
    {
        audioSource.clip = clips[0];
        audioSource.pitch = Random.Range(1f - 0.05f, 1f + 0.05f);
        audioSource.Play();
    }


}
