using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : PlayerTemplate , IPlayable
{
    public PlayerScript(string name, Sprite avatar)
    {
        this.playerName = name;
        this.playerAvatar = avatar;
        this.playerScore = 0;
        this.playerPoint = 0;
    }
    private bool _isMyTurn = false;
    public Sprite PlayerAvatar => this.playerAvatar;
    public string PlayerName => this.playerName;
    public int PlayerPoint => this.playerPoint;
    public int PlayerScore => this.playerScore;
    public bool IsMyTurnToPlay { get => _isMyTurn; set => _isMyTurn = value; }

    public void EarnPoint()
    {
        this.playerPoint++;
    }
    public void EarnScore()
    {
        this.playerScore++;
    }
    public void ResetPoint()
    {
        this.playerPoint = 0;
    }
  
}
