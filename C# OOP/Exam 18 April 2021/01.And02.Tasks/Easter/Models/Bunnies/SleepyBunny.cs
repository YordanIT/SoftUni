namespace Easter.Models.Bunnies
{
    public class SleepyBunny : Bunny
    {
        private const int energyConst = 50;
        public SleepyBunny(string name)
            : base(name, energyConst)
        {
        }

        public override void Work()
        {
            energy -= 5;

            base.Work();
        }
    }
}
