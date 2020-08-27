namespace Himiya.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Quest { get; set; }
        public string Answer { get; set; }
        public bool IgnoreCase { get; set; }

        public int TestId { get; set; }
        public Test Test { get; set; }
    }
}