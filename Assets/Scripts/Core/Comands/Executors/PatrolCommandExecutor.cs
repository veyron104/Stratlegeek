using UnityEngine;

public class PatrolCommandExecutor : CommandExecutorBase<IProduceUnitComand>
{
    public override void ExecuteSpecificCommand(IProduceUnitComand command)
    {
        Debug.Log("Патрулирую!");
    }
}