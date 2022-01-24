using UnityEngine;

namespace Abstractions.Commands
{
    public interface ICommandExecutor
    {
        // void ExecuteCommand(object command);
    }

    public interface ICommandExecutor<T> where T : ICommand
    {
       
    }
}