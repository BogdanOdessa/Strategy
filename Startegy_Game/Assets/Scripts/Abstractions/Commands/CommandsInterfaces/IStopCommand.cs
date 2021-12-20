namespace Abstractions.Commands.CommandsInterfaces
{
    public interface IStopCommand : ICommand
    {
        float Speed { get; }
    }
}