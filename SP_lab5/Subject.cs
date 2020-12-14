using System.Collections.Generic;

namespace SP_lab5
{
    public class Subject
    {
        public SubjectEnum SubjectName { get; set; }
        public List<int> Graduates { get; set; } = new List<int>();

        public Subject(SubjectEnum enumName)
        {
            SubjectName = enumName;
        }
    }
}