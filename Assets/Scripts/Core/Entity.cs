using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour, ISelectable
{
    public string ObjectName => _objectName;
    [SerializeField] string _objectName;

    public float Health => _health;
    [SerializeField] float _health;

    public float MaxHealth => _maxHealth;
    [SerializeField] float _maxHealth;

    public Sprite Icon => _icon;
    [SerializeField] Sprite _icon;

    [SerializeField] GameObject _selectionSwitcher;

    void Start()
    {
        _health = _maxHealth;
    }

    public void SwitchSelection()
    {
        _selectionSwitcher.SetActive(!_selectionSwitcher.activeSelf);
    }
}