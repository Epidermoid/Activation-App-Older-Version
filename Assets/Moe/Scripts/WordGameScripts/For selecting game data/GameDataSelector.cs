using UnityEngine;

public class GameDataSelector : MonoBehaviour
{
    public GameData currentGameData;
    public GameLevelData levelData;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        SelectSequentialBoardData();
    }

    private void SelectSequentialBoardData()
    {
        foreach(var data in levelData.data)
        {
            if(data.catagoryName == currentGameData.selectedCatagoryName)
            {
                var boardIndex = 0; //TODO : this need to be red from external file

                if(boardIndex < data.boardData.Count)
                {
                    currentGameData.selectedBoardData = data.boardData[boardIndex];
                }
                else
                {
                    var randomIndex = Random.Range(0, data.boardData.Count);
                    currentGameData.selectedBoardData = data.boardData[randomIndex];
                }
            }
        }
    }
}
