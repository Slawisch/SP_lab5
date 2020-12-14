using System;
using System.Collections.Generic;

namespace SP_lab5
{
    [Serializable]
    public class Student
    {
        public List<Subject> Subjects = new List<Subject>();
        public string Name { get; set; }
        public string Surname { get; set; }

        public Student()
        {
            Name = "NONAME";
            Surname = "NOSURNAME";
        }
        public Student(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        public void AddSubject(SubjectEnum subjectEnumName)
        {
            var addableSubject = new Subject(subjectEnumName);
            Subjects.Add(addableSubject);
        }
        
        public void RemoveSubject(Subject subject)
        {
            
        }

        public void ChangeSurname(string surname)
        {
            Surname = surname;
        }
    }
}