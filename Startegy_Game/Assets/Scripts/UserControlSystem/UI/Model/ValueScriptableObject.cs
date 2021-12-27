using System;
using System.Collections;
using System.Collections.Generic;
using Abstractions;
using UnityEngine;

public abstract class ValueScriptableObject<T> : ScriptableObject
{
    public T CurrentValue { get; private set; }
    public Action<T> OnNewValue;

    public void SetValue(T value)
    {
        CurrentValue = value;
        OnNewValue?.Invoke(value);
    }
}
