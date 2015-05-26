using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace FunctionalPrograming
{
    class FunctionalPrograming
    {
        static void Main()
        {
            /// Problem 1. Create a class Student with properties FirstName, LastName, Age, FacultyNumber, Phone, Email, Marks 
            /// (IList<int>), GroupNumber. Create a List<Student> with sample students. These students will be used for the next few tasks.
            List<Student> students = new List<Student>();
            students.Add(new Student("Ivan", "Petrov", 25, 123456789, "029720056", "vankata@abv.bg", new List<int> { 6, 5, 5, 6, 4 }, 1));
            students.Add(new Student("Petar", "Ivanov", 24, 234569871, "+359877956852", "pesho@gmail.com", new List<int> { 4, 4, 2, 3, 4 }, 2));
            students.Add(new Student("Maria", "Georgieva", 20, 395514258, "+359890369741", "marcheto95@mail.bg", new List<int> { 6, 6, 6, 6, 6 }, 3));
            students.Add(new Student("Aleksandar", "Aleksandrov", 23, 259753654, "+359883456987", "bigboss@outlook.com", new List<int> { 6, 6, 6, 6, 5 }, 2));
            students.Add(new Student("Petruna", "Karaslavova", 19, 167953247, "+359888777666", "sexy.pepi@abv.bg", new List<int> { 4, 2, 3, 4, 2 }, 1));
            students.Add(new Student("Dimitrinka", "Dimitrova", 17, 367414123, "+359 2 926 32 02", "didka@yahoo.com", new List<int> { 6, 6, 5, 6, 5 }, 3));

            /// Problem 2. Print all students from group number 2. Use a LINQ query. Order the students by FirstName.
            Console.WriteLine("Problem 2.");
            var studentsFromGroup2 =
                from student in students
                where student.GroupNumber == 2
                orderby student.FirstName ascending
                select student;

            foreach (var student in studentsFromGroup2)
            {
                Console.WriteLine("Group {0}: Name {1} {2}", student.GroupNumber, student.FirstName, student.LastName);
            }
            Console.WriteLine();

            /// Problem 3. Print all students whose first name is before their last name alphabetically. Use a LINQ query.
            Console.WriteLine("Problem 3.");
            var firstBeforeSecond =
                from student in students
                where student.FirstName.CompareTo(student.LastName) < 0
                select student;

            foreach (var student in firstBeforeSecond)
            {
                Console.WriteLine("Name: {0} {1}", student.FirstName, student.LastName);
            }
            Console.WriteLine();

            /// Problem 4. Write a LINQ query that finds the first name and last name of all students with age between 18 and 24. 
            /// The query should return only the first name, last name and age.
            Console.WriteLine("Problem 4.");
            var groupByAge =
                from student in students
                where student.Age > 18 && student.Age < 24
                select new { student.FirstName, student.LastName, student.Age };

            foreach (var student in groupByAge)
            {
                Console.WriteLine("Name: {0} {1} - Age: {2}", student.FirstName, student.LastName, student.Age);
            }
            Console.WriteLine();

            /// Problem 5. Using the extension methods OrderBy() and ThenBy() with lambda expressions sort the students by first name and last name 
            /// in descending order. Rewrite the same with LINQ query syntax.
            Console.WriteLine("Problem 5.");
            Console.WriteLine("Lambda expressions:");
            List<Student> orderedStudentsLambda = students.OrderByDescending(student => student.FirstName).ThenByDescending(student => student.LastName).ToList();
            foreach (Student student in orderedStudentsLambda)
            {
                Console.WriteLine("Name: {0} {1}", student.FirstName, student.LastName);
            }
            Console.WriteLine();
            Console.WriteLine("LINQ query:");
            var orderedStudentsLINQ =
                from student in students
                orderby student.FirstName descending, student.LastName descending
                select student;
            foreach (var student in orderedStudentsLINQ)
            {
                Console.WriteLine("Name: {0} {1}", student.FirstName, student.LastName);
            }
            Console.WriteLine();

            /// Problem 6. Print all students that have email @abv.bg. Use LINQ
            Console.WriteLine("Problem 6.");
            var abvMails =
                from student in students
                where Regex.IsMatch(student.Email, @"[-0-9a-zA-Z.+_]+@abv.bg", RegexOptions.IgnoreCase)
                select student;
            foreach (var student in abvMails)
            {
                Console.WriteLine("Name: {0} {1} - Email: {2}", student.FirstName, student.LastName, student.Email);
            }
            Console.WriteLine();

            /// Problem 7. Print all students with phones in Sofia (starting with 02 / +3592 / +359 2). Use LINQ.
            Console.WriteLine("Problem 7.");
            var sofiaPhones =
                from student in students
                where Regex.IsMatch(student.Phone, @"^\(?(\+359)?[\s]?[0]?(2)")
                select student;
            foreach (var student in sofiaPhones)
            {
                Console.WriteLine("Name: {0} {1} - Phone: {2}", student.FirstName, student.LastName, student.Phone);
            }
            Console.WriteLine();

            /// Problem 8. Print all students that have at least one mark Excellent (6). Using LINQ first select them into a new anonymous class that holds { FullName + Marks}.
            Console.WriteLine("Problem 8.");
            var studentsWithExcelent = students.Where(student => student.Marks.Contains(6)).Select(student => new {student.FirstName, student.LastName, student.Marks});
            foreach (var student in studentsWithExcelent)
            {
                Console.WriteLine("Name: {0} {1} - Marks - {2}", student.FirstName, student.LastName,string.Join(", ", student.Marks));
            }
            Console.WriteLine();

            /// Problem 9. Write a similar program to the previous one to extract the students with exactly two marks "2". Use extension methods.
            Console.WriteLine("Problem 9.");
            var weakStudent = students.Where(student => student.Marks.Count(mark => mark == 2)==2).Select(student => new { student.FirstName, student.LastName, student.Marks });
            foreach (var student in weakStudent)
            {
                Console.WriteLine("Name: {0} {1} - Marks - {2}", student.FirstName, student.LastName, string.Join(", ", student.Marks));
            }
            Console.WriteLine();

            /// Problem 10. Extract and print the Marks of the students that enrolled in 2014 (the students from 2014 have 14 as their 5-th and 6-th 
            /// digit in the FacultyNumber).
            Console.WriteLine("Problem 10.");
            var enrolled2014 = students.Where(student => Regex.IsMatch(student.FacultyNumber.ToString(), @"\d{4}14\d{3}")).Select(student => new {student.FirstName, student.LastName, student.Marks});
            foreach (var student in enrolled2014)
            {
                Console.WriteLine("Name: {0} {1} - Marks - {2}", student.FirstName, student.LastName, string.Join(", ", student.Marks));
            }
            Console.WriteLine();
        }
    }
}
