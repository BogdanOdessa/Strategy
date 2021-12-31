using System.Threading;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;

namespace Core
{
    public class StopCommandExecutor: CommandExecutorBase<IStopCommand>
    {
        public CancellationTokenSource CancellationTokenSource { get;  private set; }

        public override void ExecuteSpecificCommand(IStopCommand command)
        {
            CancellationTokenSource.Cancel();
            Debug.Log("Stopped");
        }

        public CancellationToken GetToken()
        {
            CancellationTokenSource = new CancellationTokenSource();
            return CancellationTokenSource.Token;
        }

        public void ResetTokenSource()
        {
            CancellationTokenSource = null;
        }
    }
}