namespace P06_Wardrobe
{
    using System;
    using System.Collections.Generic;

    public class Wardrobe
    {
        public static void Main()
        {
            var wardrobe = new Dictionary<string, Dictionary<string, int>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(" -> ");
                string color = input[0];

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }

                var clothes = input[1].Split(',');

                for (int j = 0; j < clothes.Length; j++)
                {
                    string clothingItem = clothes[j];

                    if (!wardrobe[color].ContainsKey(clothingItem))
                    {
                        wardrobe[color].Add(clothingItem, 0);
                    }

                    wardrobe[color][clothingItem]++;
                }
            }

            var choosenItem = Console.ReadLine().Split();
            string choosenColor = choosenItem[0];
            string choosenClothingItem = choosenItem[1];

            foreach (var color in wardrobe)
            {
                Console.WriteLine($"{color.Key} clothes:");

                foreach (var item in color.Value)
                {
                    if (color.Key == choosenColor && choosenClothingItem == item.Key)
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value} (found!)");
                    }

                    else
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value}");
                    }
                }
            }
        }
    }
}
