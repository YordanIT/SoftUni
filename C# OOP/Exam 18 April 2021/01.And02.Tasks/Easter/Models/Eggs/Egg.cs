using Easter.Models.Eggs.Contracts;
using Easter.Utilities.Messages;
using System;

namespace Easter.Models.Eggs
{
    public class Egg : IEgg
    {
        private string _name;
        private int _energyRequired;
        public Egg(string name, int energyRequired)
        {
            Name = name;
            EnergyRequired = energyRequired;
        }
        public string Name
        {
            get => _name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidEggName);
                }

                _name = value;
            }
        }

        public int EnergyRequired
        {
            get => _energyRequired;
            private set
            {
                if (value < 0)
                {
                    _energyRequired = 0;
                }
                else
                {
                    _energyRequired = value;
                }
            }
        }

        public void GetColored()
        {
            if (_energyRequired - 10 < 0)
            {
                _energyRequired = 0;
            }
            else
            {
                _energyRequired -= 10;
            }
        }

        public bool IsDone()
        {
            if (EnergyRequired == 0)
            {
                return true;
            }

            return false;
        }
    }
}
