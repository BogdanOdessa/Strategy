using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;

namespace UserControlSystem.CommandsRealization
{
    public class AttackCommand : IAttackCommand
    {
        // public AttackCommand(int damage)
        // {
        //     Damage = damage;
        // }
        //
        // public int Damage { get; }

        public AttackCommand(IAttackable attackable)
        {
            Attackable = attackable;
        }
        public IAttackable Attackable { get; }
    }
}