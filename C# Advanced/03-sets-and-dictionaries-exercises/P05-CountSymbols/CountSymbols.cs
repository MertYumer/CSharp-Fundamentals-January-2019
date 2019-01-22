namespace P05_CountSymbols
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CountSymbols
    {
        public static void Main()
        {
            var symbols = new SortedDictionary<char, int>();
            var input = Console.ReadLine();

            for (int i = 0; i < input.Length; i++)
            {
                char symbol = input[i];

                if (!symbols.ContainsKey(symbol))
                {
                    symbols.Add(symbol, 0);
                }

                symbols[symbol]++;
            }

            foreach (var symbol in symbols)
            {
                Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");
            }
        }
    }
}
