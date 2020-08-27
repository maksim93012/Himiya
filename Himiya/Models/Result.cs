using System;

namespace Himiya.Models
{
    public class Result
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Test { get; set; }
        public string Group { get; set; }

        public string DateTime { get; set; }
        public int Grade { get; set; }
    }
}