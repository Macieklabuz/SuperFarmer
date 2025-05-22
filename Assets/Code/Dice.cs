using UnityEngine;

namespace Code
{
    public class Dice
    {
        private AnimalType[] faces;

        public Dice(AnimalType[] faces)
        {
            this.faces = faces;
        }

        public AnimalType Roll()
        {
            int index = Random.Range(0, faces.Length);
            return faces[index];
        }
        
        public static Dice CreateDice1()
        {
            return new Dice(new AnimalType[]
            {
                AnimalType.Rabbit, AnimalType.Rabbit, AnimalType.Rabbit,
                AnimalType.Rabbit, AnimalType.Rabbit, AnimalType.Rabbit,
                AnimalType.Sheep, AnimalType.Sheep, AnimalType.Sheep,
                AnimalType.Pig,
                AnimalType.Cow,
                AnimalType.Wolf
            });
        }
        
        public static Dice CreateDice2()
        {
            return new Dice(new AnimalType[]
            {
                AnimalType.Sheep, AnimalType.Sheep, AnimalType.Sheep,
                AnimalType.Sheep, AnimalType.Sheep, AnimalType.Sheep,
                AnimalType.Sheep, AnimalType.Sheep,
                AnimalType.Pig, AnimalType.Pig,
                AnimalType.Horse,
                AnimalType.Fox
            });
        }
    }
}