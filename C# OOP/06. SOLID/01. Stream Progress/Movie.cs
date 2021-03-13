using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Stream_Progress
{
    public class Movie : IProgressible
    {
        public string Name { get; set; }
        public int Length { get; set; }
        public int BytesSent { get; set; }
    }
}
