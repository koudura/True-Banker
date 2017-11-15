using System;
using BankLib;
using System.Windows.Forms;

namespace BankG
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnRoot_Click(object sender, EventArgs e)
        {
            SuperGlobal.rootForm.Show();
            Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (Validation.ValidAccountNumOrAmt(txtAccNum.Text) &&
                Validation.ValidPin(txtPin.Text))
            {
                Account a = SuperGlobal.db.Retrieve(txtAccNum.Text, txtPin.Text);

                if (a == null)
                {
                    Dialog d = new Dialog("Account not found");
                    d.ShowDialog();
                }
                else {
                    SuperGlobal.account = a;

                    FormAccountOps f = new FormAccountOps();
                    f.Show();
                    Close();
                }
            }
            else if(!Validation.ValidAccountNumOrAmt(txtAccNum.Text))
            {
                Dialog d = new Dialog("Invalid Accnum");
                d.ShowDialog();
            }
            else if (!Validation.ValidPin(txtPin.Text))
            {
                Dialog d = new Dialog("Invalid Pin");
                d.ShowDialog();
            }


        }
    }
}
