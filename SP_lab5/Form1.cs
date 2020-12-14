using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace SP_lab5
{
    public partial class Form1 : Form
    {
        public List<Student> Students = new List<Student>();

        XmlSerializer formatter = new XmlSerializer(typeof(List<Student>));
        
        private BindingSource bindingSource;
        private IEnumerable<Student> data;
        public Form1()
        {
            InitializeComponent();
            using (FileStream fs = new FileStream("students.xml", FileMode.OpenOrCreate))
            {
                Students = (List<Student>)formatter.Deserialize(fs);
            }
            
            bindingSource = new BindingSource();
            data = from st in Students select st;
            bindingSource.DataSource = data.ToList();
            dataGridView1.DataSource = bindingSource;
            comboBox1.DataSource = Enum.GetValues(typeof(SubjectEnum));
        }
        
        private void UpdateForm()
        {
            bindingSource.DataSource = data.ToList();
            bindingSource.ResetBindings(true);
            Update();
        }

        private void onAddStudentClicked(object sender, EventArgs e)
        {
            var addingForm = new AddStudentForm();
            addingForm.ShowDialog();

            if (addingForm.DialogResult == DialogResult.Yes)
                Students.Add(addingForm.StudentObj);

            UpdateForm();
        }
        
        private void onRemoveStudendClicked(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dataGridView1.SelectedRows)
            {
                IEnumerable<Student> removableStudent = from st in Students
                    where st.Name == item.Cells[0].Value.ToString()
                    select st;
          
                Students.Remove(removableStudent.ToList()[0]);
            }
            UpdateForm();
        }

        private void onChangeSurnameClicked(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dataGridView1.SelectedRows)
            {
                var changeForm = new ChangeSurnameForm();
                changeForm.ShowDialog();
                if (changeForm.DialogResult == DialogResult.Yes)
                    item.Cells[1].Value = changeForm.NewSurname;
            }
            UpdateForm();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                data = from st in Students
                    where (from sub in st.Subjects select sub.SubjectName.ToString())
                        .Contains(comboBox1.SelectedItem
                        .ToString())
                    select st;
            }
            else
                data = from st in Students select st;
            UpdateForm();
        }

        private void button5_Click(object sender, EventArgs e)
        {    
            if (checkBox1.Checked)
                foreach (DataGridViewRow item in dataGridView1.SelectedRows)
                {
                    Subject changableSubject = (from sub in (item.DataBoundItem as Student).Subjects
                        where sub.SubjectName.ToString() == comboBox1.SelectedItem.ToString()
                        select sub).FirstOrDefault();
                    var changeSubjectForm = new ChangeSubjectForm(item.DataBoundItem as Student, comboBox1.SelectedItem.ToString());
                    changeSubjectForm.ShowDialog();
                    if (changeSubjectForm.DialogResult == DialogResult.Yes)
                        changableSubject.SubjectName = changeSubjectForm.newSubjectName;
                }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dataGridView1.SelectedRows)
            {
                var addSubjectForm = new AddSubjectForm();
                addSubjectForm.ShowDialog();
                if (addSubjectForm.DialogResult == DialogResult.Yes)
                    (item.DataBoundItem as Student).AddSubject(addSubjectForm.SubjectName);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                foreach (DataGridViewRow item in dataGridView1.SelectedRows)
                {
                    Subject removableSubject = (from sub in (item.DataBoundItem as Student)?.Subjects
                        where sub.SubjectName.ToString() == comboBox1.SelectedItem.ToString()
                        select sub).FirstOrDefault();
                    (item.DataBoundItem as Student)?.Subjects.Remove(removableSubject);
                }
            UpdateForm();
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var studentInfo = new StudentInfoForm(dataGridView1.SelectedRows[0].DataBoundItem as Student);
            studentInfo.ShowDialog();
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                data = from st in Students orderby st.Surname select st;
            }
            UpdateForm();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            using (FileStream fs = new FileStream("students.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Students);
            }
        }
    }
}