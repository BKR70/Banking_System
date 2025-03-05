using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_Banking_System
{
    
    public class SavingsAccount : BankAccount {
        
        private static double interestrate = 0;
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
        public double TotalBalanceAfterApplyInterest()
        {
            double interest = (totalbalance * interestrate / 100);
            totalbalance = totalbalance + interest;
            return interest;
        }
        
    }
}
