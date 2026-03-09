
using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
[CreateAssetMenu]
public class GameLevelData : ScriptableObject
{
    [System.Serializable]

    public struct CatagoryRecord
    {
        public string catagoryName;
        public List<BoardData> boardData;
    }
   
    public List<CatagoryRecord> data;
}
