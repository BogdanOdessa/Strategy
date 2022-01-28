using Abstractions.Commands.CommandsInterfaces;

public class AutoAttackCommand : IAttackCommand
{
    public IAttackable Target { get; }

    public AutoAttackCommand(IAttackable target)
    {
        Target = target;
    }
}