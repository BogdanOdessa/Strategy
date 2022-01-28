using Abstractions;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using Core;
using UniRx;
using UnityEngine;
using Zenject;

public class MainBuildingCommandQueue : MonoBehaviour, ICommandsQueue
{
    [Inject] CommandExecutorBase<IProduceUnitCommand> _produceUnitCommandExecutor;
    [Inject] CommandExecutorBase<ISetRallyPointCommand> _setRallyPointCommandExecutor;
    
    private ReactiveCollection<IUnitProductionTask> _queue = new ReactiveCollection<IUnitProductionTask>();
    public ICommand CurrentCommand => default;

    public void Clear() { }

    public async void EnqueueCommand(object command)
    {
        await _setRallyPointCommandExecutor.TryExecuteCommand(command);
        await _produceUnitCommandExecutor.TryExecuteCommand(command);
    }
}

