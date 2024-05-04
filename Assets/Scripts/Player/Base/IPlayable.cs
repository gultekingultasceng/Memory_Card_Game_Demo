using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MCG.Core.Base
{
    public interface IPlayable
    {
        void EarnPoint();
        void EarnScore();
        bool IsMyTurnToPlay { get; set; }
    }
}