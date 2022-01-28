using UnityEngine;
using UserControlSystem.CommandsRealization;

namespace UserControlSystem
{
    public class TeleportCommandCommandCreator : CancellableCommandCreatorBase<ITeleportCommand, Vector3>
    {
        protected override ITeleportCommand CreateCommand(Vector3 argument) => new TeleportCommand(argument);
    }
}