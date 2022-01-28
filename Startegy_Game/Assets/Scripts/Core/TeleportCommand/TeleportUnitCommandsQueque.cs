using System.Collections;
using System.Collections.Generic;
using Abstractions.Commands;
using UniRx;
using UnityEngine;
using Zenject;

public class TeleportUnitCommandsQueque : MonoBehaviour, ICommandsQueue
{
    [Inject] CommandExecutorBase<ITeleportCommand> _teleporCommandExecutor;

    private ReactiveCollection<ITeleportCommand> _queue = new ReactiveCollection<ITeleportCommand>();
    public ICommand CurrentCommand => default;

    public void Clear() { }

    public async void EnqueueCommand(object command)
    {
        await _teleporCommandExecutor.TryExecuteCommand(command);
    }
}
