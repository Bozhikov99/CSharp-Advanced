using System;
using System.Collections.Generic;
using System.Linq;

namespace SumOfCoins
{
    public class SumOfCoins
    {
        public static void Main(string[] args)
        {
            var availableCoins = new[] { 1, 2, 5, 10, 20, 50 };
            var targetSum = 923;

            var selectedCoins = ChooseCoins(availableCoins, targetSum);

            Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");
            foreach (var selectedCoin in selectedCoins)
            {
                Console.WriteLine($"{selectedCoin.Value} coin(s) with value {selectedCoin.Key}");
            }
        }

        public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
        {
            var coinsDict = new Dictionary<int, int>();
            int currentSum = 0;
            coins = coins.OrderByDescending(c => c).ToList();

            for (int i = 0; i < coins.Count; i++)
            {
                int currentCoin = coins[i];

                if (currentCoin + currentSum > targetSum)
                {
                    continue;
                }

                coinsDict[currentCoin] = 0;
                coinsDict[currentCoin] += (targetSum - currentSum) / currentCoin;
                currentSum += coinsDict[currentCoin] * currentCoin;

                if (currentSum == targetSum)
                {
                    coins[currentCoin]++;
                    break;
                }
            }

            return coinsDict;
        }
    }
}
