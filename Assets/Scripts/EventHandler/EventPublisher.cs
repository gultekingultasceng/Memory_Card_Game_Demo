using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventPublisher<T> : IEventPublisher<T>
{
    public Action<T> MyAction { get; set; }

    public void Publish(T Data)
    {
       MyAction?.Invoke(Data);
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
