using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public abstract class Car : ICar
    {

        private const int modelLength = 4;
        private int minHorsePower;
        private int maxHorsePower;
        private string model;
        private int horsePower;

        protected Car(
            string model,
            int horsePower,
            double cubicCentimeters,
            int minHorsePower,
            int maxHorsePower)        //string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower
        {
            Model = model;
            HorsePower = horsePower;
            CubicCentimeters = cubicCentimeters;
            this.minHorsePower = minHorsePower;
            this.maxHorsePower = maxHorsePower;
        }

        public string Model
        {
            get => model;
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < modelLength)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidModel, value, modelLength));
                }

                model = value;
            }
        }

        public int HorsePower
        {
            get => horsePower;
            private set
            {
                if (value < minHorsePower || value > maxHorsePower)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, value));
                }

                horsePower = value;
            }
        }

        public double CubicCentimeters { get; private set; }

        public double CalculateRacePoints(int laps) => CubicCentimeters / HorsePower * laps;
    }
}
