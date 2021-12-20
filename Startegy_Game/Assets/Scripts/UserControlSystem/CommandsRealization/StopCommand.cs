using Abstractions.Commands.CommandsInterfaces;

namespace UserControlSystem.CommandsRealization
{
    public class StopCommand : IStopCommand
    {
        public StopCommand(float speed)
        {
            Speed = speed;
        }

        public float Speed { get; }
    }
}