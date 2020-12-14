using System;
using System.Windows.Forms;

namespace SP_lab5
{
    public partial class AddStudentForm : Form
    {
        public Student StudentObj;
        public AddStudentForm()
        {
            InitializeComponent();
        }
        
        private void onAddClicked(object sender, EventArgs e)
        {
            StudentObj = new Student(textBox1.Text, textBox2.Text);
            DialogResult = DialogResult.Yes;
        }

        private void onCancelClicked(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}