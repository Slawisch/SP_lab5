using System.Collections.Generic;

namespace SP_lab5
{
    public class Student
    {
        public List<Subject> Subjects = new List<Subject>();
        public string Name { get; set; }
        public string Surname { get; set; }

        public Student(string name = "NONAME", string surname = "NOSURNAME")
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