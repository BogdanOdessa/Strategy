namespace Abstractions.Commands.CommandsInterfaces
{
    public interface IAttackCommand : ICommand
    {
        // public int Damage { get; }
        public IAttackable Attackable { get; }
    }
}