namespace DragonArmy.Stats
{
    public class Health
    {
        private const double DefaultValue = 250;

        public double Value { get; set; }

        private Health(double value)
        {
            this.Value = value;
        }

        public override string ToString()
        {
            return string.Format("health: {0}", this.Value);
        }

        public static Health Create(string healthInfo)
        {
            var healthValue = healthInfo.Equals("null")
                ? DefaultValue
                : double.Parse(healthInfo);

            return new Health(healthValue);
        }
    }
}
