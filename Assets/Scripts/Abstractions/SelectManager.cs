using System;
using UnityEngine;

public class SelectManager
{
    [SerializeField] ISelectable[] _selectedObjects;
    public static event Action<ISelectable[]> OnSelected;

    public void ChangeSelect(ISelectable selectable)
    {
        if (_selectedObjects != null)
        {
            if (_selectedObjects[0] == selectable)
            {
                SelectSwitcher();
                _selectedObjects = null;
            }
            else
            {
                SelectSwitcher();

                if (selectable == null) _selectedObjects = null;
                else
                {
                    _selectedObjects = new ISelectable[] { selectable };
                    SelectSwitcher();
                }
            }
        }
        else
        {
            if (selectable == null) _selectedObjects = null;
            else
            {
                _selectedObjects = new ISelectable[] { selectable };
                SelectSwitcher();
            }
        }

        OnSelected(_selectedObjects);
    }

    public void ChangeSelect(ISelectable[] selectable) // заменить на массив
    {
        if (_selectedObjects == selectable)
        {
            SelectSwitcher();
            _selectedObjects = new ISelectable[] { };
        }
        else
        {
            SelectSwitcher();

            Debug.Log($"selectable {selectable != null} _selectedObjects {_selectedObjects != null}");
            if (selectable != null) _selectedObjects = selectable;
            else _selectedObjects = null;
            Debug.Log($"selectable {selectable != null} _selectedObjects {_selectedObjects != null}");

            SelectSwitcher();
        }

        OnSelected(_selectedObjects);
    }

    void SelectSwitcher()
    {
        if (_selectedObjects == null || _selectedObjects.Length == 0) return;

        for (int i = _selectedObjects.Length - 1; i >= 0; i--)
        {
            _selectedObjects[i].SwitchSelection();
        }
    }
}