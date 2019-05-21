namespace P08_MilitaryElite.Core
{
    using Contracts;
    using Models;
    using Enums;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        private ICollection<ISoldier> soldiers;
        private ISoldier soldier;

        public Engine()
        {
            this.soldiers = new List<ISoldier>();
        }

        public void Run()
        {
            while (true)
            {
                var input = Console.ReadLine().Split();

                if (input[0] == "End")
                {
                    break;
                }

                string type = input[0];
                int id = int.Parse(input[1]);
                string firstName = input[2];
                string lastName = input[3];

                switch (type)
                {
                    case "Private":
                        decimal salary = decimal.Parse(input[4]);
                        soldier = GetPrivateSoldier(id, firstName, lastName, salary);
                        break;

                    case "LieutenantGeneral":
                        salary = decimal.Parse(input[4]);
                        soldier = GetLieutenantGeneral(id, firstName, lastName, salary, input);
                        break;

                    case "Engineer":
                        salary = decimal.Parse(input[4]);
                        soldier = GetEngineer(id, firstName, lastName, salary, input);
                        break;

                    case "Commando":
                        salary = decimal.Parse(input[4]);
                        soldier = GetCommando(id, firstName, lastName, salary, input);
                        break;

                    case "Spy":
                        int codeNumber = int.Parse(input[4]);
                        soldier = GetSpy(id, firstName, lastName, codeNumber);
                        break;
                }

                if (soldier != null)
                {
                    this.soldiers.Add(soldier);
                }
            }

            foreach (var soldier in this.soldiers)
            {
                Console.WriteLine(soldier);
            }
        }

        private ISoldier GetSpy(int id, string firstName, string lastName, int codeNumber)
        {
            ISpy spy = new Spy(id, firstName, lastName, codeNumber);
            return spy;
        }

        private ISoldier GetCommando(int id, string firstName, 
            string lastName, decimal salary, string[] input)
        {
            string corpsAsString = input[5];

            if (!Enum.TryParse(corpsAsString, out Corps corps))
            {
                return null;
            }

            ICommando commando = new Commando(id, firstName, lastName, salary, corps);

            for (int i = 6; i < input.Length; i += 2)
            {
                string codeName = input[i];
                string stateAsString = input[i + 1];

                if (!Enum.TryParse(stateAsString, out State state))
                {
                    continue;
                }

                IMission mission = new Mission(codeName, state);
                commando.Missions.Add(mission);
            }

            return commando;
        }

        private ISoldier GetEngineer(int id, string firstName, 
            string lastName, decimal salary, string[] input)
        {
            string corpsAsString = input[5];

            if (!Enum.TryParse(corpsAsString, out Corps corps))
            {
                return null;
            }

            IEngineer engineer = new Engineer(id, firstName, lastName, salary, corps);

            for (int i = 6; i < input.Length; i += 2)
            {
                string partName = input[i];
                int workedHours = int.Parse(input[i + 1]);

                IRepair repair = new Repair(partName, workedHours);
                engineer.Repairs.Add(repair);
            }

            return engineer;
        }

        private ISoldier GetLieutenantGeneral(int id, string firstName, 
            string lastName, decimal salary, string[] input)
        {
            ILieutenantGeneral lieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary);

            for (int i = 5; i < input.Length; i++)
            {
                int privateId = int.Parse(input[i]);
                IPrivate privateSoldier = (IPrivate)this.soldiers.FirstOrDefault(s => s.Id == privateId);

                lieutenantGeneral.Privates.Add(privateSoldier);
            }

            return lieutenantGeneral;
        }

        private ISoldier GetPrivateSoldier(int id, string firstName, string lastName, decimal salary)
        {
            IPrivate privateSoldier = new Private(id, firstName, lastName, salary);
            return privateSoldier;
        }
    }
}
