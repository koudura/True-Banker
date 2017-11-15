using System;
using BankLib;
using System.Windows.Forms;

namespace BankG
{
    public partial class FormAccountOps : Form
    {
        Account account;

        public FormAccountOps()
        {
            InitializeComponent();
        }

        private void btnRoot_Click(object sender, EventArgs e)
        {
            SuperGlobal.rootForm.Show();
            SuperGlobal.account = null;
            Close();
        }

        private void FormAccountOps_Load(object sender, EventArgs e)
        {
            account = SuperGlobal.account;
            lblDetails.Text = account.Name +"\n" + account.AccNum + "\n" + account.Balance;
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            FormUpdate f = new FormUpdate();
            f.Show();
            Close();
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            FormTransact f = new FormTransact("Deposit");
            f.Show();
            Close();
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            FormTransact f = new FormTransact("withdraw");
            f.Show();
            Close();
        }
    }
}
