using DragonArmy.Stats;

namespace DragonArmy.Dragons
{
    public abstract class Dragon
    {
        public string Name { get; private set; }
        public Damage Damage { get; private set; }
        public Health Health { get; private set; }
        public Armor Armor { get; private set; }

        protected Dragon(string name, Damage damage, 
            Health health, Armor armor)
        {
            this.Name = name;
            this.Damage = damage;
            this.Health = health;
            this.Armor = armor;
        }

        public override string ToString()
        {
            //Bazgargal -> damage: 100, health: 2500, armor: 25
            return string.Format("{0} -> {1}, {2}, {3}",
                this.Name, this.Damage, this.Health, this.Armor);
        }
    }
}
