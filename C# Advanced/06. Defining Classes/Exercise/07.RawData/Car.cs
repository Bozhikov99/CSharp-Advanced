using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        public string Model { get; set; }
        public Engine CarEngine { get; set; }
        public Tire[] Tires { get; set; } = new Tire[4];
        public Cargo Cargo { get; set; }
        //{model} {engineSpeed} {enginePower} {cargoWeight} {cargoType} {tire1Pressure} {tire1Age} {tire2Pressure} {tire2Age} {tire3Pressure} {tire3Age} {tire4Pressure} {tire4Age}"
        public Car(string model, Engine engine, Cargo cargo, 
            Tire[] tires)
        {
            Model = model;
            CarEngine = engine;
            Cargo = cargo;
            Tires = tires;
        }
    }
}
