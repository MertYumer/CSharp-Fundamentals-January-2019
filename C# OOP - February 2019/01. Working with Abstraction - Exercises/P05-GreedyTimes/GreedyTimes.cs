namespace P05_GreedyTimes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class GreedyTimes
    {
        public static void Main()
        {
            long bagCapacity = long.Parse(Console.ReadLine());
            var allTypes = new Dictionary<string, Dictionary<string, long>>();
            allTypes["Gold"] = new Dictionary<string, long>();
            allTypes["Gem"] = new Dictionary<string, long>();
            allTypes["Cash"] = new Dictionary<string, long>();
            var summedQuantity = new Dictionary<string, long>();
            summedQuantity["Gold"] = 0;
            summedQuantity["Gem"] = 0;
            summedQuantity["Cash"] = 0;

            string input = Console.ReadLine();
            MatchCollection matchedTypes = FindMatches(input);

            foreach (Match match in matchedTypes)
            {
                string item = match.Groups[1].Value;
                long quantity = long.Parse(match.Groups[2].Value);

                if (bagCapacity >= quantity)
                {
                    if (item.ToLower() == "gold")
                    {
                        AddQuantity(allTypes, item, quantity, summedQuantity, "Gold");
                    }

                    else if (item.ToLower().EndsWith("gem") && item.Length > 3)
                    {
                        if (summedQuantity["Gem"] + quantity > summedQuantity["Gold"])
                        {
                            continue;
                        }

                        AddQuantity(allTypes, item, quantity, summedQuantity, "Gem");
                    }

                    else if (item.Length == 3)
                    {
                        if (summedQuantity["Cash"] + quantity > summedQuantity["Gem"])
                        {
                            continue;
                        }

                        AddQuantity(allTypes, item, quantity, summedQuantity, "Cash");
                    }

                    bagCapacity -= quantity;
                }
            }

            PrintTypes(allTypes, summedQuantity);
        }

        public static void PrintTypes(Dictionary<string, Dictionary<string, long>> allTypes,
            Dictionary<string, long> summedQuantity)
        {
            foreach (var type in allTypes.Where(t => t.Value.Any()))
            {
                Console.WriteLine($"<{type.Key}> ${summedQuantity[type.Key]}");

                var orderedItems = allTypes[type.Key]
                    .OrderByDescending(i => i.Key)
                    .ThenBy(i => i.Value);

                foreach (var item in orderedItems)
                {
                    Console.WriteLine($"##{item.Key} - {item.Value}");
                }
            }
        }

        public static void AddQuantity(Dictionary<string, Dictionary<string, long>> allTypes,
            string item, long quantity, Dictionary<string, long> summedQuantity, string type)
        {
            if (!allTypes[type].ContainsKey(item))
            {
                allTypes[type][item] = 0;
            }

            allTypes[type][item] += quantity;
            summedQuantity[type] += quantity;
        }

        public static MatchCollection FindMatches(string input)
        {
            string pattern = @"(gold|[a-zA-Z]{3}|[a-zA-Z]+gem)[\s]+([0-9]+)";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            MatchCollection matchedTypes = regex.Matches(input);

            return matchedTypes;
        }
    }
}