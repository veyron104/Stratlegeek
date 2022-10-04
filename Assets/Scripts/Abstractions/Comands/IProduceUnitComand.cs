using UnityEngine;

public interface IProduceUnitComand : ICommand
{
    GameObject Prefab { get; }
}