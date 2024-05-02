using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : Singleton<GameplayManager>
{
    public void Initialize()
    {
        EventSubscriber<Vector2Int>.Subscribe(InputManager.Instance.OnLeftMouseButtonClick, OnTryToSelect);
    }
    [SerializeField] private CardScript _selectedCard;
    private void OnTryToSelect(Vector2Int coordinate)
    {
        Debug.Log(coordinate);
        _selectedCard = GridManager.Instance.GetCardFromCoordinate(coordinate);
        if (_selectedCard != null )
        {
           MathcingSystem.AddTheCardMatchingSystem( _selectedCard );
        }
    }
}
