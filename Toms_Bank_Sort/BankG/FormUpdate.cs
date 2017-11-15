using System;
using BankLib;
using System.Windows.Forms;

namespace BankG
{
    public partial class FormUpdate : Form
    {
        Account account;
        public FormUpdate()
        {
            InitializeComponent();
        }

        private void FormUpdate_Load(object sender, EventArgs e)
        {
            account = SuperGlobal.account;
            lblDetails.Text = account.Name + "\n" + account.AccNum;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Validation.ValidName(txtName.Text) && Validation.ValidPin(txtPin.Text))
            {
                account.Name = txtName.Text;
                account.Pin = txtPin.Text;
                SuperGlobal.db.Update(account.AccNum, account);
                FormAccountOps f = new FormAccountOps();
                f.Show();
                Close();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FormAccountOps f = new FormAccountOps();
            f.Show();
            Close();
        }
    }
}
