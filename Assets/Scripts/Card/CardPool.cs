using MCG.Core.Factory;
using MCG.Core.ObjectPooling;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MCG.Core.Base
{
    public class CardPool : Pool<CardScript, GameObject, Transform>
    {
        [SerializeField] private CardFactory cardFactory;
        public override Factory<CardScript, GameObject, Transform> Factory { get => cardFactory; set => throw new System.NotImplementedException(); }
    }
}