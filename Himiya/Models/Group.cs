using System.Collections.Generic;

namespace Himiya.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Test> Tests { get; set; }
    }
}