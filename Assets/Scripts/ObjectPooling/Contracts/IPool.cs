using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MCG.Core.ObjectPooling
{
    public interface IPool<T, P1, P2>
    {
        T GetObject(P1 parameter1, P2 parameter2);
        void ReturnObject(T obj);
    }
}