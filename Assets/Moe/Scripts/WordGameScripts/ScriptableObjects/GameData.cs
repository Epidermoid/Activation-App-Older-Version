using UnityEngine;

[System.Serializable]
[CreateAssetMenu]
public class GameData : ScriptableObject
{
    public string selectedCatagoryName;
    public BoardData selectedBoardData;
}
