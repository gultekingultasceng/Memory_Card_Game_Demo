using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private InGameSettings _gameSettings;

    protected override void Awake()
    {
        base.Awake();
        _gameSettings = GetComponent<InGameSettings>();
    }
    private void Start()
    {
        int gridRowCount = _gameSettings.GridRowCount;
        int gridColumnCount = _gameSettings.GridColumnCount;
        DeckManager.Instance.Initialize(gridRowCount, gridColumnCount);
        GridManager.Instance.Initialize(gridRowCount , gridColumnCount);
        InputManager.Instance.Initialize();
        GameplayManager.Instance.Initialize();
        
    }
}
