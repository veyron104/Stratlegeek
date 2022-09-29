using UnityEngine;

public interface ISelectable
{
    string ObjectName { get; }
    float Health { get; }
    float MaxHealth { get; }
    Sprite Icon { get; }

    void SwitchSelection();
}