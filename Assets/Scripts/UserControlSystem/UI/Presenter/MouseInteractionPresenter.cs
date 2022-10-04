using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseInteractionPresenter : MonoBehaviour
{
    [SerializeField] Camera _camera;
    public static SelectManager selectManager;

    void Start()
    {
        if (selectManager == null) selectManager = new SelectManager();
    }
    void Update()
    {
        if (Input.GetMouseButtonUp(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            if (Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out RaycastHit hit)) selectManager.ChangeSelect(hit.collider.GetComponent<ISelectable>());
        }
    }
}