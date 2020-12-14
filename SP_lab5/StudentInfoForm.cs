using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SP_lab5
{
    public partial class StudentInfoForm : Form
    {
        private Student _student;
        private List<SubjectEnum> _subjects;
        public StudentInfoForm(Student student)
        {
            InitializeComponent();
            _student = student;
            
            _subjects = (from sbj in _student.Subjects
                select sbj.SubjectName).ToList();
            
            comboBox1.DataSource = _subjects;
            WriteGraduates();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // SubjectName = (SubjectEnum)Enum.Parse(typeof(SubjectEnum), comboBox1.SelectedItem.ToString());
            (from subj in _student.Subjects
                where subj.SubjectName.ToString() == comboBox1.SelectedItem.ToString()
                select subj).FirstOrDefault()
                ?.Graduates.Add(decimal.ToInt32(numericUpDown1.Value));
            
            WriteGraduates();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            WriteGraduates();
        }

        private void WriteGraduates()
        {
            IEnumerable<object> grads = new List<object>();
            var gradsList = (from stSb in _student.Subjects
                where stSb.SubjectName.ToString() == comboBox1.SelectedItem.ToString()
                select stSb.Graduates).FirstOrDefault(); 
            
            if(gradsList != null)
                grads = from grad in gradsList select grad as object;
            
            listBox1.Items.Clear();
            listBox1.Items.AddRange(grads.ToArray());
        }
    }
}