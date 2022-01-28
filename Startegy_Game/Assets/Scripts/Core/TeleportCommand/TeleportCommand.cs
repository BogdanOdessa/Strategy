using Abstractions.Commands;
using UnityEngine;

namespace Core.TeleportCommand
{
    public sealed class TeleportCommand : ITeleportCommand
    {
        public Vector3 Target { get; }
        
        public TeleportCommand(Vector3 target)
        {
            Target = target;
        }
    }
}