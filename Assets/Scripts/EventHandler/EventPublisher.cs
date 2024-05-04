using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MCG.Core.EventHandler
{
    public class EventPublisher<T> : IEventPublisher<T>
    {
        public Action<T> MyAction { get; set; }

        public void Publish(T Data)
        {
            MyAction?.Invoke(Data);
        }
    }
    public class EventPublisher<T1, T2> : IEventPublisher<T1, T2>
    {
        public Action<T1, T2> MyAction { get; set; }

        public void Publish(T1 Data, T2 Data2)
        {
            MyAction?.Invoke(Data, Data2);
        }
    }
    public class EventPublisher : IEventPublisher
    {
        public Action MyAction { get; set; }

        public void Publish()
        {
            MyAction?.Invoke();
        }
    }
}

