namespace AquaShop.Models.Fish
{
    public class FreshwaterFish : Fish
    {
        //Can only live in FreshwaterAquarium!
        public FreshwaterFish(string name, string species, decimal price)
            : base(name, species, price)
        {
        }
        public override void Eat()
        {
            Size *= 3;
        }
    }
}
