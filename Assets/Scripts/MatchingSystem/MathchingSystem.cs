using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathchingSystem : MonoBehaviour
{
    private List<CardScript> selectedCards = new List<CardScript>();
    public EventPublisher OnMatch = new EventPublisher();
    public EventPublisher OnDisMatch = new EventPublisher();
    public void AddTheCardMatchingSystem(CardScript card)
    {
        if (!card.IsCardSelectable)
            return;
        selectedCards.Add(card);
        card.Flip();
        if (selectedCards.Count == 2)
            CheckMatching();
    }
    private void CheckMatching()
    {
        CardScript firstCard = selectedCards[0];
        CardScript secondCard = selectedCards[1];
        selectedCards.Clear();
        if (firstCard.UniqueId == secondCard.UniqueId)
        {
            firstCard.OnMatched();
            secondCard.OnMatched();
            OnMatch.Publish();
        }
        else
        {
            firstCard.OnDismatched();
            secondCard.OnDismatched();
            OnDisMatch.Publish();
        }
    }
}
