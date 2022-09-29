using System;
using UnityEngine;

public class MouseInteractionPresenter : MonoBehaviour
{
    [SerializeField] Camera _camera;
    SelectManager selectManager;

    void Start()
    {
        selectManager = new SelectManager();
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
            {
                ISelectable selectable = hit.collider.GetComponent<ISelectable>();

                selectManager.ChangeSelect(selectable);
            }
        }
    }
}