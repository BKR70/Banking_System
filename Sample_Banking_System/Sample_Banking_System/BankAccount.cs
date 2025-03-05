using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_Banking_System
{
    public class BankAccount
    {
        private int accountnumber;
        private string holdername;
        protected double inibalance = 0;
        public double totalbalance = 0;
        public int AccountNumber
        {
            get { return accountnumber; }
            set { accountnumber = value; }
        }
        public string HolderName
        {
            get { return holdername; }
            set { holdername = value; }
        }
        public double IniBalance
        {
            get
            {
                return inibalance;
            }
            set { inibalance = value; }
        }
        public void MoneyWithdraw(double amount)
        {
            totalbalance -= amount;
        }
        public double MoneyDeposit(double depositamount)
        {
            totalbalance += depositamount;
            return totalbalance;
        }
    }
}
