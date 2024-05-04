using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MCG.Core.Base
{
    [RequireComponent(typeof(CardUIScript))]
    public class CardScript : MonoBehaviour, ICardState, IMatchable, IEnableDisable
    {
        private int _uniqueId;
        private CardUIScript _cardUIScript;
        [SerializeField] private CardTemplate cardTemplate;
        private bool _isCardReveal = false;
        private bool _isMatched = false;
        private bool _canFlip = true;
        [SerializeField] private GameObject cardFrontObj;
        [SerializeField] private GameObject cardBackObj;

        public bool IsRevealed => _isCardReveal;

        public bool IsMatched => _isMatched;

        public bool CanFlip => _canFlip;
        public int UniqueId => _uniqueId;

        private void Awake()
        {
            _cardUIScript = GetComponent<CardUIScript>();
        }
        public void SetTheCardForStart(Sprite iconSprite, int uniqueId)
        {
            _uniqueId = uniqueId;
            _canFlip = true;
            _isCardReveal = false;
            _isMatched = false;
            _cardUIScript.SetCardFaces(cardTemplate, iconSprite);
            SetRightFaceOfCard();
        }
        private void SetRightFaceOfCard()
        {
            cardFrontObj.SetActive(_isCardReveal);
        }

        public bool IsCardSelectable => !IsMatched && CanFlip && !IsRevealed;

        public void Flip()
        {
            if (!_canFlip)
            {
                return;
            }
            _isCardReveal = !_isCardReveal;
            SetRightFaceOfCard();
        }

        public void OnMatched()
        {
            _canFlip = false;
            _isMatched = true;
            _isCardReveal = true;
        }

        public void OnDismatched()
        {
            _canFlip = true;
            _isMatched = false;
            Invoke(nameof(Flip), .5f);
        }

        public void PerformOnEnable()
        {
            gameObject.SetActive(true);
        }

        public void PerformOnDisable()
        {
            gameObject.SetActive(false);
        }
    }
}