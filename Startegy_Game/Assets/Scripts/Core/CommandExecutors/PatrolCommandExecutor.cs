using System;
using System.Threading.Tasks;
using System.Threading;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using UnityEngine.AI;
using Utils;

namespace Core
{
    public class PatrolCommandExecutor : CommandExecutorBase<IPatrolCommand>, ICommandExecutor
    {
        [SerializeField] private UnitMovementStop _stop;
        [SerializeField] private Animator _animator;
        [SerializeField] private StopCommandExecutor _stopCommandExecutor;
        [SerializeField] private NavMeshAgent _navMeshAgent;
        private static readonly int Walk = Animator.StringToHash("Walk");
        private static readonly int Idle = Animator.StringToHash("Idle");

        public override async Task ExecuteSpecificCommand(IPatrolCommand command)
        {
            var point1 = gameObject.GetComponent<Transform>().position;
            var point2 = command.To;
            while (true)
            {
                _navMeshAgent.destination = point2;
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
                    break;
                }
                var temp = point1;
                point1 = point2;
                point2 = temp;
            }
            _stopCommandExecutor.ResetTokenSource();
            _animator.SetTrigger(Idle);
        }
    }
}

    
    