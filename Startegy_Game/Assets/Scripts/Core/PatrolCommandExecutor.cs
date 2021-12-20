using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;

namespace Core
{
    public class PatrolCommandExecutor : CommandExecutorBase<IPatrolCommand>
    {
        public override void ExecuteSpecificCommand(IPatrolCommand command)
        {
            var position = gameObject.GetComponent<Transform>().position;
            Debug.Log($"Starting to patrol from {position} to {command.PatrolDestination}");
        }
    }
}