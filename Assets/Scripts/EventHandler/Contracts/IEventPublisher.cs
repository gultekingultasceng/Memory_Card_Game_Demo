using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEventPublisher<T>
{
    public Action<T> MyAction
    {
        get; set;
    }
    void Publish(T Data);
}

public interface IEventPublisher
{
    public Action MyAction
    {
        get; set;
    }
    void Publish();
}
