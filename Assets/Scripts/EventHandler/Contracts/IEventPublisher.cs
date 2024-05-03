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

public interface IEventPublisher<T1,T2>
{
    public Action<T1,T2> MyAction
    {
        get; set;
    }
    void Publish(T1 Data , T2 Data2);
}
