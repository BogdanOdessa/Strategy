using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public abstract class AwaiterBase<T,T2> : IAwaiter<T>
{
    protected  T2 ParentClass;
    protected Action Continuation;
    public bool IsCompleted { get; protected set; }

    public void OnCompleted(Action continuation)
    {
        if (IsCompleted)
        {
            continuation?.Invoke();
        }
        else
        {
            Continuation = continuation;
        }
    }
    
    public abstract T GetResult();

}
