using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CardUIScript))]
public class CardScript : MonoBehaviour
{
    private CardUIScript _cardUIScript;
    [SerializeField] private CardTemplate cardTemplate;
    private bool _isCardReveal = false;
    [SerializeField] private GameObject cardFrontObj;
    [SerializeField] private GameObject cardBackObj;
    private void Awake()
    {
        _cardUIScript = GetComponent<CardUIScript>();
    }
    public void SetTheCardForStart(Sprite iconSprite)
    {
        _isCardReveal = false;
        _cardUIScript.SetCardFaces(cardTemplate, iconSprite);
        SetRightFaceOfCard();
    }
    private void SetRightFaceOfCard()
    {
        cardFrontObj.SetActive(_isCardReveal);
    }
    
}
