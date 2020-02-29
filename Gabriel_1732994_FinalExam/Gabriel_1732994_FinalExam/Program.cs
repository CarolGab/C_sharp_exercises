using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace Gabriel_1732994_FinalExam
{
    class Program
    {
        static void Main(string[] args)
        {
            var personList = new List<Person>();


            var johnDOB = new DateTime(1990,01,10);
            var lizDOB = new DateTime(1980, 01, 21);
            var claireDOB = new DateTime(2000, 01, 20);
            var albertDOB = new DateTime(2004, 05, 05);


            Person p1 = new Person("John", "Smith", johnDOB);
            Person p2 = new Person("Liz", "Brown", lizDOB);
            Person p3 = new Person("Claire", "James", claireDOB);
            Person p4 = new Person("Albert", "Green", albertDOB);

            personList.Add(p1);
            personList.Add(p2);
            personList.Add(p3);
            personList.Add(p4);

            var profdict1 = new Dictionary<int, int>();
            var profdict2 = new Dictionary<int, int>();
            var profdict3 = new Dictionary<int, int>();
            var profdict4 = new Dictionary<int, int>();

            profdict1.Add(33333, 16);
            profdict2.Add(44444, 15);
            profdict3.Add(11111, 15);
            profdict4.Add(22222, 17);

            var stephDOB = new DateTime(1994, 10, 20);
            var jamesDOB = new DateTime(1993, 04, 03);
            var gregDOB = new DateTime(1996, 09, 20);
            var lucyDOB = new DateTime(1991, 11, 19);

            var prof1 = new Professor("Stephanie, Goldman", stephDOB, profdict1);
            var prof2 = new Professor("James, Davis", jamesDOB, profdict2);
            var prof3 = new Professor("Greg, Hamilton", gregDOB, profdict3);
            var prof4 = new Professor("Lucy, Smith", lucyDOB, profdict4);

            personList.Add(prof1);
            personList.Add(prof2);
            personList.Add(prof3);
            personList.Add(prof4);

            var stud1 = new Student("Allen, Joseph, 1998/09/23, 77777, aec, Winter2018");
            var stud2 = new Student("Frank, Bower, 1994/05/12, 66666, aec, Winter2018");
            var stud3 = new Student("Selma, Nassim, 1999/08/21, 99999, aec, Winter2018");
            var stud4 = new Student("Hellen, Brown, 1992/07/12, 88888, aec, Winter2018");

            /*string clientsTextFilePath = (@"C:\Users\cg_19\Source\Repos\Gabriel_1732994_FinalExam\students.txt");
            DirectoryInfo newDirectory = new DirectoryInfo(@"C:\Users\cg_19\Source\Repos\Gabriel_1732994_FinalExam\students.txt");
            newDirectory.Create();
            string[] students =
            {
                "Allen, Joseph, 1998/09/23, 77777, aec, Winter2018",
                "Frank, Bower, 1994/05/12, 66666, aec, Winter2018",
                "Selma, Nassim, 1999/08/21, 99999, aec, Winter2018",
                "Hellen, Brown, 1992/07/12, 88888, aec, Winter2018"
            };
            DirectoryInfo currentDirectory = new DirectoryInfo(".");
            File.WriteAllLines(clientsTextFilePath, students);

            foreach (var student in File.ReadAllLines(clientsTextFilePath))
            {
                Console.WriteLine($"{student}");
            }*/
            
            personList.Add(stud1);
            personList.Add(stud2);
            personList.Add(stud3);
            personList.Add(stud4);

            foreach(var person in personList)
            {
                Console.WriteLine(person);
            }

            Console.ReadLine();
            Console.Clear();

            var profList = new List<Professor>();
            var studentList = new List<Student>();
            Array personArray = personList.ToArray();
            

            foreach (var person in personArray)
            {
                if(person is Professor)
                {
                    profList.Add((Professor)person);
                    personList.Remove((Person)person);
                }

                if(person is Student)
                {
                    studentList.Add((Student)person);
                    personList.Remove((Person)person);
                }
            }

            Console.WriteLine("The number of elements in personList is: " + personList.Count);
            Console.WriteLine("The number of elements in profList is: " + profList.Count);
            Console.WriteLine("The number of elements in studentList is: " + studentList.Count);

            Console.ReadLine();
            Console.Clear();

            foreach(var prof in profList)
            {
                if (prof.Id == 33333)
                {
                    prof.Level = 19;
                    Console.WriteLine(prof);
                }
            }

            Console.ReadLine();
            Console.Clear();

            foreach (var student in studentList)
            {
                if (student.Id == 99999)
                {
                    student.Program = "dec";
                    Console.WriteLine(student);
                }
            }

            Console.ReadLine();
            Console.Clear();

            studentList.Sort();
            profList.Sort();

            foreach(var prof in profList)
            {
                Console.WriteLine(prof);
            }

            Console.ReadLine();
            Console.Clear();

            foreach(var stud in studentList)
            {
                Console.WriteLine(stud);
            }

            Console.ReadLine();
            Console.Clear();
        }
    }

    class Person
    {
        //fields
        string firstName;
        string lastName;
        protected DateTime dob;

        //properties
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public DateTime Dob { get => dob; set => dob = value; }

        //default constructor
        public Person()
        {

        }

        //constructor that takes all parameters
        public Person(string fn, string ln, DateTime d)
        {
            this.FirstName = fn;
            this.LastName = ln;
            this.Dob = d;
        }

        //overriding the ToString method
        public override string ToString()
        {
            return $"Person: First Name = {this.FirstName} | Last Name = {this.LastName} | Date of Birth = {this.Dob}\n\n"; 
        }
    }

    class Professor : Person
    {
        //fields
        int id;
        int level;

        //properties
        public int Id { get => id; set => id = value; }
        public int Level { get => level; set => level = value; }

        //default constructor
        public Professor()
        {

        }

        //dictionary constructor
        public Professor(string s, DateTime d, Dictionary<int, int>dict)
        {
            var strArray = s.Split(',');
            this.FirstName = strArray[0];
            this.LastName = strArray[1];
            this.Dob = d;
            dict.Add(this.id, this.level);
        }
        
        public override int GetHashCode()
        {
            var hashCode = 1098242698;
            hashCode = hashCode * -1521134295 + id.GetHashCode();
            hashCode = hashCode * -1521134295 + level.GetHashCode();
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + Level.GetHashCode();
            return hashCode;
        }

        public override bool Equals(object obj)
        {
            var professor = obj as Professor;
            return professor != null &&
                   Id == professor.Id;
        }

        public override string ToString()
        {
            return $"Professor:\nID = {this.Id}\nFirst Name = {this.FirstName}\nLast Name = {this.LastName}\nDate of Birth = {this.Dob}\nLevel = {this.Level}\n\n";
        }
    }

    class Student : Person
    {
        //fields
        int id;
        string program;
        string session;

        //properties
        public int Id { get => id; set => id = value; }
        public string Program { get => program; set => program = value; }
        public string Session { get => session; set => session = value; }

        //default constructor
        public Student()
        {

        }

        //string constructor
        public Student(string s)
        {
            var strArray = s.Split(',');
            this.FirstName = strArray[0];
            this.LastName = strArray[1];
            DateTime.TryParse(strArray[2], out this.dob);
            int.TryParse(strArray[3], out this.id);
            this.Program = strArray[4];
            this.Session = strArray[5];
        }

        public override bool Equals(object obj)
        {
            var student = obj as Student;
            return student != null &&
                   Id == student.Id;
        }

        public override int GetHashCode()
        {
            return 2108858624 + Id.GetHashCode();
        }

        public override string ToString()
        {
            return $"Student:\nID = {this.Id}\nFirst Name = {this.FirstName}\nLast Name = {this.LastName}\nDate of Birth = {this.Dob}\nProgram = {this.Program}\nSession = {this.Session}\n\n";
        }
    }
}
