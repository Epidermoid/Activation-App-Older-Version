using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomizeManager : MonoBehaviour
{
    public List<Sprite> bigAvatars = new List<Sprite>();
    public List<Sprite> mapAvatars = new List<Sprite>();

    [SerializeField] public GameObject bigAvatarSlot;
    [SerializeField] public GameObject equipBigAvatar;
    [SerializeField] public GameObject mapAvatar;

    private void Start()
    {
        SetAvatar();
    }

    public void ChangeAvatar (int wantedAvatar)
    {
        bigAvatarSlot.GetComponent<Image>().sprite = bigAvatars[wantedAvatar];
        mapAvatar.GetComponent<SpriteRenderer>().sprite = mapAvatars[wantedAvatar];
        
        PlayerPrefs.SetInt("Avatar", wantedAvatar);
    }

    public void SetAvatar()
    {
        bigAvatarSlot.GetComponent<Image>().sprite = bigAvatars[PlayerPrefs.GetInt("Avatar", 0)];
        mapAvatar.GetComponent<SpriteRenderer>().sprite = mapAvatars[PlayerPrefs.GetInt("Avatar", 0)];
        
    }
}
