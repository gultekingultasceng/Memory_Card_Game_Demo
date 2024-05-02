using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MathcingSystem
{
    static List<CardScript> selectedCards = new List<CardScript>();
    public static void AddTheCardMatchingSystem(CardScript card)
    {
        if (!card.IsCardSelectable)
            return;
        selectedCards.Add(card);
        card.Flip();
        if (selectedCards.Count == 2)
            CheckMatching();
    }
    private static void CheckMatching()
    {
        CardScript firstCard = selectedCards[0];
        CardScript secondCard = selectedCards[1];
        selectedCards.Clear();
        if (firstCard.UniqueId == secondCard.UniqueId)
        {
            firstCard.OnMatched();
            secondCard.OnMatched();
        }
        else
        {
            firstCard.OnDismatched();
            secondCard.OnDismatched();
        }
    }
}
