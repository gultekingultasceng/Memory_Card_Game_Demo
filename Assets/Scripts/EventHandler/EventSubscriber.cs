using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MCG.Core.EventHandler
{
    public static class EventSubscriber
    {
        public static void Subscribe(EventPublisher publisher, Action func)
        {
            publisher.MyAction += func;
        }

        public static void Unsubscribe(EventPublisher publisher, Action func)
        {
            publisher.MyAction -= func;
        }
    }
    public static class EventSubscriber<T>
    {
        public static void Subscribe(EventPublisher<T> publisher, Action<T> func)
        {
            publisher.MyAction += func;
        }

        public static void Unsubscribe(EventPublisher<T> publisher, Action<T> func)
        {
            publisher.MyAction -= func;
        }
    }
    public static class EventSubscriber<T1, T2>
    {
        public static void Subscribe(EventPublisher<T1, T2> publisher, Action<T1, T2> func)
        {
            publisher.MyAction += func;
        }

        public static void Unsubscribe(EventPublisher<T1, T2> publisher, Action<T1, T2> func)
        {
            publisher.MyAction -= func;
        }
    }
}

