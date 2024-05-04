using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MCG.Core.Factory
{
    public abstract class Factory<T, P1, P2> : MonoBehaviour, IFactory<T, P1, P2>
    {
        public abstract T Create(P1 param1, P2 param2);
    }
}