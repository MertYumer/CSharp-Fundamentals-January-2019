namespace P05_CountSymbols
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CountSymbols
    {
        public static void Main()
        {
            var symbols = new Dictionary<char, int>();
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

            var result = symbols.OrderBy(s => (int)s.Key);

            foreach (var symbol in result)
            {
                Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");
            }
        }
    }
}
