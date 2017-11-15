using System;
using BankLib;
using System.Windows.Forms;

namespace BankG
{
    public partial class FormTransact : Form
    {
        Account account;
        string s;

        public FormTransact(string s)
        {
            InitializeComponent();
            this.s = s;
            
        }

        private void FormTransact_Load(object sender, EventArgs e)
        {
            account = SuperGlobal.account;
            lblDetails.Text = account.Name + "\n" + account.AccNum + "\n" + account.Balance;
            lblTrans.Text = s;
        }

        private void btnProceed_Click(object sender, EventArgs e)
        {

            try
            {

                if (Validation.ValidAccountNumOrAmt(txtAmt.Text))
                {
                    if (s == "withdraw")
                    {
                        account.WithDraw(int.Parse(txtAmt.Text));
                        
                    }
                    else
                    {
                        account.Deposit(int.Parse(txtAmt.Text));
                        
                    }
                    SuperGlobal.db.Update(account.AccNum, account);
                    account = SuperGlobal.db.Retrieve(account.AccNum, account.Pin);
                    FormAccountOps f = new FormAccountOps();
                    f.Show();
                    Close();
                }
                else
                {
                    Dialog g = new Dialog("Invalid amount");
                    g.ShowDialog();
                }
            }
            catch (Exception)
            {
                Dialog g = new Dialog("Invalid amount");
                g.ShowDialog();
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
