using UnityEngine;

public class ProduceUnitCommandExecutor : CommandExecutorBase<IProduceUnitComand>
{
    public override void ExecuteSpecificCommand(IProduceUnitComand command)
    {
        Instantiate(command.Prefab, new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)), Quaternion.identity);
    }
}