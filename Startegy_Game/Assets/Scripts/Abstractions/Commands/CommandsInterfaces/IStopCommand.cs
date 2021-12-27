namespace Abstractions.Commands.CommandsInterfaces
{
    public interface IStopCommand : ICommand
    {
        public float Speed { get; }
    }
}