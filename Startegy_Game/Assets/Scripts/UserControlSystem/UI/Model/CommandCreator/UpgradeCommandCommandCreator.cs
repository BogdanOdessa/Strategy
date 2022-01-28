using System;
using UserControlSystem.CommandsRealization;

namespace UserControlSystem
{
    public class UpgradeCommandCommandCreator: CommandCreatorBase<IUpgradeCommand>
    {
        protected override void ClassSpecificCommandCreation(Action<IUpgradeCommand> creationCallback)
            => creationCallback?.Invoke(new UpgradeCommand());
    }
}