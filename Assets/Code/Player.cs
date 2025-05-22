namespace Code
{
    public class Player
    {
        public string Name { get; private set; }
        public Herd Herd { get; private set; }

        public Player(string name)
        {
            Name = name;
            Herd = new Herd();
        }
    }
}