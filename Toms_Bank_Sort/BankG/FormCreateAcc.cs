using System;
using BankLib;
using System.Windows.Forms;

namespace BankG
{
    public partial class FormCreateAcc : Form
    {
        Account account;
        public FormCreateAcc()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Validation.ValidName(txtName.Text) &&
                Validation.ValidAccountNumOrAmt(txtBal.Text) &&
                Validation.ValidPin(txtPin.Text))
            {

                switch (cmbType.Text)
                {
                    case "Savings":
                        account = new SavingsAccount(txtName.Text, int.Parse(txtBal.Text), txtPin.Text);
                        break;

                    case "Current":
                        account = new CurrentAccount(txtName.Text, int.Parse(txtBal.Text), txtPin.Text);
                        break;

                    default:
                        break;
                }

                SuperGlobal.account = account;
                SuperGlobal.db.Insert(account);

                Dialog d = new Dialog(account.AccNum);

                FormAccountOps f = new FormAccountOps();
                f.Show();
                Close();
            }else
            {
                Dialog d = new Dialog("invalid input");
            }
        }

        private void btnRoot_Click(object sender, EventArgs e)
        {
            SuperGlobal.rootForm.Show();
            Close();
        }
    }
}
