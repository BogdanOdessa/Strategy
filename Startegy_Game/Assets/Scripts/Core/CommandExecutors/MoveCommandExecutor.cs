using System;
using System.Threading;
using System.Threading.Tasks;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using UnityEngine.AI;
using Utils;

namespace Core
{
    public class MoveCommandExecutor: CommandExecutorBase<IMoveCommand>, ICommandExecutor
    {
        [SerializeField] private UnitMovementStop _stop;
        [SerializeField] private Animator _animator;
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private StopCommandExecutor _stopCommandExecutor;
        private static readonly int Walk = Animator.StringToHash("Walk");
        private static readonly int Idle = Animator.StringToHash("Idle");

        public override async Task ExecuteSpecificCommand(IMoveCommand command)
        {
            _navMeshAgent.destination = command.Target;
            _animator.SetTrigger(Walk);
            var stopToken = _stopCommandExecutor.GetToken();
            try
            {
                await _stop.WithCancellation(stopToken);
            }
            catch
            {
                _navMeshAgent.isStopped = true;
                _navMeshAgent.ResetPath();
            }
           
            _stopCommandExecutor.ResetTokenSource();
            _animator.SetTrigger(Idle);
        }
    }
}