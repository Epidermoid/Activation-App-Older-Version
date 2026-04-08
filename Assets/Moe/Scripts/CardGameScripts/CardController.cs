using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    [Header("Prefabs & Grid")]
    [SerializeField] private Card cardPrefab;
    [SerializeField] private Transform gridTransform;

    [Header("Game Data")]
    [SerializeField] private CardGameData cardGameData;

    // Selected category set by the category button
    public static string SelectedCategory;

    private int totalPairs;
    private int matchedPairs = 0;

    private List<CardData> cardDataList;

    private Card firstSelected;
    private Card secondSelected;

    private bool isChecking = false;

    private void Start()
    {
        LoadCategory(SelectedCategory);
        CreateCards();
    }

    // Internal data structure for gameplay
    private class CardData
    {
        public Sprite sprite;
        public int pairID;

        public CardData(Sprite sprite, int pairID)
        {
            this.sprite = sprite;
            this.pairID = pairID;
        }
    }

    // Load the selected category from ScriptableObject
    private void LoadCategory(string categoryName)
    {
        cardDataList = new List<CardData>();
        matchedPairs = 0;

        var category = cardGameData.categories.Find(c => c.categoryName == categoryName);
        if (category == null)
        {
            Debug.LogError("Category not found: " + categoryName);
            return;
        }

        int pairID = 0;

        foreach (var pair in category.cardPairs)
        {
            cardDataList.Add(new CardData(pair.firstSprite, pairID));
            cardDataList.Add(new CardData(pair.secondSprite, pairID));
            pairID++;
        }

        totalPairs = pairID; // totalPairs = number of pairs
        ShuffleCards(cardDataList);
    }

    // Create the cards in the grid
    private void CreateCards()
    {
        foreach (var data in cardDataList)
        {
            Card newCard = Instantiate(cardPrefab, gridTransform);
            newCard.SetIconSprite(data.sprite);
            newCard.pairID = data.pairID;
            newCard.controller = this;
        }
    }

    // Called when a card is clicked
    public void SetSelected(Card card)
    {
        if (isChecking || card.isSelected || card.isMatched)
            return;

        card.Show();

        if (firstSelected == null)
        {
            firstSelected = card;
            return;
        }

        secondSelected = card;
        isChecking = true;

        StartCoroutine(CheckMatching(firstSelected, secondSelected));
    }

    // Coroutine to check match
    private IEnumerator CheckMatching(Card a, Card b)
    {
        yield return new WaitForSeconds(0.4f);

        if (a.pairID == b.pairID)
        {
            matchedPairs++;

            a.isMatched = true;
            b.isMatched = true;

            a.enabled = false;
            b.enabled = false;

            CheckWinCondition();
        }
        else
        {
            a.Hide();
            b.Hide();
        }

        firstSelected = null;
        secondSelected = null;
        isChecking = false;
    }

    // Shuffle the cards
    private void ShuffleCards(List<CardData> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);

            CardData temp = list[i];
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

    // Check if all pairs are matched
    private void CheckWinCondition()
    {
        if (matchedPairs >= totalPairs)
        {
            Debug.Log("YOU WIN!");
            OnGameWon();
        }
    }

    // Trigger win event
    private void OnGameWon()
    {
        Debug.Log("All pairs matched!");
         Debug.Log("Unlocking badge for category: " + SelectedCategory);
            BadgeManager.Instance.UnlockBadge(SelectedCategory);
        // TODO: show UI panel, play animation, sound, etc.
    }
}