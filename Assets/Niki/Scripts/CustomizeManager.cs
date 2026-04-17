using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomizeManager : MonoBehaviour
{
    public List<Sprite> bigAvatars = new List<Sprite>(); 

    [SerializeField] public GameObject bigAvatarSlot;
    [SerializeField] public GameObject equipBigAvatar;

    private void Start()
    {
        SetAvatar();
    }

    public void ChangeAvatar (int wantedAvatar)
    {
        bigAvatarSlot.GetComponent<Image>().sprite = bigAvatars[wantedAvatar];
        PlayerPrefs.SetInt("Avatar", wantedAvatar);
    }

    public void SetAvatar()
    {
        bigAvatarSlot.GetComponent<Image>().sprite = bigAvatars[PlayerPrefs.GetInt("Avatar", 0)];
    }
}
