using Playground.Models;
using System.Collections.Generic;

namespace Playground.ViewModels
{
    public class GroupJoinAndInnerJoinViewModel
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string SchoolName { get; set; }
        public string Field { get; set; }

        public List<Mark> Marks { get; set; }
    }
}
