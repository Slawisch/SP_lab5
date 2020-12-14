using System;
using System.Windows.Forms;

namespace SP_lab5
{
    public partial class AddSubjectForm : Form
    {
        public SubjectEnum SubjectName;
        
        public AddSubjectForm()
        {
            InitializeComponent();
            comboBox1.DataSource = Enum.GetValues(typeof(SubjectEnum));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SubjectName = (SubjectEnum)Enum.Parse(typeof(SubjectEnum), comboBox1.SelectedItem.ToString());
            DialogResult = DialogResult.Yes;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}