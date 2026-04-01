using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
[CreateAssetMenu]
public class CardGameData : ScriptableObject
{
    [System.Serializable]
    public class CardData
    {
        public Sprite cardSprite;
    }

    [System.Serializable]
    public class ThemeData
    {
        public string themeName;
        public List<CardData> cards;
    }

    public List<ThemeData> themes;
}
