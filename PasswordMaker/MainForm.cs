using PasswordMaker.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordMaker
{
    public partial class MainForm : Form
    {
        public String Password
        {
            get
            {
                return this.textBoxPassword.Text;
            }
        }
        public MainForm()
        {
            InitializeComponent();
            this.numericUpDown1.Maximum = 65535;
            this.numericUpDown1.Value = 8;
            this.label2.Text = "最大" + 65535 + "桁";

            this.checkBoxUppercase.Checked = true;
            this.checkBoxLowercase.Checked = true;
            this.checkBoxNumbers.Checked = true;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            PasswordMakeService passwordMakeService = new PasswordMakeService(Decimal.ToInt32(this.numericUpDown1.Value), this.checkBoxUppercase.Checked, this.checkBoxLowercase.Checked, this.checkBoxNumbers.Checked, this.checkBoxSymbol.Checked);
            e.Result = passwordMakeService.GetPassWord();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(this.backgroundWorker1.IsBusy)
            {
                this.backgroundWorker1.CancelAsync();
                return;
            }

            this.backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.textBoxPassword.Text = (String)e.Result;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
