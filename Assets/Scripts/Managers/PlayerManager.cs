using MCG.Core.Base;
using MCG.Core.EventHandler;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MCG.Core.Managers
{
    public class PlayerManager : MonoBehaviour
    {
        private List<PlayerScript> _playerList;
        [Range(1, 2)]
        [SerializeField] private int playerCount = 2;
        [SerializeField] private Sprite[] playerAvatarIcons;
        private int _currentlyPlayerIndex = -1;
        public EventPublisher<int> OnPlayerDataChanged;
        public void GeneratePlayers()
        {
            _playerList = new List<PlayerScript>();
            _currentlyPlayerIndex = -1;
            for (int i = 0; i < playerCount; i++)
            {
                PlayerScript player = new PlayerScript($"Player {i + 1}", playerAvatarIcons[i]);
                _playerList.Add(player);
            }
        }

        public void Initialize()
        {
            OnPlayerDataChanged = new EventPublisher<int>();
            GeneratePlayers();
            SetTurn();
        }
        public int GetWinnerPlayerIndexOfGame()
        {
            int topPlayerIndex = 0;
            if (_playerList.Count == 1)
                return topPlayerIndex;
            else
            {
                var maxPlayerScore = _playerList.Max(p => p.PlayerScore);
                var topPlayerList = _playerList.Where(p => p.PlayerScore == maxPlayerScore);
                if (topPlayerList.Count() == 1)
                {
                    topPlayerIndex = _playerList.FindIndex(p => p.PlayerScore == maxPlayerScore);
                    return topPlayerIndex;
                }
                else
                {
                    return -1; // DRAFT
                }
            }
        }
        public void SetWinnerOfTheRound()
        {
            int targetIndex = 0;
            if (_playerList.Count == 1)
            {
                _playerList[targetIndex].ResetPoint();
                _playerList[targetIndex].EarnScore();
                OnPlayerDataChanged.Publish(targetIndex);
            }
            else
            {
                var maxPoint = _playerList.Max(p => p.PlayerPoint);
                var topPlayerList = _playerList.Where(p => p.PlayerPoint == maxPoint);
                if (topPlayerList.Count() == 1)
                {
                    targetIndex = _playerList.FindIndex(p => p.PlayerPoint == maxPoint);
                    _playerList[targetIndex].EarnScore();
                }
                else
                {
                    // NO ONE CAN EARN SCORE !
                }
                _playerList.ForEach(p => { p.ResetPoint(); });
                for (int i = 0; i < _playerList.Count; i++)
                {
                    OnPlayerDataChanged.Publish(i);
                }
            }

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

            foreach (PlayerScript player in _playerList)
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


    }
}