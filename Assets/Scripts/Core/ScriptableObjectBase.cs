using UnityEngine;

public class ScriptableObjectBase : ScriptableObject
{
    [SerializeField] Entity _prefab;
    [SerializeField] Sprite _icon;
}