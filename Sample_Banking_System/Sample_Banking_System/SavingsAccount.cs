using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_Banking_System
{
    
    public class SavingsAccount : BankAccount {
        
        private double interestrate = 0;
        public double totalbalance = 0;
        public double InterestRate
        {
            get
            {
                return interestrate;
            }
            set
            {
                interestrate = value;
            }
        }
        public double SavingsAccountTotalBalance()
        {
            totalbalance = inibalance + (inibalance * interestrate / 100);
            return totalbalance;
        }
        
    }
}
