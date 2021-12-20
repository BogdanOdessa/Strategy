using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;

namespace UserControlSystem.CommandsRealization
{
    public class MoveCommand : IMoveCommand
    {
        public MoveCommand(Vector3 destination)
        {
            Destination = destination;
        }

        public Vector3 Destination { get; }
    }
}