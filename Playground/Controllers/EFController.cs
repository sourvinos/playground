using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Playground.Models;
using Playground.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Playground.Controllers
{
    public class EFController : Controller
    {
        private PlaygroundContext _context;

        public EFController(PlaygroundContext context) { _context = context; }

        // GET: EF/Index
        public IActionResult Index()
        {
            return View();
        }

        // GET: EF/One
        // Group Join and navigation field combined with a parameter
        public IActionResult One()
        {
            var q = GetAllStudents()
                .GroupJoin(GetAllMarks(),
                    o => o.Id,
                    i => i.StudentId, (student, marks) => new GroupJoinAndInnerJoinViewModel
                    {
                        StudentId = student.Id,
                        StudentName = ($"Name: {student.StudentName}"),
                        Field = (string)student.GetType().GetProperty("StudentName").GetValue(student),
                        SchoolName = GetAllSchools().Where(d => d.Id == student.SchoolId).Select(a => a.SchoolName).SingleOrDefault(),
                        Marks = marks.ToList()
                    }).ToList();

            return View("GroupJoinAndInnerJoin", q);
        }

        // GET: EF/Two
        // Select all students, find their school name and their first score
        public IActionResult Two()
        {
            var q = GetAllStudents()
                .Select(student => new StudentThumbnailViewModel
                {
                    Id = student.Id,
                    Name = student.StudentName,
                    SchoolName = GetAllSchools().Where(b => b.Id == student.SchoolId).Select(a => a.SchoolName).FirstOrDefault(),
                    FirstMark = GetAllMarks().Where(m => m.StudentId == student.Id && m.Order == 1).Select(a => a.Score).FirstOrDefault()
                }).ToList();

            return View("studentThumbnails", q);
        }

        // GET: EF/Three
        // Retrieve all the records and select (project) only one field with 'Select'
        public void Three()
        {
            IEnumerable<string> r = GetAllStudents().Select(e => e.StudentName);

            foreach (string p in r)
            {
                Console.WriteLine(p);
            }
        }

        // GET: EF/Four
        // Retrieve records and create anonymous objects
        public void Four()
        {
            var students = GetAllStudents().Select(s => new
            {
                Id = s.Id,
                SchoolName = s.School.SchoolName,
                Name = s.StudentName
            });

            foreach (var p in students)
            {
                Console.WriteLine(p.Id + " " + p.Name + " ");
            }
        }

        // GET: EF/Five/71 or EF/Five?id=71
        // Url with one parameter
        public string Five(int id)
        {
            return "Id = " + id;
        }

        // GET: EF/Six OR EF/Six?categoryId=71 OR EF/Six?pageNo=71 OR EF/Six?categoryId=12&pageNo=71
        // Url with two parameters, both optional
        public string Six(int? categoryId, int? pageNo)
        {
            int _categoryId = categoryId ?? 1;
            int _pageNo = pageNo ?? 1;

            string result = "Id = " + _categoryId + " " + "Page = " + _pageNo;

            return result;
        }

        // GET: EF/Seven
        // Inner join with one field
        public void Seven()
        {
            var students = GetAllStudents()
                .Join(GetAllSchools(),
                    o => o.SchoolId,
                    i => i.Id, (student, school) => new
                    {
                        Name = student.StudentName,
                        SchoolDescription = school.SchoolName
                    });

            foreach (var student in students)
            {
                Console.WriteLine(student.Name + " " + student.SchoolDescription);
            }
        }

        // GET: EF/Eight
        // Load all customers with identity as parameter and paging capability, find the tax office and the first address
        public async Task<IActionResult> Eight(int? identity, int? pageNo)
        {
            int _identity = identity ?? 1;
            int _pageNo = pageNo ?? 1;
            int _pageItems = 5;

            ViewData["identity"] = _identity;

            var customers = _context.Customers
                .Where(c => c.Identity == _identity)
                .OrderBy(c => c.Description)
                .Select(customer => new CustomerThumbnailViewModel
                {
                    Id = customer.Id,
                    CustomerDescription = customer.Description,
                    TaxOfficeDescription = _context.TaxOffices.Where(b => b.Id == customer.TaxOfficeId).Select(a => a.Description).FirstOrDefault(),
                    FirstAddress = _context.Addresses.Where(m => m.CustomerId == customer.Id && m.Order == 1).Select(a => a.Street).FirstOrDefault()
                });

            return View("paging", await PaginatedList<CustomerThumbnailViewModel>.CreateAsync(customers.AsNoTracking(), _pageNo, _pageItems));
        }

        // GET: EF/Nine
        // Group Join, get only one student with its marks. I am using the IEnumerable<T> instead of var students
        // I am getting the result type from the last command in the chain, that is GroupJoin.
        public IActionResult Nine(int studentId)
        {
            IEnumerable<GroupJoinAndInnerJoinViewModel> students = GetAllStudents()
                .Where(s => s.Id == studentId)
                .GroupJoin(GetAllMarks(),
                    o => o.Id,
                    i => i.StudentId, (student, marks) => new GroupJoinAndInnerJoinViewModel
                    {
                        StudentId = student.Id,
                        StudentName = student.StudentName,
                        SchoolName = GetAllSchools().Where(d => d.Id == student.SchoolId).Select(a => a.SchoolName).SingleOrDefault(),
                        Marks = marks.ToList()
                    }).ToList();

            return View("SingleRecordWithChildren", students);
        }

        // GET: EF/Ten
        // Retrieve all the records and all the fields
        // This will return a <List> of student objects and not an anonymous type
        public void Ten()
        {
            List<Student> students = GetAllStudents();

            foreach (var student in students)
            {
                Console.WriteLine(student.Id + " " + student.StudentName);
            }
        }

        // GET: EF/Eleven
        // Get all the students with their marks
        public void Eleven()
        {
            var students = GetAllStudents()
                .Select(c => new
                {
                    fullName = c.Id + " " + c.StudentName,
                    marks = GetAllMarks()
                });

            foreach (var student in students)
            {
                Console.WriteLine(student.fullName);

                foreach (var mark in student.marks)
                {
                    Console.WriteLine(mark.StudentId + " " + mark.SubjectName + " " + mark.SubjectName);
                }
            }
        }

        // GET: EF/Fourteen
        // Custom Sorting
        public void Fourteen()
        {
            var orderedPersons = CustomSort(p => p.Age);

            foreach (var p in orderedPersons)
            {
                Console.WriteLine(p.Name + " " + p.Age);
            }
        }

        public IOrderedEnumerable<Person> CustomSort<TKey>(Func<Person, TKey> selector)
        {
            var persons = GetAllPersons().OrderBy(selector);

            return persons;
        }

        // GET: EF/Fifteen
        // Custom fields
        public void Fifteen()
        {
            var students = GetAllStudents().Select(s => new { Field = (string)s.GetType().GetProperty("StudentName").GetValue(s) });

            foreach (var student in students)
            {
                Console.WriteLine(student.Field);
            }
        }

        public static List<Student> GetAllStudents()
        {
            List<Student> objStudentCollection = new List<Student> {
                new Student { Id = 104517, StudentName = "John", SchoolId = 1, Age = 22 },
                new Student { Id = 104520, StudentName = "Stella", SchoolId = 2, Age = 21 },
                new Student { Id = 104933, StudentName = "Mitsos", SchoolId = 3, Age = 20 }
            };

            return objStudentCollection;
        }

        public static List<School> GetAllSchools()
        {
            List<School> objSchoolCollection = new List<School>
            {
                new School{ Id = 1, SchoolName= "Elementary" },
                new School{ Id = 2, SchoolName= "Primary" },
                new School{ Id = 3, SchoolName = "University" }
            };

            return objSchoolCollection;
        }

        public static List<Mark> GetAllMarks()
        {
            List<Mark> objMarkCollection = new List<Mark>
            {
                new Mark{ StudentId = 104517, SubjectName = "English", Score = "85", Order = 3 },
                new Mark{ StudentId = 104517, SubjectName = "Mathematics", Score = "60", Order = 1 },
                new Mark{ StudentId = 104517, SubjectName = "English", Score = "75", Order = 2 },
                new Mark{ StudentId = 104517, SubjectName = "Optional 1", Score = "75", Order = 4 },

                new Mark{ StudentId = 104520, SubjectName = "French", Score = "75", Order = 3 },
                new Mark{ StudentId = 104520, SubjectName = "Science", Score = "60", Order = 1  },
                new Mark{ StudentId = 104520, SubjectName = "Mathematics", Score = "75", Order = 2  },
                new Mark{ StudentId = 104520, SubjectName = "Optional 1", Score = "50", Order = 4  },
                new Mark{ StudentId = 104520, SubjectName = "Astronomy", Score = "71", Order = 5  }
            };

            return objMarkCollection;
        }

        public static List<Person> GetAllPersons()
        {
            List<Person> objPersonCollection = new List<Person>
            {
                new Person { Name = "Kayes", Age = 29, JoiningDate = DateTime.Parse("2010-06-06") },
                new Person { Name = "Gibbs", Age = 34, JoiningDate = DateTime.Parse("2008-04-23") },
                new Person { Name = "Steyn", Age = 28, JoiningDate = DateTime.Parse("2011-02-17") }
            };

            return objPersonCollection;
        }
    }
}
