using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Eggs;
using Easter.Models.Workshops;
using Easter.Repositories;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Core
{
    public class Controller : IController
    {
        private int coloredEggs;
        private BunnyRepository bunnies = new BunnyRepository();
        private EggRepository eggs = new EggRepository();
        public string AddBunny(string bunnyType, string bunnyName)
        {
            if (bunnyType != "HappyBunny" && bunnyType != "SleepyBunny")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidBunnyType);
            }

            IBunny bunny;

            if (bunnyType == "HappyBunny")
            {
                bunny = new HappyBunny(bunnyName);
            }
            else
            {
                bunny = new SleepyBunny(bunnyName);
            }

            bunnies.Add(bunny);

            return string.Format(OutputMessages.BunnyAdded, bunnyType, bunnyName);
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            var bunny = bunnies.FindByName(bunnyName);

            if (bunny == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentBunny);
            }

            var dye = new Dye(power);
            bunny.AddDye(dye);

            return string.Format(OutputMessages.DyeAdded, power, bunny.Name);
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            var egg = new Egg(eggName, energyRequired);
            eggs.Add(egg);

            return string.Format(OutputMessages.EggAdded, eggName);
        }

        public string ColorEgg(string eggName)
        {
            List<IBunny> readyBunnies = bunnies.Models.Where(x => x.Energy >= 50).OrderByDescending(x => x.Energy).ToList();

            if (readyBunnies.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.BunniesNotReady);
            }

            var egg = eggs.FindByName(eggName);
            var currentBunny = readyBunnies.First();
            var workshop = new Workshop();
            

            while (true)
            {
                workshop.Color(egg, currentBunny);

                if (currentBunny.Energy == 0)
                {
                    readyBunnies.Remove(currentBunny);
                    currentBunny = readyBunnies.FirstOrDefault();

                    bunnies.Remove(currentBunny);
                }

                if (currentBunny.Dyes.Count == 0)
                {
                    readyBunnies.Remove(currentBunny);
                    currentBunny = readyBunnies.FirstOrDefault();
                }

                if (readyBunnies.Count == 0)
                {
                    return string.Format(OutputMessages.EggIsNotDone, eggName);
                }

                if (egg.IsDone())
                {
                    coloredEggs++;
                    return string.Format(OutputMessages.EggIsDone, eggName);
                }               
            }
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{coloredEggs} eggs are done!");

            foreach (var bunny in bunnies.Models)
            {
                sb.AppendLine("Bunnies info:");
                sb.AppendLine($"Name: {bunny.Name}");
                sb.AppendLine($"Energy: {bunny.Energy}");
                sb.AppendLine($"Dyes: {bunny.Dyes.Count} not finished");
            }

            return sb.ToString().Trim();
        }
    }
}
