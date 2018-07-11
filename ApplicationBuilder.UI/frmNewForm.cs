using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApplicationBuilder.UI
{
    public partial class frmNewForm : Form
    {
        public frmNewForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox2.Text = textBox1.Text.Replace(' ', '_');
            button2.Enabled = !string.IsNullOrWhiteSpace(textBox1.Text);
        }

        private void frmNewForm_Load(object sender, EventArgs e)
        {
#if BRIDGE
            if(Data.Schema.Tables == null || Data.Schema.Tables.Count == 0)
            {
                DialogResult = DialogResult.Cancel;
                this.Close();

                MessageBox.Show("Please have atleast one table to create a form!");

                return;
            }

            foreach (var item in Data.Schema.Tables)
            {
                comboBox1.Items.Add(item.Name);
            }
            
#endif
            textBox1.Focus();
        }
    }
}
