using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Drivers.Entities
{
    public class Driver : IDriver
    {

        private const int minNameLength = 5;
        private string name;

        public Driver(string name)
        {
            Name = name;
            NumberOfWins = 0;
            CanParticipate = false;
            Car = null;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (value.Length < minNameLength)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, value, minNameLength));
                }

                name = value;
            }
        }

        public ICar Car { get; private set; }

        public int NumberOfWins
        {
            get;
            private set;
        }

        public bool CanParticipate { get; private set; }

        public void AddCar(ICar car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(ExceptionMessages.CarInvalid);
            }

            CanParticipate = true;
            Car = car;
        }

        public void WinRace()
        {
            NumberOfWins++;
        }
    }
}
