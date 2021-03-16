using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Stream_Progress
{
    public class Music:IProgressible
    {
        public string Artist { get; set; }
        public string Name { get; set; }
        public double Time { get; set; }
        public int Length { get; set; }
        public int BytesSent { get; set; }
    }
}
