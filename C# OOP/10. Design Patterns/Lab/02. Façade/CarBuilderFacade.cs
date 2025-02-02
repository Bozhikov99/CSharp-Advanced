﻿using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace _02._Façade
{
    public class CarBuilderFacade
    {
        protected Car Car { get; set; }

        public CarBuilderFacade()
        {
            Car = new Car();
        }

        public Car Build() => Car;

        public CarInfoBuilder Info => new CarInfoBuilder(Car);
        public CarAddressBuilder Built => new CarAddressBuilder(Car);
    }
}
