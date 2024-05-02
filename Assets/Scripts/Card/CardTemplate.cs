using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardTemplate : ScriptableObject
{
    [SerializeField] private Sprite cardFrontSprite;
    [SerializeField] private Sprite cardBackSprite;
    public Sprite GetCardFrontSprite => cardFrontSprite;
    public Sprite GetCardBackSprite => cardBackSprite;
}
