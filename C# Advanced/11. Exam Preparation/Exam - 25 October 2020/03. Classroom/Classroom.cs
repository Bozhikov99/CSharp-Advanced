using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        public Classroom(int capacity)
        {
            Capacity = capacity;
            students = new List<Student>(capacity);
        }
        private List<Student> students;
        public int Capacity { get; }
        public int Count { get { return students.Count(); } }

        public string RegisterStudent(Student newStudent)
        {
            if (Capacity > Count)
            {
                students.Add(newStudent);
                return $"Added student {newStudent.FirstName} {newStudent.LastName}";
            }
            else
            {
                return "No seats in the classroom";
            }
        }

        public string DismissStudent(string firstName, string lastName)
        {
            //Dismissed student {firstName} {lastName}
            //Student not found


            if (students.Any(x => x.FirstName == firstName && x.LastName ==lastName))
            {
                students.Remove(students.Where(x => x.FirstName == firstName && x.LastName == lastName).First());
                return $"Dismissed student {firstName} {lastName}";
            }
            else
            {
                return "Student not found";
            }
        }

        public string GetSubjectInfo(string subject)
        {
            List<Student> currentSubject = students.Where(s => s.Subject == subject).ToList();
            if (currentSubject.Count == 0)
            {
                return "No students enrolled for the subject";
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Subject: {subject}");
                sb.AppendLine("Students: ");
                foreach (Student s in currentSubject)
                {
                    sb.AppendLine($"{s.FirstName} {s.LastName}");
                }
                return sb.ToString();
            }
        }

        public int GetStudentsCount()
        {
            return Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            return students.First(x => x.FirstName == firstName && x.LastName == lastName);
        }
    }
}

