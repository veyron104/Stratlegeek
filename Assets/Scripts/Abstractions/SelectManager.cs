using System;
using UnityEngine;

public class SelectManager
{
    [SerializeField] ISelectable _selectedObject;
    public static event Action<ISelectable> OnSelected;

    public void ChangeSelect(ISelectable selectable)
    {
        if (selectable == null)
        {
            _selectedObject = null;
            OnSelected(null);
            return;
        }

        if (_selectedObject != null)
        {
            if (_selectedObject == selectable)
            {
                _selectedObject = null;
                OnSelected(null);
                return;
            }
            else OnSelected(null);
        }
        _selectedObject = selectable;

        OnSelected += selectable.SwitchSelection;
        OnSelected(_selectedObject);
    }
}