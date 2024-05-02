using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMatchable
{
    bool IsMatched { get; }
    void OnMatched();
    void OnDismatched();
}
