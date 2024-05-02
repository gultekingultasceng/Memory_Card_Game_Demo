using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICardState
{
    void Flip();
    bool IsRevealed { get; }
    bool CanFlip { get; }
}
