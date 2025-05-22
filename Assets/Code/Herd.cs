using System.Collections.Generic;

namespace Code
{
    public class Herd
    {
        private Dictionary<AnimalType, int> animals = new Dictionary<AnimalType, int>();

        public Herd()
        {
            animals[AnimalType.Rabbit] = 1;
        }
        
        public void SetAnimal(AnimalType type, int count)
        {
            if (count <= 0)
            {
                animals.Remove(type);
            }
            else
            {
                animals[type] = count;
            }
        }
        
        public void AddAnimal(AnimalType type, int count = 1)
        {
            if (!animals.ContainsKey(type))
                animals[type] = 0;

            animals[type] += count;
        }
        
        public int GetCount(AnimalType type)
        {
            return animals.ContainsKey(type) ? animals[type] : 0;
        }
        
        public Dictionary<AnimalType, int> GetAnimalCounts()
        {
            return new Dictionary<AnimalType, int>(animals);
        }
        
        public void RemoveAnimal(AnimalType type, int count = 1)
        {
            if (!animals.ContainsKey(type))
                return;

            animals[type] -= count;
            if (animals[type] <= 0)
            {
                animals.Remove(type);
            }
        }
    }
}