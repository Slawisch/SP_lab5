using System;
using System.Collections.Generic;

namespace SP_lab5
{
    [Serializable]
    public class Subject
    {
        public SubjectEnum SubjectName { get; set; }
        public List<int> Graduates { get; set; } = new List<int>();

        public Subject()
        {
            SubjectName = SubjectEnum.SP;
        }

        public Subject(SubjectEnum enumName)
        {
            SubjectName = enumName;
        }
    }
}