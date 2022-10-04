using UnityEngine;

public class ProduceUnitComand : IProduceUnitComand
{
    public GameObject Prefab => _prefab;
    [InjectAsset("Tank")] protected GameObject _prefab;
}