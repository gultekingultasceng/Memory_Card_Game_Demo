using MCG.Core.GameSettings;
using MCG.Core.Singleton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MCG.Core.Managers
{
    public class GameManager : Singleton<GameManager>
    {
        private InGameSettings _gameSettings;
        public InGameSettings GameSettings { get { return _gameSettings; } }
        protected override void Awake()
        {
            base.Awake();
            _gameSettings = GetComponent<InGameSettings>();
        }

        private void Start()
        {
            UIManager.Instance.Initialize();
        }
        public void StartGame()
        {
            int gridRowCount = _gameSettings.GridRowCount;
            int gridColumnCount = _gameSettings.GridColumnCount;
            GridManager.Instance.Initialize(gridRowCount, gridColumnCount);
            InputManager.Instance.Initialize();
            GameplayManager.Instance.Initialize();
            UIManager.Instance.InitializeGamePanel();
            GameplayManager.Instance.StartGameplay(_gameSettings.RoundTime, _gameSettings.RoundCount);
        }
    }
}