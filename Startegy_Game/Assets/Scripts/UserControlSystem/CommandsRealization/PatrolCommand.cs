using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;

namespace UserControlSystem.CommandsRealization
{
    public class PatrolCommand : IPatrolCommand
    {
        public PatrolCommand(Vector3 patrolDestination)
        {
            PatrolDestination = patrolDestination;
        }

        public Vector3 PatrolDestination { get; }
    }
}