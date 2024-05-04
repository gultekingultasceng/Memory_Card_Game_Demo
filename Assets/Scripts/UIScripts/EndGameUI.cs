using MCG.Core.Base;
using MCG.Core.Managers;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MCG.Core.UI
{
    public class EndGameUI : MonoBehaviour
    {
        [SerializeField] private List<PlayerPanel> playerPanels = new List<PlayerPanel>();
        [SerializeField] private Button exitButton;
        [SerializeField] private Button newGameButton;
        [SerializeField] private TextMeshProUGUI winnerText;

        private List<PlayerScript> _playerlist = new List<PlayerScript>();

        private void Start()
        {
            exitButton.onClick.AddListener(() => UIManager.Instance.MainMenu());
            newGameButton.onClick.AddListener(() => UIManager.Instance.CloseAllPanelsBeforeGameStart());
        }
        public void SetPlayerDataAtStart(List<PlayerScript> playerList, int winnerIndex)
        {
            _playerlist = playerList;
            if (winnerIndex == -1)
            {
                for (int i = 0; i < playerPanels.Count; i++)
                {
                    PlayerPanel playerPanel = playerPanels[i];
                    PlayerScript player = _playerlist[i];
                    playerPanel.playerCanvasGroup.alpha = 1f;
                    playerPanel.playerScoreText.text = player.PlayerScore.ToString();
                    playerPanel.playerNameText.text = player.PlayerName;
                    playerPanel.playerAvatarImage.sprite = player.PlayerAvatar;
                }
                winnerText.text = "DRAFT !";
            }
            else
            {
                for (int i = 0; i < playerPanels.Count; i++)
                {
                    PlayerPanel playerPanel = playerPanels[i];
                    if (i <= _playerlist.Count - 1)
                    {
                        PlayerScript player = _playerlist[i];
                        playerPanel.playerScoreText.text = player.PlayerScore.ToString();
                        playerPanel.playerNameText.text = player.PlayerName;
                        playerPanel.playerAvatarImage.sprite = player.PlayerAvatar;
                        if (winnerIndex == i)
                        {
                            playerPanel.playerCanvasGroup.alpha = 1;
                        }
                        else
                            playerPanel.playerCanvasGroup.alpha = .7f;
                    }
                    else
                    {
                        playerPanels[i].playerCanvasGroup.alpha = 0;
                    }
                }
                winnerText.text = $"WINNER IS {playerList[winnerIndex].PlayerName}";
            }

        }


    }
}