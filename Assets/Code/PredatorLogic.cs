using UnityEngine;

namespace Code
{
    public static class PredatorLogic
    {
        public static void HandlePredators(Player player, AnimalType result1, AnimalType result2)
        {
            bool foxRolled = result1 == AnimalType.Fox || result2 == AnimalType.Fox;
            bool wolfRolled = result1 == AnimalType.Wolf || result2 == AnimalType.Wolf;

            Herd herd = player.Herd;

            // LIS
            if (foxRolled)
            {
                if (herd.GetCount(AnimalType.SmallDog) > 0)
                {
                    herd.RemoveAnimal(AnimalType.SmallDog);
                    Debug.Log("🦊 Mały pies ochronił króliki przed lisem.");
                }
                else
                {
                    int rabbits = herd.GetCount(AnimalType.Rabbit);
                    if (rabbits > 1)
                    {
                        herd.SetAnimal(AnimalType.Rabbit, 1);
                        Debug.Log("🦊 Lis zjadł wszystkie króliki oprócz jednego.");
                    }
                }
            }

            // WILK
            if (wolfRolled)
            {
                if (herd.GetCount(AnimalType.BigDog) > 0)
                {
                    herd.RemoveAnimal(AnimalType.BigDog);
                    Debug.Log("🐺 Duży pies ochronił stado przed wilkiem.");
                }
                else
                {
                    foreach (var type in new[] { AnimalType.Sheep, AnimalType.Pig, AnimalType.Cow })
                    {
                        if (herd.GetCount(type) > 0)
                        {
                            herd.SetAnimal(type, 0);
                        }
                    }
                    Debug.Log("🐺 Wilk zjadł wszystkie owce, świnie i krowy.");
                }
            }
        }
    }
}