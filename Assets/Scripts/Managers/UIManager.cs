using MCG.Core.Singleton;
using MCG.Core.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MCG.Core.Managers
{
    public class UIManager : Singleton<UIManager>
    {
        [SerializeField] private InGameSettingsUI inGameSettingsPanel;
        [SerializeField] private EntryPanelUI entryPanelUI;
        [SerializeField] private GamePanelUI gamePanelUI;
        [SerializeField] private EndGameUI endGameUI;
        public void Initialize()
        {
            inGameSettingsPanel.Initialize(GameManager.Instance.GameSettings);
            entryPanelUI.Initialize();
            OpenEntryPanel();
        }
        public void OnGamePanelUIPlayerDataChanged(int playerIndex)
        {
            gamePanelUI.UpdatePlayerData(playerIndex);
        }
        public void InitializeGamePanel()
        {
            gamePanelUI.SetPlayerDataAtStart(GameplayManager.Instance.GetPlayerList());
            gamePanelUI.gameObject.SetActive(true);
        }
        public void OpenEndGamePanel()
        {
            endGameUI.SetPlayerDataAtStart(GameplayManager.Instance.GetPlayerList(), GameplayManager.Instance.GetWinnerPlayerIndex());
            endGameUI.gameObject.SetActive(true);
        }
        public void OpenEntryPanel()
        {
            entryPanelUI.gameObject.SetActive(true);
        }
        public void CloseEntryPanel()
        {
            entryPanelUI.gameObject.SetActive(false);
        }
        public void CloseEndGamePanel()
        {
            endGameUI.gameObject.SetActive(false);
        }
        public void MainMenu()
        {
            CloseAllPanels();
            OpenEntryPanel();
        }

        public void OpenSettingsPanel()
        {
            inGameSettingsPanel.gameObject.SetActive(true);
        }
        public void CloseSettingsPanel(bool withStartButton)
        {
            inGameSettingsPanel.gameObject.SetActive(false);
            if (withStartButton)
            {
                CloseAllPanelsBeforeGameStart();
            }
        }
        public void CloseAllPanels()
        {
            CloseSettingsPanel(false);
            CloseEntryPanel();
            CloseEndGamePanel();
        }

        public void CloseAllPanelsBeforeGameStart()
        {
            CloseAllPanels();
            GameManager.Instance.StartGame();
        }
    }
}