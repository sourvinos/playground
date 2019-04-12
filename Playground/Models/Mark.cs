namespace Playground.Models
{
    public class Mark
    {
        public int StudentId { get; set; }
        public string SubjectName { get; set; }
        public string Score { get; set; }
        public int Order { get; set; }

        public Student Student { get; set; }
    }
}
