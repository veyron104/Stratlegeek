using System.Collections.Generic;
using UnityEngine;

public class BottomLeftPresenter : MonoBehaviour
{
    [SerializeField] SoloTargetPresenter _soloTargetPanel;

    [SerializeField] Transform _groupTargetPanel;
    [SerializeField] SimpleTargetPresenter _simpleTargetPrefab;
    [SerializeField] List<SimpleTargetPresenter> _targetsInfo = new List<SimpleTargetPresenter>();

    private void Start()
    {
        SelectManager.OnSelected += OnSelected;
        OnSelected(null);
    }

    public void OnSelected(ISelectable target)
    {
        if (target == null)
        {
            _soloTargetPanel.gameObject.SetActive(false);
            //_groupTargetPanel.gameObject.SetActive(false);
        }
        else
        {
            _soloTargetPanel.gameObject.SetActive(true);
            //_groupTargetPanel.gameObject.SetActive(target.Length != 1);

            //if (target.Length == 1) 
                _soloTargetPanel.SetTarget(target);
            //else
            //{
            //    for (int i = _targetsInfo.Count - 1; i >= 0; i--)
            //    {
            //        Destroy(_targetsInfo[i].gameObject);
            //    }
            //    foreach (var target in target)
            //    {
            //        _targetsInfo.Add(Instantiate(_simpleTargetPrefab, _groupTargetPanel));
            //        _targetsInfo[_targetsInfo.Count - 1].SetTarget(target);
            //    }
            //}
        }
    }

    private void Update()
    {
        if (_soloTargetPanel.isActiveAndEnabled) _soloTargetPanel.UpdateInfo();
        else
        {
            for (int i = _targetsInfo.Count - 1; i >= 0; i--)
            {
                _targetsInfo[i].UpdateInfo();
            }
        }
    }
}