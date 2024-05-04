using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MCG.Core.Base
{
    public interface IMatchable
    {
        bool IsMatched { get; }
        void OnMatched();
        void OnDismatched();
    }
}