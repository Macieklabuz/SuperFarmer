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

        /// <summary>
        /// Kostka 1:
        /// 6 królików, 3 owce, 1 świnia, 1 krowa, 1 wilk
        /// </summary>
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

        /// <summary>
        /// Kostka 2:
        /// 6 owiec, 2 owce (czyli razem 8), 2 świnie, 1 koń, 1 lis
        /// </summary>
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