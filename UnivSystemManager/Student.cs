using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnivSystemManager
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime EnrollementDate { get; set; }

        public static Student GetStudentInfoFromUser()
        {
            Console.WriteLine("Enter the first name and the last name of the student:");
            string firstName = Console.ReadLine();
            string lastName = Console.ReadLine();

            return new Student { FirstName = firstName, LastName = lastName, EnrollementDate = DateTime.Now };
        }

    }
}
