using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankAccount
{
    public partial class Form1 : Form
    {
        double balance = 0;
        int numOfDeposits = 0;
        double totalDeposits = 0;
        int numOfChecks = 0;
        double totalChecks = 0;
        double totalServiceCharge = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            //Check which transaction is selected
            if (rbtnDeposit.Checked)
            {
                //Add deposit to balance
                balance += Convert.ToDouble(txtAmount.Text);
                //Increment the total number of deposits and add the deposit amount to total deposits
                numOfDeposits++;
                totalDeposits += Convert.ToDouble(txtAmount.Text);
            }
            else if (rbtnCheck.Checked)
            {
                //If the check amount is greater than the balance, display an insufficient funds message
                if (Convert.ToDouble(txtAmount.Text) > balance)
                {
                    MessageBox.Show("Insufficient Funds");
                    //Add service charge of $10
                    totalServiceCharge += 10;
                }
                else
                {
                    //Deduct check amount from balance and increment total number of checks and total checks amount
                    balance -= Convert.ToDouble(txtAmount.Text);
                    numOfChecks++;
                    totalChecks += Convert.ToDouble(txtAmount.Text);
                }
            }
            else if (rbtnServiceCharge.Checked)
            {
                //Deduct service charge from balance and add it to total service charge
                balance -= Convert.ToDouble(txtAmount.Text);
                totalServiceCharge += Convert.ToDouble(txtAmount.Text);
            }

            //Check if the balance is negative
            if (balance < 0)
            {
                MessageBox.Show("Warning: Negative Balance");
            }

            //Display the new balance

            lblBalance.Text = balance.ToString("c");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            
                //Clear all fields and reset variables
                balance = 0;
                numOfDeposits = 0;
                totalDeposits = 0;
                numOfChecks = 0;
                totalChecks = 0;
                totalServiceCharge = 0;
                rbtnDeposit.Checked = true;
                txtAmount.Clear();
                lblBalance.Text = "";
       
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //Close the application
            this.Close();
        }

        private void btnSummary_Click(object sender, EventArgs e)
        {
            //Display a summary message box
            MessageBox.Show("Number of Deposits: " + numOfDeposits + "\nTotal Deposits: " + totalDeposits.ToString("c") +
                "\nNumber of Checks: " + numOfChecks + "\nTotal Checks: " + totalChecks.ToString("c") +
                "\nTotal Service Charge: " + totalServiceCharge.ToString("c"));
        }
    }
}
