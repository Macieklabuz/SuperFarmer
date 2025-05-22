using System.Collections.Generic;
using UnityEngine;

namespace Code
{
    public static class BreedingLogic
    {
        public static void ApplyDiceResults(Player player, AnimalType result1, AnimalType result2)
        {
            Herd herd = player.Herd;
            
            var rolledTypes = new HashSet<AnimalType> { result1, result2 };

            foreach (var type in rolledTypes)
            {
                int baseCount = herd.GetCount(type);
                int rolledCount = CountOccurrences(type, result1, result2);
                int totalCount = baseCount + rolledCount;
                int pairs = totalCount / 2;
                Debug.Log(baseCount + "/" + rolledCount + "/" + totalCount);
                
                if (pairs > 0)
                {
                    int addable = AnimalLimitManager.Instance.GetAddableCount(type, pairs);
                    if (addable > 0)
                    {
                        herd.AddAnimal(type, addable);
                        Debug.Log($"Rozmnożenie: +{addable} {type} (z {baseCount} + {rolledCount} = {totalCount})");
                    }
                }
            }
        }

        private static int CountOccurrences(AnimalType type, AnimalType result1, AnimalType result2)
        {
            int count = 0;
            if (result1 == type) count++;
            if (result2 == type) count++;
            return count;
        }
    }
}