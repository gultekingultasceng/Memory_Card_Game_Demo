using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : Singleton<DeckManager>
{
    [SerializeField] private CardPool cardPool;
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private Sprite[] cardIcons;
    private List<CardScript> _generatedDeck;
    
    public void Initialize(int rowCount, int columnCount)
    {
        GenerateDeckForGame(rowCount,columnCount);
    }
    private void GenerateDeckForGame(int rowCount, int columnCount)
    {
        _generatedDeck = new List<CardScript>();
        List<Sprite> tempCardIconList = new List<Sprite>();
        foreach (var card in cardIcons)
        {
            tempCardIconList.Add(card);
        }
        int numberOfDifferentCards = (rowCount * columnCount) / 2;
        for (int i = 0; i < numberOfDifferentCards; i++)
        {
            int randomIndexForCardIcons = Random.Range(0, tempCardIconList.Count);
            Sprite cardIcon = tempCardIconList[randomIndexForCardIcons];
            tempCardIconList.Remove(cardIcon);
            //GENERATE CARD
            CardScript card = CreateCard();
            CardScript cardDuplicated = CreateCard();
            card.SetTheCardForStart(cardIcon , i);
            cardDuplicated.SetTheCardForStart(cardIcon , i);
            _generatedDeck.Add(card);
            _generatedDeck.Add(cardDuplicated);
        }
        _generatedDeck.Shuffle();
    }
    
    private CardScript CreateCard()
    {
        return cardPool.GetObject(cardPrefab,this.transform);
    }
    public List<CardScript> GetDeck()
    {
        return _generatedDeck;
    }

    
}
