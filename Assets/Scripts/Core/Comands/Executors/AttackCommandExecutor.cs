using UnityEngine;

public class AttackCommandExecutor : CommandExecutorBase<IProduceUnitComand>
{
    public override void ExecuteSpecificCommand(IProduceUnitComand command)
    {
        Debug.Log("Нападаю!");
    }
}