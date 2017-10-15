namespace DragonArmy.Stats
{
    public class Armor
    {
        private const double DefaultValue = 10;

        public double Value { get; private set; }

        private Armor(double value)
        {
            this.Value = value;
        }

        public override string ToString()
        {
            return $"armor: {this.Value}";
        }

        public static Armor Create(string armorInfo)
        {
            var armorValue = armorInfo.Equals("null")
                ? DefaultValue
                : double.Parse(armorInfo);

            return new Armor(armorValue);
        }
    }
}
