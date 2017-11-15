using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankG
{
    public partial class FormRoot : Form
    {
        public FormRoot()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            FormCreateAcc f = new FormCreateAcc();
            f.Show();
            Hide();
        }

        private void FormRoot_Load(object sender, EventArgs e)
        {
            SuperGlobal.rootForm = this;
         
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            FormLogin f = new FormLogin();
            f.Show();
            Hide();
        }
    }
}
