using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ViewDemo.Models;

namespace ViewDemo.Controllers
{
    public class StudentController : Controller
    {
        private static List<Student> studentList = new List<Student>()
        {
            new Student { Id = 1, Name = "Raj",   Email = "raj@gmail.com",   Age = 20, Gender = "Male",   Course = "IT",  IsActive = true  },
            new Student { Id = 2, Name = "Priya", Email = "priya@gmail.com", Age = 22, Gender = "Female", Course = "BCA", IsActive = true  },
            new Student { Id = 3, Name = "Amit",  Email = "amit@gmail.com",  Age = 21, Gender = "Male",   Course = "CE",  IsActive = false },
            new Student { Id = 4, Name = "Ayush",  Email = "ayush@gmail.com",  Age = 23, Gender = "Male",   Course = "CE",  IsActive = false }
        };

        private static int GetNextId()
        {
            return studentList.Count > 0 ? studentList.Max(s => s.Id) : 1;
        }

        [HttpGet]
        public IActionResult GetAllStudentList()
        {
            return View(studentList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                student.Id = GetNextId();   
                studentList.Add(student);     
                return RedirectToAction("GetAllStudentList");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(Int32 Id)
        {
            Student student = studentList.FirstOrDefault(s => s.Id == Id);
            if(student == null)
                return NotFound();
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Int32 Id, Student LatestStudent)
        {
            if (ModelState.IsValid)
            {
                Student OldStudent = studentList.FirstOrDefault(s => s.Id == Id);

                if(OldStudent == null)
                    return NotFound();

                OldStudent.Name = LatestStudent.Name;
                OldStudent.Email = LatestStudent.Email;
                OldStudent.Age = LatestStudent.Age;
                OldStudent.Gender = LatestStudent.Gender;
                OldStudent.Course = LatestStudent.Course;
                OldStudent.IsActive = LatestStudent.IsActive;

                return RedirectToAction("GetAllStudentList");
            }
            return View(LatestStudent);
        }

        public IActionResult Details(int id)
        {
            var student = studentList.FirstOrDefault(s => s.Id == id);
            if (student == null) return NotFound();
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = studentList.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                studentList.Remove(student);
            }
            return RedirectToAction("GetAllStudentList");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var student = studentList.FirstOrDefault(s => s.Id == id);
            if (student == null) return NotFound();
            return View(student);
        }


        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.CourseList = new SelectList(new List<string>
            {
                "IOT", "IT", "CE", "BCA", "MCA", "CHE"
            });

            return View();
        }
        [HttpPost]
        public IActionResult Register(Student Student)
        {
            if (ModelState.IsValid)
            {
                return View("ShowStudent", Student);
            }

            ViewBag.CourseList = new SelectList(new List<string>
            {
                "IOT", "IT", "CE", "BCA", "MCA", "CHE"
            });

            return View(Student);

        }

    }
}
