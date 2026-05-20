using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{

    public static AudioManager Instance;
    public Slider slider;

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
    void Start()
    {
        audioSource.volume = PlayerPrefs.GetFloat("Vol", 1);
        slider.value = PlayerPrefs.GetFloat("Vol", 1); 
    }

    public static void PlayPop()
    {
        audioSource.clip = clips[0];
        audioSource.pitch = Random.Range(1f - 0.05f, 1f + 0.05f);
        audioSource.Play();
    }


    public void ChangeVolume(float vol)
    {
        audioSource.volume = vol;
        PlayerPrefs.SetFloat("Vol", vol);
    }
}
