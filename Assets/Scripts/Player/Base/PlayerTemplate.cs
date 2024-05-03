using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerTemplate
{
    [SerializeField] protected string playerName;
    [SerializeField] protected int playerScore;
    [SerializeField] protected int playerPoint;
    [SerializeField] protected Sprite playerAvatar;
}
