using System.Linq;

namespace UnivSystemManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to University System Manager !");

            while (true)
            {
                Console.WriteLine("Choose what you want to do:");
                Console.WriteLine("1-Insert a student 2-Insert a list of student 3-Show the list of student 4-Search for Student");
                int OpNumber = Convert.ToInt32(Console.ReadLine()); 
                var context = new StudentDbContext();
                switch (OpNumber)
                {
                    case 1:
                        //Insert a given student to the database
                        var student = Student.GetStudentInfoFromUser();
                        context.Students.Add(student);
                        context.SaveChanges();
                        Console.WriteLine($"The student added to database");
                        Console.WriteLine("The List of Students Has been added to the database.\n");
                        break;
                    case 2:
                        Console.WriteLine("How to many student you want to insert ?");
                        int NumberOfStudents = Convert.ToInt32(Console.ReadLine()); 
                        while(NumberOfStudents != 0)
                        {
                            //input
                            Console.WriteLine("Enter the FirstName Of the student");
                            string? firstName = Convert.ToString(Console.ReadLine());
                            Console.WriteLine("Enter the LastName Of the student");
                            string? lastName = Convert.ToString(Console.ReadLine());
                            //Create a new object of student
                            var studentList = new Student
                            { FirstName = firstName, LastName = lastName, EnrollementDate = DateTime.Now };
                            context.Students.Add(studentList);
                            context.SaveChanges();
                            NumberOfStudents--;
                        }
                        Console.WriteLine("The List of Students Has been added to the database.\n");
                        break;
                    case 3:
                        // Reading all students from the database
                        var students = context.Students.ToList();
                        Console.WriteLine("List of Students:");
                        foreach (var std in students)
                        {
                            Console.WriteLine($"ID: {std.StudentId}, Name: {std.FirstName}, LastName: {std.LastName}, Enrollmed: {std.EnrollementDate}");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Enter the name of student you looking for:");
                        string studentName = Convert.ToString(Console.ReadLine());
                        IQueryable<Student> studentsTable = context.Students;
                        if(!string.IsNullOrEmpty(studentName) )
                        {
                            studentsTable = studentsTable.Where(s => s.FirstName.Contains(studentName) || s.LastName.Contains(studentName));
                            List<Student> results = studentsTable.ToList();
                            if (results.Any())
                            {
                                Console.WriteLine("The Search Result is :");
                                foreach (var std in results)
                                {
                                    Console.WriteLine($"Student ID: {std.StudentId}, FirstName : {std.FirstName}, LastName : {std.LastName}");
                }
            }
                            else
            {
                                Console.WriteLine("No matching students found");
                            }
                        }
                        else
                {
                            Console.WriteLine("Please enter a student name!");
                        }
                        break;
                }

                Console.ReadKey();
            }
        }
    }
}