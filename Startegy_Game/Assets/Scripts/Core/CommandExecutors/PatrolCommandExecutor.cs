using System.Threading.Tasks;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;

namespace Core
{
    public class PatrolCommandExecutor : CommandExecutorBase<IPatrolCommand>, ICommandExecutor
    {
        public override async Task ExecuteSpecificCommand(IPatrolCommand command)
        {
            var position = gameObject.GetComponent<Transform>().position;
            Debug.Log($"Starting to patrol from {command.From} to {command.To}");
        }
    }
}