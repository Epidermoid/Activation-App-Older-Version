using UnityEngine;
using UnityEngine.UI;
using PrimeTween;

public class Card : MonoBehaviour
{
    [SerializeField] private Image iconImage;

    public Sprite hiddenIconSprite;
    public Sprite iconSprite;

    public int pairID;
    public bool isSelected;
    public bool isMatched; // <-- Added to track matched cards

    public CardController controller;

    public void OnCardClick()
    {
        controller.SetSelected(this);
    }

    public void SetIconSprite(Sprite sp)
    {
        iconSprite = sp;
        iconImage.sprite = hiddenIconSprite; // ensure hidden at start
    }

    public void Show()
    {
        isSelected = true;

        Tween.Rotation(transform,
            new Vector3(0f, 180f, 0f),
            0.2f);

        Tween.Delay(0.1f, () =>
        {
            iconImage.sprite = iconSprite;
        });
    }

    public void Hide()
    {
        Tween.Rotation(transform,
            new Vector3(0f, 0f, 0f),
            0.2f);

        Tween.Delay(0.1f, () =>
        {
            iconImage.sprite = hiddenIconSprite;
            isSelected = false;
        });
    }
}