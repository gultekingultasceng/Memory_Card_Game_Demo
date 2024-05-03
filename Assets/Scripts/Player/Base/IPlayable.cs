using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayable
{
    void EarnPoint();
    void EarnScore();
    bool IsMyTurnToPlay { get; set; }
}
