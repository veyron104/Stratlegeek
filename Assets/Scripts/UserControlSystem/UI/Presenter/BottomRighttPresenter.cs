using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BottomRighttPresenter : MonoBehaviour
{
    [SerializeField] Button _moveButton;
    [SerializeField] Button _patrolButton;
    [SerializeField] Button _attackButton;
    [SerializeField] Button _stopButton;
    [SerializeField] Button _produceButton;

    Dictionary<Type, Button> _buttonsByExecutorsType;

    [SerializeField] private AssetsContext _context;

    private void Start()
    {
        _buttonsByExecutorsType = new Dictionary<Type, Button>();
        _buttonsByExecutorsType.Add(typeof(MoveCommandExecutor), _moveButton);
        _buttonsByExecutorsType.Add(typeof(PatrolCommandExecutor), _patrolButton);
        _buttonsByExecutorsType.Add(typeof(AttackCommandExecutor), _attackButton);
        _buttonsByExecutorsType.Add(typeof(StopCommandExecutor), _stopButton);
        _buttonsByExecutorsType.Add(typeof(ProduceUnitCommandExecutor), _produceButton);
        SelectManager.OnSelected += OnSelected;
        OnSelected(null);
    }

    public void OnSelected(ISelectable target)
    {
        if (target == null) HideButtons();
        else
        {
            List<ICommandExecutor> commandExecutors = new List<ICommandExecutor>();
            commandExecutors.AddRange((target as Component).GetComponents<ICommandExecutor>());

            ShowButtons(commandExecutors);
        }
    }

    void HideButtons()
    {
        foreach (var button in _buttonsByExecutorsType)
        {
            button.Value.onClick.RemoveAllListeners();
            button.Value.gameObject.SetActive(false);
        }
    }

    void ShowButtons(List<ICommandExecutor> executors)
    {
        for (int i = 0; i < executors.Count; i++)
        {
            ICommandExecutor currentExecutor = executors[i];
            var buttonGameObject = _buttonsByExecutorsType.First(type => type.Key.IsInstanceOfType(currentExecutor)).Value;
            buttonGameObject.gameObject.SetActive(true);
            buttonGameObject.onClick.AddListener(() => OnButtonClick(currentExecutor));
        }
    }

    public void OnButtonClick (ICommandExecutor commandExecutor)
    {
        var unitProducer = commandExecutor as CommandExecutorBase<IProduceUnitComand>;
        if (unitProducer != null)
        {
            commandExecutor.ExecuteCommand(_context.Inject(new ProduceUnitComandHeir()));
            return;
        }
        
        throw new ApplicationException($"{nameof(BottomRighttPresenter)}.{nameof(OnButtonClick)}: unoounType of command {commandExecutor.GetType().FullName}!");
    }
}