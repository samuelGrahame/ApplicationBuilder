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
    public partial class frmTable : Form
    {
#if BRIDGE
        public Data.Table table;
#endif
        public frmTable()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button2.Enabled = !string.IsNullOrWhiteSpace(textBox1.Text);
        }

        private void frmTable_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
#if BRIDGE            
            int i = 0;
            foreach (var item in table.Fields)
            {
                RenderField(item, i);
                i++;
            }
#endif        
        }

        private void button3_Click(object sender, EventArgs e)
        {
#if BRIDGE
            var nf = new Data.SchemaField();
            table.Fields.Add(nf);
            RenderField(nf, table.Fields.Count - 1);            
#endif
        }

#if BRIDGE
        public void RenderField(Data.SchemaField field, int index)
        {
            var panelField = new System.Windows.Forms.Panel();
            var txtName = new System.Windows.Forms.TextBox();
            var lblName = new System.Windows.Forms.Label();
            var txtType = new System.Windows.Forms.ComboBox();
            var lblType = new System.Windows.Forms.Label();
            var txtDefaultValue = new System.Windows.Forms.TextBox();
            var lblDefaultValue = new System.Windows.Forms.Label();
            var lblComment = new System.Windows.Forms.Label();
            var txtComment = new System.Windows.Forms.TextBox();

            this.panel1.SuspendLayout();
            panelField.SuspendLayout();

            panelField.Controls.Add(txtComment);
            panelField.Controls.Add(lblComment);
            panelField.Controls.Add(lblDefaultValue);
            panelField.Controls.Add(txtDefaultValue);
            panelField.Controls.Add(lblType);
            panelField.Controls.Add(txtType);
            panelField.Controls.Add(lblName);
            panelField.Controls.Add(txtName);
            panelField.Dock = System.Windows.Forms.DockStyle.Top;
            panelField.Location = new System.Drawing.Point(0, index * 100);
            panelField.Name = "panelField";
            panelField.Size = new System.Drawing.Size(427, 100);
            panelField.TabIndex = 0;
            // 
            // txtName
            // 
            txtName.Location = new System.Drawing.Point(95, 14);
            txtName.Name = "txtName";
            txtName.Size = new System.Drawing.Size(140, 20);
            txtName.TabIndex = 0;
            txtName.Text = field.Name;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new System.Drawing.Point(15, 17);
            lblName.Name = "lblName";
            lblName.Size = new System.Drawing.Size(38, 13);
            lblName.TabIndex = 1;
            lblName.Text = "Name:";
            // 
            // txtType
            // 
            txtType.FormattingEnabled = true;
            txtType.Location = new System.Drawing.Point(95, 40);
            txtType.Name = "txtType";
            txtType.Size = new System.Drawing.Size(140, 21);
            txtType.TabIndex = 2;
            var names = Enum.GetNames(typeof(Data.SchemaFieldType));
            txtType.Items.AddRange(names);
            txtType.Text = names[(int)field.FieldType];
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.Location = new System.Drawing.Point(15, 43);
            lblType.Name = "lblType";
            lblType.Size = new System.Drawing.Size(34, 13);
            lblType.TabIndex = 3;
            lblType.Text = "Type:";
            // 
            // txtDefaultValue
            // 
            txtDefaultValue.Location = new System.Drawing.Point(95, 67);
            txtDefaultValue.Name = "txtDefaultValue";
            txtDefaultValue.Size = new System.Drawing.Size(140, 20);
            txtDefaultValue.TabIndex = 4;
            txtDefaultValue.Text = field.DefaultValue;
            // 
            // lblDefaultValue
            // 
            lblDefaultValue.AutoSize = true;
            lblDefaultValue.Location = new System.Drawing.Point(15, 70);
            lblDefaultValue.Name = "lblDefaultValue";
            lblDefaultValue.Size = new System.Drawing.Size(74, 13);
            lblDefaultValue.TabIndex = 5;
            lblDefaultValue.Text = "Default Value:";
            // 
            // lblComment
            // 
            lblComment.AutoSize = true;
            lblComment.Location = new System.Drawing.Point(241, 17);
            lblComment.Name = "lblComment";
            lblComment.Size = new System.Drawing.Size(59, 13);
            lblComment.TabIndex = 6;
            lblComment.Text = "Comments:";
            // 
            // txtComment
            // 
            txtComment.Location = new System.Drawing.Point(241, 40);
            txtComment.Multiline = true;
            txtComment.Name = "txtComment";
            txtComment.Size = new System.Drawing.Size(165, 47);
            txtComment.TabIndex = 7;
            txtComment.Text = field.Comments;

            this.panel1.Controls.Add(panelField);

            this.panel1.ResumeLayout(false);
            panelField.ResumeLayout(false);

        }
#endif
    }
}
