using System.Collections.Generic;

/// Problem 1. Create a class Student with properties FirstName, LastName, Age, FacultyNumber, Phone, Email, Marks 
/// (IList<int>), GroupNumber. Create a List<Student> with sample students. These students will be used for the next few tasks.

namespace FunctionalPrograming
{
    class Student
    {
        private string firstName;
        private string lastName;
        private byte age;
        private ulong facultyNumber;
        private string phone;
        private string email;
        private List<int> marks;
        private int groupNumber;

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                this.firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                this.lastName = value;
            }
        }
        public byte Age
        {
            get
            {
                return this.age;
            }
            set
            {
                this.age = value;
            }
        }
        public ulong FacultyNumber
        {
            get
            {
                return this.facultyNumber;
            }
            set
            {
                this.facultyNumber = value;
            }
        }
        public string Phone
        {
            get
            {
                return this.phone;
            }
            set
            {
                this.phone = value;
            }
        }
        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                this.email = value;
            }
        }
        public List<int> Marks
        {
            get
            {
                return this.marks;
            }
            set
            {
                this.marks = value;
            }
        }
        public int GroupNumber
        {
            get
            {
                return groupNumber;
            }
            set
            {
                this.groupNumber = value;
            }
        }
        public Student(string fName, string lName, byte age, ulong fNumber, string pNumber, string eml, List<int> mks, int gNumber)
        {
            this.firstName = fName;
            this.lastName = lName;
            this.age = age;
            this.facultyNumber = fNumber;
            this.phone = pNumber;
            this.email = eml;
            this.marks = mks;
            this.groupNumber = gNumber;


    }
    }
}
