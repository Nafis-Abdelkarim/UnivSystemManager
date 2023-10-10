using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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

        public  static Student GetStudentInfoFromUser(string firstName, string lastName)
        { 
            return new Student { FirstName = firstName, LastName = lastName, EnrollementDate = DateTime.Now };
        }
        
        public (string firstnameb, string lastname) GetInformationFromtheUser()
        {
            Console.WriteLine("Enter the FirstName Of the student");
            string? firstName = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Enter the LastName Of the student");
            string? lastName = Convert.ToString(Console.ReadLine());

            return (firstName, lastName);
        }

    }
}
