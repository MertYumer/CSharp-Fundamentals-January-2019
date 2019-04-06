namespace Heroes.Commands
{
    using Heroes.Contracts;

    public class GroupAttackCommand : ICommand
    {
        private IAttackGroup attackGroup;

        public GroupAttackCommand(IAttackGroup attackGroup)
        {
            this.attackGroup = attackGroup;
        }

        public void Execute()
        {
            this.attackGroup.GroupAttack();
        }
    }
}
