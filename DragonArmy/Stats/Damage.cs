namespace DragonArmy.Stats
{
    public class Damage
    {
        private const double DefaultValue = 45;

        public double Value { get; private set; }

        private Damage(double value)
        {
            this.Value = value;
        }

        public override string ToString()
        {
            return string.Format("damage: {0}", this.Value);
        }

        public static Damage Create(string damageInfo)
        {
            var damageValue = damageInfo.Equals("null")
                ? DefaultValue
                : double.Parse(damageInfo);

            return new Damage(damageValue);
        }
    }
}
