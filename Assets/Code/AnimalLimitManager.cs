using System.Collections.Generic;
using UnityEngine;

namespace Code
{
    public class AnimalLimitManager : MonoBehaviour
    {
        public static AnimalLimitManager Instance { get; private set; }

        private Dictionary<AnimalType, int> maxLimits = new Dictionary<AnimalType, int>
        {
            { AnimalType.Rabbit, 60 },
            { AnimalType.Sheep, 24 },
            { AnimalType.Pig, 20 },
            { AnimalType.Cow, 12 },
            { AnimalType.Horse, 6 },
            { AnimalType.SmallDog, 4 },
            { AnimalType.BigDog, 2 },
        };

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
        }

        public bool CanAddAnimal(AnimalType type, int amount)
        {
            int totalOwned = GetTotalOwnedOf(type);
            return totalOwned + amount <= maxLimits[type];
        }

        public int GetAddableCount(AnimalType type, int desiredAmount)
        {
            int totalOwned = GetTotalOwnedOf(type);
            int maxAvailable = maxLimits[type] - totalOwned;
            return Mathf.Clamp(maxAvailable, 0, desiredAmount);
        }

        private int GetTotalOwnedOf(AnimalType type)
        {
            int total = 0;
            foreach (var player in PlayerManager.Instance.Players)
            {
                total += player.Herd.GetCount(type);
            }
            return total;
        }
    }
}