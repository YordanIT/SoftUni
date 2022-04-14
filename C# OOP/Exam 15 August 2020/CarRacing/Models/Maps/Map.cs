using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return OutputMessages.RaceCannotBeCompleted;
            }
            else if (!racerOne.IsAvailable())
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);
            }
            else if (!racerTwo.IsAvailable())
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
            }
            else
            {
                double racingBehaviorMultiplierOne = racerOne.RacingBehavior == "strict" ? 1.2 : 1.1;
                double racingBehaviorMultiplierTwo = racerTwo.RacingBehavior == "strict" ? 1.2 : 1.1;

                double chanceOfWinningOne = racerOne.Car.HorsePower * racerOne.DrivingExperience * racingBehaviorMultiplierOne;
                double chanceOfWinningtwo = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * racingBehaviorMultiplierTwo;

                racerOne.Race();
                racerTwo.Race();

                if (chanceOfWinningOne > chanceOfWinningtwo)
                {
                    return string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerOne.Username);
                }
                else
                {
                    return string.Format(OutputMessages.RacerWinsRace, racerTwo.Username, racerOne.Username, racerTwo.Username);
                }
            }

        }
    }
}
