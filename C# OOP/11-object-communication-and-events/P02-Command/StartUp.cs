namespace Heroes
{
    using Heroes.Commands;
    using Heroes.Contracts;
    using Heroes.Models;

    public class StartUp
    {
        public static void Main()
        {
            Logger combatLog = new CombatLogger();
            Logger eventLog = new EventLogger();

            combatLog.SetSuccessor(eventLog);

            var warrior = new Warrior("Gosho", 10, combatLog);
            var dragon = new Dragon("Peter", 100, 25, combatLog);

            IExecutor executor = new CommandExecutor();
            ICommand command = new TargetCommand(warrior, dragon);
            ICommand attack = new AttackCommand(warrior);
        }
    }
}
