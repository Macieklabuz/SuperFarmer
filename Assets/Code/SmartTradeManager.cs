using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Code
{
    public static class SmartTradeManager
    {
        public struct ExchangeRule
        {
            public AnimalType From;
            public AnimalType To;
            public int FromCount; // ile FROM
            public int ToCount;   // ile TO (standardowo 1)
        }
        
        private static readonly Dictionary<AnimalType, int> rabbitValues = new()
        {
            { AnimalType.Rabbit, 1 },
            { AnimalType.Sheep, 6 },
            { AnimalType.Pig, 12 },
            { AnimalType.Cow, 36 },
            { AnimalType.Horse, 72 },
            { AnimalType.SmallDog, 6 },
            { AnimalType.BigDog, 36 }
        };
        
        private static readonly List<ExchangeRule> exchangeRules = new()
        {
            new() { From = AnimalType.Sheep, To = AnimalType.Rabbit, FromCount = 1, ToCount = 6 },
            new() { From = AnimalType.Pig, To = AnimalType.Sheep, FromCount = 1, ToCount = 2 },
            new() { From = AnimalType.Cow, To = AnimalType.Pig, FromCount = 1, ToCount = 3 },
            new() { From = AnimalType.Horse, To = AnimalType.Cow, FromCount = 1, ToCount = 2 },
            new() { From = AnimalType.SmallDog, To = AnimalType.Sheep, FromCount = 1, ToCount = 1 },
            new() { From = AnimalType.BigDog, To = AnimalType.Cow, FromCount = 1, ToCount = 1 },
            
            new() { From = AnimalType.Rabbit, To = AnimalType.Sheep, FromCount = 6, ToCount = 1 },
            new() { From = AnimalType.Sheep, To = AnimalType.Pig, FromCount = 2, ToCount = 1 },
            new() { From = AnimalType.Pig, To = AnimalType.Cow, FromCount = 3, ToCount = 1 },
            new() { From = AnimalType.Cow, To = AnimalType.Horse, FromCount = 2, ToCount = 1 },
            new() { From = AnimalType.Sheep, To = AnimalType.SmallDog, FromCount = 1, ToCount = 1 },
            new() { From = AnimalType.Cow, To = AnimalType.BigDog, FromCount = 1, ToCount = 1 },
        };

        public static bool TryExecuteExchange(Player player, AnimalType from, int fromCount, AnimalType to, int toCount)
        {
            Herd herd = player.Herd;

            int requiredValue = rabbitValues[from] * fromCount;
            int availableValue = CalculateTotalRabbitValue(herd);

            if (availableValue < requiredValue)
            {
                Debug.Log("Gracza nie stać na wymianę.");
                return false;
            }
            
            var animalsSorted = rabbitValues.OrderByDescending(kv => kv.Value).Select(kv => kv.Key).ToList();
            int remaining = requiredValue;
            Dictionary<AnimalType, int> toRemove = new();

            foreach (var animal in animalsSorted)
            {
                int count = herd.GetCount(animal);
                int value = rabbitValues[animal];

                int needed = Mathf.Min(count, remaining / value);
                if (needed > 0)
                {
                    toRemove[animal] = needed;
                    remaining -= needed * value;
                }

                if (remaining <= 0)
                    break;
            }

            if (remaining > 0)
            {
                Debug.Log("Gracz nie ma odpowiednich zwierząt do wymiany.");
                return false;
            }
            
            foreach (var kv in toRemove)
                herd.RemoveAnimal(kv.Key, kv.Value);

            herd.AddAnimal(to, toCount);
            Debug.Log($"Wymiana zakończona: {fromCount} {from} -> {toCount} {to}");
            return true;
        }

        private static int CalculateTotalRabbitValue(Herd herd)
        {
            return rabbitValues.Sum(kv => herd.GetCount(kv.Key) * kv.Value);
        }

        public static List<ExchangeRule> GetAllRules()
        {
            return exchangeRules;
        }
    }
}
