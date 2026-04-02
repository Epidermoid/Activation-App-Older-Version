using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu]
public class CardGameData : ScriptableObject
{
    [System.Serializable]
    public class CardPair
    {
        public Sprite firstSprite;
        public Sprite secondSprite;
    }

    [System.Serializable]
    public class CardCategory
    {
        public string categoryName;
        public bool unlocked; // Like badge in quiz
        public List<CardPair> cardPairs;
    }

    public List<CardCategory> categories;
}