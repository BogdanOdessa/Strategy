using System.Threading.Tasks;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;

namespace Core
{
    public class AttackCommandExecutor : CommandExecutorBase<IAttackCommand>, ICommandExecutor
    {
        public override async Task ExecuteSpecificCommand(IAttackCommand command)
        {
            //Debug.Log(command.Attackable != null ? $"Attacking {command.Attackable}" : "No Target To Attack");
        }
    }
}