using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MCG.Core.Base
{
    public interface ICardState
    {
        void Flip();
        bool IsRevealed { get; }
        bool CanFlip { get; }
    }
}