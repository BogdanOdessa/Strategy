using System.Collections;
using System.Collections.Generic;
using Abstractions;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UniRx;
using UnityEngine;
using Zenject;

public class UpgradeBuildingCommandQueque : MonoBehaviour, ICommandsQueue
{
    [Inject] CommandExecutorBase<IUpgradeCommand> _upgradeCommandExecutor;

    private ReactiveCollection<IUpgradeCommand> _queue = new ReactiveCollection<IUpgradeCommand>();
    public ICommand CurrentCommand => default;

    public void Clear() { }

    public async void EnqueueCommand(object command)
    {
        await _upgradeCommandExecutor.TryExecuteCommand(command);
    }
}
