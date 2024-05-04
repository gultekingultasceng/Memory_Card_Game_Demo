using MCG.Core.Base;
using MCG.Core.EventHandler;
using MCG.Core.Managers;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace MCG.Core.UI
{
    public class GamePanelUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI currentRoundInfoText;
        [SerializeField] private TextMeshProUGUI timerText;
        [SerializeField] private RectTransform timerFillBar;
        private float _timerFillBarWidth;

        [SerializeField] private List<PlayerPanel> playerPanels = new List<PlayerPanel>();
        private List<PlayerScript> _playerlist;
        public void SetPlayerDataAtStart(List<PlayerScript> playerList)
        {
            _playerlist = playerList;
            _timerFillBarWidth = timerFillBar.transform.parent.GetComponent<RectTransform>().rect.width;
            for (int i = 0; i < playerPanels.Count; i++)
            {
                PlayerPanel playerPanel = playerPanels[i];
                if (i <= _playerlist.Count - 1)
                {
                    PlayerScript player = _playerlist[i];
                    UpdatePlayerData(i);
                    SetPlayerPanelsAlpha();
                    playerPanel.playerNameText.text = player.PlayerName;
                    playerPanel.playerAvatarImage.sprite = player.PlayerAvatar;
                }
                else
                {
                    playerPanels[i].playerCanvasGroup.alpha = 0;
                }
            }
            EventSubscriber<int, int>.Subscribe(GameplayManager.Instance.OnRoundChange, SetRound);
            EventSubscriber<float, float>.Subscribe(GameplayManager.Instance.OnRoundTimeChange, SetTimer);
        }
        public void SetRound(int currentRound, int maxRound)
        {
            currentRoundInfoText.text = $"{currentRound}/{maxRound}";
        }
        public void SetTimer(float roundTimeAsSecond, float initialRoundTimeAsSecond)
        {
            int minutes = Mathf.FloorToInt(roundTimeAsSecond / 60f);
            int seconds = Mathf.FloorToInt(roundTimeAsSecond % 60f);
            string countdownString = string.Format("{0:00}:{1:00}", minutes, seconds);
            timerText.text = countdownString;
            timerFillBar.sizeDelta = new Vector2(_timerFillBarWidth * (roundTimeAsSecond / initialRoundTimeAsSecond), timerFillBar.rect.height);
        }
        private void SetPlayerPanelsAlpha()
        {
            for (int i = 0; i < _playerlist.Count; i++)
            {
                playerPanels[i].playerCanvasGroup.alpha = _playerlist[i].IsMyTurnToPlay ? 1f : .7f;
            }
        }
        public void UpdatePlayerData(int playerIndex)
        {
            PlayerPanel playerPanel = playerPanels[playerIndex];
            PlayerScript playerScript = _playerlist[playerIndex];
            playerPanel.playerScoreText.text = playerScript.PlayerScore.ToString();
            playerPanel.playerPointText.text = playerScript.PlayerPoint.ToString();
            SetPlayerPanelsAlpha();
        }
    }
}