using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardUIScript : MonoBehaviour
{
    [SerializeField] private SpriteRenderer cardIconSpriteRenderer;
    [SerializeField] private SpriteRenderer cardFrontSpriteRenderer;
    [SerializeField] private SpriteRenderer cardBackSpriteRenderer;
    public void SetCardFaces(CardTemplate cardTemplate , Sprite iconSprite)
    {
        cardIconSpriteRenderer.sprite = iconSprite;
        cardFrontSpriteRenderer.sprite = cardTemplate.GetCardFrontSprite;
        cardBackSpriteRenderer.sprite= cardTemplate.GetCardBackSprite;
    }
}
