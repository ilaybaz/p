using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApp6
{
    class Playground
    {
        private List<Activity> exercises;
        private List<Student> students = new List<Student>();
        public Playground()
        {
            exercises = new List<Activity>();
        }

        public void CreateActivity(string name)
        {
            exercises.Add(new Activity(name));
        }
        public void AddStudent(Student student)
        {
            this.students.Add(student);

        }

        public Activity GetActivity(string name)
        {
                foreach (Activity activity in this.exercises)
                {
                if (activity.name == name)
                {
                    return activity;
                }
            }
            return null;
        }
        public List<Activity> GetActivities()
        {
            return this.exercises;
        }
        private Student GetStudent(string name)
        {
            foreach (Student student in students)
            {
                if (student.Name == name)
                {
                    return student;
                }
            }
            return null;
        }

        public List<Student> GetStudentsByActivity(string exerciseName)
        {
            foreach (Activity exercise in exercises)
            {
                if (exercise.name == exerciseName)
                {
                    List<Student> students = new List<Student>();
                    foreach (Student student in exercise.students)
                    {
                        students.Add(student);
                    }
                    return students;
                }
            }
            return null;
        }

        public List<Activity> GetActivitiesByStudent(string studentName)
        {
            List<Activity> studentExercises = new List<Activity>();
            foreach (Activity exercise in exercises)
            {
                foreach (Student student in exercise.students)
                {
                    if (student.Name == studentName)
                    {
                        studentExercises.Add(exercise);
                        break;
                    }
                }
            }
            return studentExercises;
        }
        public void AddActivity(Activity exercise)
        {
            exercises.Add(exercise);
        }
        public void AddStudentToExercise(string exerciseName, Student student)
        {
            foreach (Activity exercise in exercises)
            {
                if (exercise.name == exerciseName)
                {
                    exercise.AddStudent(student);
                    break;
                }
            }
        }
        public Student GetFastestStudentForActivity(string name)
        {
            Activity exercise = this.GetActivity(name);
            if (exercise == null)
            {
                return null;
            }

            Student fastestStudent = null;
            int fastestTime = int.MaxValue;

            foreach (Student student in exercise.students)
            {
                if (student.TimeTaken.ContainsKey(name) && student.TimeTaken[name] < fastestTime)
                {
                    fastestStudent = student;
                    fastestTime = student.TimeTaken[name];
                }
            }

            return fastestStudent;
        }
        public List<Student> GetTopNStudentsForExercise(string name, int n)
        {
            Activity exercise = this.GetActivity(name);
            if (exercise == null)
            {
                return null;
            }

            List<Student> topStudents = new List<Student>();
            SortedDictionary<int, List<Student>> timeToStudents = new SortedDictionary<int, List<Student>>();

            foreach (Student student in exercise.students)
            {
                if (student.TimeTaken.ContainsKey(name))
                {
                    int time = student.TimeTaken[name];
                    if (!timeToStudents.ContainsKey(time))
                    {
                        timeToStudents[time] = new List<Student>();
                    }
                    timeToStudents[time].Add(student);
                }
            }

            foreach (KeyValuePair<int, List<Student>> pair in timeToStudents)
            {
                foreach (Student student in pair.Value)
                {
                    topStudents.Add(student);
                    if (topStudents.Count == n)
                    {
                        return topStudents;
                    }
                }
            }

            return topStudents;
        }
        public void AddTimeForActivity(string studentName, string exerciseName, int time)
        {
            Activity exercise = GetActivity(exerciseName);
            if (exercise == null)
            {
                Console.WriteLine($"Exercise '{exerciseName}' does not exist in the playground.");
                return;
            }

            Student student = GetStudent(studentName);
            if (student == null)
            {
                Console.WriteLine($"Student '{studentName}' does not exist in the playground.");
                return;
            }

            exercise.AddTimeForStudent(studentName, time);
        }
        


    }

}
