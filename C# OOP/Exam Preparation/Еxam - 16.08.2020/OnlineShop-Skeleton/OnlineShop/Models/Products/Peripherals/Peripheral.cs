﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products.Peripherals
{
    public abstract class Peripheral : Product, IPeripheral
    {
        protected Peripheral(int id, string manufacturer, string model, decimal price, double performance, string connectionType) 
            : base(id, manufacturer, model, price, performance)
        {
            ConnectionType = connectionType;
        }
        public string ConnectionType { get; private set; }

        public override string ToString()
        {
            return $"Overall Performance: {OverallPerformance:f2}. Price: {Price:f2} - {GetType().Name}: {Manufacturer} {Model} (Id: {Id}) Connection Type: {ConnectionType}";
        }
    }
}
