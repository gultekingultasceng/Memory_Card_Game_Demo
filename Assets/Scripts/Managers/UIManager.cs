using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private InGameSettingsUI inGameSettingsPanel;
    [SerializeField] private EntryPanelUI entryPanelUI;
    [SerializeField] private GamePanelUI gamePanelUI;

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
    public void OpenEntryPanel()
    {
        entryPanelUI.gameObject.SetActive(true);
    }
    public void CloseEntryPanel()
    {
        entryPanelUI.gameObject.SetActive(false);
    }
    public void OpenSettingsPanel()
    {
        inGameSettingsPanel.gameObject.SetActive(true);
    }
    public void CloseSettingsPanel(bool withStartButton)
    {
        inGameSettingsPanel.gameObject.SetActive(false);
        if (withStartButton )
        {
            CloseAllPanelsBeforeGameStart();
        }
    }
    public void CloseAllPanelsBeforeGameStart()
    {
        CloseSettingsPanel(false);
        CloseEntryPanel();
        GameManager.Instance.StartGame();
    }
}
