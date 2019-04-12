using System.Collections.Generic;

namespace Playground.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public int Age { get; set; }

        public int SchoolId { get; set; }
        public School School { get; set; }

        public List<Mark> Marks { get; set; }
    }
}
