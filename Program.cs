using System;
using System.Collections.Generic;

namespace ConsoleApp6
{
    class Student
    {
        

        public string Name { get; set; }
        public Dictionary<string, int> TimeTaken { get; set; }
     
        public Student(string name , int time  )
        {
            this.Name = name;
            TimeTaken = new Dictionary<string, int>(); 
        }
        public void AddTimeTaken(string timeTaken, int time)
        {
            TimeTaken[timeTaken] = time;
        }

        public override string ToString()
        {
            string result = Name + ": ";
            foreach (KeyValuePair<string, int> exerciseTime in TimeTaken)
            {
                result += exerciseTime.Key + " (" + exerciseTime.Value + " seconds), ";
            }
            return result;
        }
    }
   

    class Program
    {
        static void Main(string[] args)
        {
            Playground gina = new Playground();
            gina.AddActivity(new Activity("Pullup"));
            gina.AddActivity(new Activity("Push-ups"));
            gina.AddActivity(new Activity("Run"));

            gina.AddStudent(new Student("Alice",0));
            gina.AddStudent(new Student("Bob",0));
            gina.AddStudent(new Student("Charlie",0));

            gina.AddTimeForActivity("Alice", "Pullup", 10);
            gina.AddTimeForActivity("Alice", "Push-ups", 20);
            gina.AddTimeForActivity("Alice", "Run", 15);
            gina.AddTimeForActivity("Bob", "Pullup", 12);
            gina.AddTimeForActivity("Bob", "Push-ups", 18);
            gina.AddTimeForActivity("Bob", "Run", 13);
            gina.AddTimeForActivity("Charlie", "Pullup", 8);
            gina.AddTimeForActivity("Charlie", "Push-ups", 22);
            gina.AddTimeForActivity("Charlie", "Run", 16);

            Console.WriteLine("Fastest students for each exercise:");
            foreach (Activity activity in gina.GetActivities())
            {
                Student fastestStudent = gina.GetFastestStudentForActivity(activity.name);
                Console.WriteLine("{0}: {1} ({2} seconds)", activity.name, fastestStudent.Name);
            }

        }
    }   
}
