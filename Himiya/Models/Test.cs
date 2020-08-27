using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Himiya.Models
{
    public class Test
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public int QuestsCount { get; set; }
        public double PriceForQuest { get; set; }

        
        public int GroupId { get; set; }
        public Group Group { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
    }
}