using System.Threading.Tasks;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;

namespace Core.CommandExecutors
{
    public class TeleportCommandExecutor: CommandExecutorBase<ITeleportCommand>, ICommandExecutor
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private Animator _animator;
        
        private static readonly int IsTeleported = Animator.StringToHash("Teleport");

        public override async Task ExecuteSpecificCommand(ITeleportCommand command)
        {
            _animator.SetTrigger(IsTeleported);
            _transform.position = command.Target;
        }
    }
}