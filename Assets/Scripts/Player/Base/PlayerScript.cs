using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace MCG.Core.Base
{
    public class PlayerScript : PlayerTemplate, IPlayable
    {
        public PlayerScript(string name, Sprite avatar)
        {
            playerName = name;
            playerAvatar = avatar;
            playerScore = 0;
            playerPoint = 0;
        }
        private bool _isMyTurn = false;
        public Sprite PlayerAvatar => playerAvatar;
        public string PlayerName => playerName;
        public int PlayerPoint => playerPoint;
        public int PlayerScore => playerScore;
        public bool IsMyTurnToPlay { get => _isMyTurn; set => _isMyTurn = value; }

        public void EarnPoint()
        {
            playerPoint++;
        }
        public void EarnScore()
        {
            playerScore++;
        }
        public void ResetPoint()
        {
            playerPoint = 0;
        }

    }
}