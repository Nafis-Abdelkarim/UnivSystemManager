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
                Console.WriteLine("1-Insert a student 2-Insert a list of student 3-Show the list of student");
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

                }
            }
            using (var context = new StudentDbContext())
            {
                //Seeding the students to the data base
                //context.Database.EnsureCreated();
                //var student = new List<Student>
                //{
                //   new Student
                //   {
                //        FirstName = "John",
                //        LastName = "Doe",
                //        EnrollementDate = DateTime.Now
                //   },
                //   new Student 
                //   {
                //       FirstName = "Alice",
                //       LastName = "Smith",
                //       EnrollementDate = DateTime.Now
                //   }, 
                //   new Student
                //   {
                //       FirstName = "Bob",
                //       LastName = "Boo",
                //       EnrollementDate = DateTime.Now
                //   }
                //};

                //context.Students.AddRange(student);
                //context.SaveChanges();


                

                // Reading all students from the database
                var students = context.Students.ToList();

                Console.WriteLine("List of Students:");
                foreach(var std in students)
                {
                    Console.WriteLine($"ID: {std.StudentId}, Name: {std.FirstName}, LastName: {std.LastName}, Enrollmed: {std.EnrollementDate}");   
                }

                Console.ReadKey();
            }
        }
    }
}