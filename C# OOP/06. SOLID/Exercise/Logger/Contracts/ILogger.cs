﻿using Logger.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    public interface ILogger
    {
        void Warning(string date, string message);
        void Info(string date, string message);
        void Fatal(string date, string message);
        void Critical(string date, string message);
        void Error(string date, string message);
    }
}
