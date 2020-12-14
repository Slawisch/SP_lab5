using System;
using System.Windows.Forms;

namespace SP_lab5
{
    public partial class ChangeSurnameForm : Form
    {
        public string NewSurname;
        
        public ChangeSurnameForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NewSurname = textBox1.Text;
            
            DialogResult = DialogResult.Yes;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}