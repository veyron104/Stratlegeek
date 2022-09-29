using System;
using UnityEngine;

public class SelectableValue: ScriptableObject
{
    public ISelectable CurentValue { get; private set; }
    public event Action<ISelectable> OnSelected;

    public void SetValue(ISelectable value)
    {
        CurentValue = value;
        OnSelected?.Invoke(value);
    }
}