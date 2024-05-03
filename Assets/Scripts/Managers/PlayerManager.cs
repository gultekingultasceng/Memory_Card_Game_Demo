using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private List<PlayerScript> _playerList = new List<PlayerScript>();
    [Range(1,2)]
    [SerializeField] private int playerCount = 2;
    [SerializeField] private Sprite[] playerAvatarIcons;
    private int _currentlyPlayerIndex = -1;
    public EventPublisher<int> OnPlayerDataChanged;
    public void GeneratePlayers()
    {
        _currentlyPlayerIndex = -1;
        for (int i = 0; i < playerCount; i++)
        {
            PlayerScript player = new PlayerScript($"Player {(i+1)}", playerAvatarIcons[i]);
            _playerList.Add(player);
        }
    }
    public void Initialize()
    {
        OnPlayerDataChanged = new EventPublisher<int>();
        GeneratePlayers();
        SetTurn();
    }
    public List<PlayerScript> PlayerList => _playerList;
    public PlayerScript CurrentlyPlayer => _playerList[_currentlyPlayerIndex];
    public void SetTurn()
    {
        _currentlyPlayerIndex++;
        if (_currentlyPlayerIndex >= playerCount)
        {
            _currentlyPlayerIndex = 0;
        }

        foreach (PlayerScript player in _playerList )
        {
            player.IsMyTurnToPlay = player == _playerList[_currentlyPlayerIndex];
        }
        OnPlayerDataChanged.Publish(_currentlyPlayerIndex);
    }

    public void EarnPointToCurrentlyPlayer()
    {
        CurrentlyPlayer.EarnPoint();
        OnPlayerDataChanged.Publish(_currentlyPlayerIndex);
    }
    public void EarnScoreToCurrentlyPlayer()
    {
        CurrentlyPlayer.EarnScore();
        OnPlayerDataChanged.Publish(_currentlyPlayerIndex);
    }
    
}
