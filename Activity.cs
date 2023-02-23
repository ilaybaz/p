using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class Activity
    {
            public string name { get; set; }
            public List<Student> students { get; set; }
            public Dictionary<string, int> times = new Dictionary<string, int>();

        public Activity(string name)
        {
            this.name = name;
            this.students = new List<Student>();
        }
public void AddStudent(Student student)
        {
            
            this.students.Add(student);
        }
        public void AddTimeForStudent(string studentName, int time)
        {
            if (times.ContainsKey(studentName))
            {
                times[studentName] = time;
            }
            else
            {
                times.Add(studentName, time);
            }
        }
        
    }
}

