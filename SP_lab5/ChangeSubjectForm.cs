using System;
using System.Windows.Forms;

namespace SP_lab5
{
    public partial class ChangeSubjectForm : Form
    {
        private Student _student;
        public SubjectEnum newSubjectName;
        public ChangeSubjectForm(Student student, string subjectName)
        {
            InitializeComponent();
            _student = student;
            comboBox1.DataSource = Enum.GetValues(typeof(SubjectEnum));
            comboBox1.SelectedItem = (SubjectEnum) Enum.Parse(typeof(SubjectEnum), subjectName);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            newSubjectName = (SubjectEnum)comboBox1.SelectedItem;
            DialogResult = DialogResult.Yes;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}