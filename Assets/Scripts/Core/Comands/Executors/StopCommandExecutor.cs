using UnityEngine;

public class StopCommandExecutor : CommandExecutorBase<IProduceUnitComand>
{
    public override void ExecuteSpecificCommand(IProduceUnitComand command)
    {
        Debug.Log("останавливаюсь!");
    }
}