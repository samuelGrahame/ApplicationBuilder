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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var frm = new frmNewForm();
            frm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
#if BRIDGE
            var frm = new frmTable();
            frm.table = new Data.Table();
            frm.ShowDialog(new DialogOption(DialogResult.OK, () => {
                foreach (var item in Data.Schema.Tables)
                {
                    if(item.Name == frm.table.Name)
                    {
                        MessageBox.Show($"{item.Name} already exist's in the schema!");
                        return;
                    }
                }
                Data.Schema.Tables.Add(frm.table);                
            }));
#endif
        }
    }
}
