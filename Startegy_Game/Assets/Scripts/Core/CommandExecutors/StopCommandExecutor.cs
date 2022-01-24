using System.Threading;
using System.Threading.Tasks;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;

namespace Core
{
    public class StopCommandExecutor: CommandExecutorBase<IStopCommand>, ICommandExecutor
    {
        public CancellationTokenSource CancellationTokenSource { get;  private set; }

        public override async Task ExecuteSpecificCommand(IStopCommand command)
        {
            CancellationTokenSource?.Cancel();
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