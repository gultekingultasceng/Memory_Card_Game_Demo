using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFactory<T,P1,P2>
{
    public abstract T Create(P1 param1, P2 param2);
}
