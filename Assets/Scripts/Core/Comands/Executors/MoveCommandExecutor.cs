using UnityEngine;

public class MoveCommandExecutor : CommandExecutorBase<IProduceUnitComand>
{
    public override void ExecuteSpecificCommand(IProduceUnitComand command)
    {
        Debug.Log("Иду!");
    }
}