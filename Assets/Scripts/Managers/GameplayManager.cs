using MCG.Core.Base;
using MCG.Core.EventHandler;
using MCG.Core.Singleton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MCG.Core.Managers
{
    public class GameplayManager : Singleton<GameplayManager>
    {
        private PlayerManager _playerManager;
        [SerializeField] private CameraSetups _cameraSetups;
        private MathchingSystem _matchingSystem;
        private int currentRoundCount, maxRoundCount;
        private float currentRoundTime, maxRoundTime;
        Coroutine roundCooldown;
        public EventPublisher<int, int> OnRoundChange;
        public EventPublisher<float, float> OnRoundTimeChange;
        public void Initialize()
        {
            _playerManager = GetComponent<PlayerManager>();
            _matchingSystem = GetComponent<MathchingSystem>();
            _playerManager.Initialize();
            OnRoundChange = new EventPublisher<int, int>();
            OnRoundTimeChange = new EventPublisher<float, float>();
            EventSubscriber<Vector2Int>.Subscribe(InputManager.Instance.OnLeftMouseButtonClick, OnTryToSelect);
            EventSubscriber.Subscribe(_matchingSystem.OnMatch, _playerManager.EarnPointToCurrentlyPlayer);
            EventSubscriber.Subscribe(_matchingSystem.OnMatch, CheckCardsMatchesAll);
            EventSubscriber.Subscribe(_matchingSystem.OnDisMatch, _playerManager.SetTurn);
            EventSubscriber<int>.Subscribe(_playerManager.OnPlayerDataChanged, UIManager.Instance.OnGamePanelUIPlayerDataChanged);
            _cameraSetups.Initialize();
        }
        private void GameEnd()
        {
            DeckManager.Instance.PutCardsBackToDeck();
            EventSubscriber.Unsubscribe(_matchingSystem.OnMatch, _playerManager.EarnPointToCurrentlyPlayer);
            EventSubscriber.Unsubscribe(_matchingSystem.OnMatch, CheckCardsMatchesAll);
            EventSubscriber.Unsubscribe(_matchingSystem.OnDisMatch, _playerManager.SetTurn);
            EventSubscriber<int>.Unsubscribe(_playerManager.OnPlayerDataChanged, UIManager.Instance.OnGamePanelUIPlayerDataChanged);
        }
        public int GetWinnerPlayerIndex()
        {
            return _playerManager.GetWinnerPlayerIndexOfGame();
        }
        public List<PlayerScript> GetPlayerList() => _playerManager.PlayerList;
        private CardScript _selectedCard;
        private void OnTryToSelect(Vector2Int coordinate)
        {
            _selectedCard = GridManager.Instance.GetCardFromCoordinate(coordinate);
            if (_selectedCard != null)
            {
                _matchingSystem.AddTheCardMatchingSystem(_selectedCard);
            }
        }
        private void CheckCardsMatchesAll()
        {
            if (DeckManager.Instance.IsAllCardsInDeckMatched())
                NextRound();
        }

        public void StartGameplay(int gameRoundTime, int gameRoundCount)
        {
            maxRoundTime = gameRoundTime * 60; // second
            currentRoundTime = maxRoundTime;
            currentRoundCount = 1;
            maxRoundCount = gameRoundCount;
            roundCooldown = StartCoroutine(RoundTimerStart());
            OnRoundTimeChange.Publish(currentRoundTime, maxRoundTime);
            OnRoundChange.Publish(currentRoundCount, maxRoundCount);
        }
        public void NextRound()
        {
            StopCoroutine(roundCooldown);
            _playerManager.SetWinnerOfTheRound();
            if (currentRoundCount + 1 > maxRoundCount)
            {
                OnRoundTimeChange.Publish(0f, maxRoundTime);
                OnRoundChange.Publish(maxRoundCount, maxRoundCount);
                UIManager.Instance.OpenEndGamePanel();
                GameEnd();
                return;
            }
            GridManager.Instance.ReArrangeTheGridForNewPlay();
            currentRoundCount++;
            currentRoundTime = maxRoundTime;
            OnRoundChange.Publish(currentRoundCount, maxRoundCount);
            roundCooldown = StartCoroutine(RoundTimerStart());
        }
        IEnumerator RoundTimerStart()
        {
            while (currentRoundTime > 0)
            {
                OnRoundTimeChange.Publish(currentRoundTime, maxRoundTime);
                currentRoundTime -= Time.deltaTime;
                yield return null;
            }
            currentRoundTime = 0;
            NextRound();
        }
    }
}