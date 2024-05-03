using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pool<T, P1, P2> : MonoBehaviour, IPool<T, P1, P2>
    where T: IEnableDisable
{
    public abstract Factory<T, P1, P2> Factory { get; set; }
    private readonly Stack<T> pool = new Stack<T>();
    public T GetObject(P1 parameter1, P2 parameter2)
    {
        T obj = pool.Count > 0 ? pool.Pop() : Factory.Create(parameter1, parameter2);
        obj.PerformOnEnable();
        return obj;
    }

    public void ReturnObject(T obj)
    {
        pool.Push(obj);
        obj.PerformOnDisable();
    }
}
