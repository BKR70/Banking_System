using Microsoft.VisualBasic;
using Sample_Banking_System;
using System;
using System.Diagnostics.Metrics;

namespace Sample_Banking_System {
    public class Program
    {
        public static void Main(String[] args) {

            Dictionary<int, BankAccount> original = new Dictionary<int, BankAccount>();
            Dictionary<int, SavingsAccount> dict = new Dictionary<int, SavingsAccount>();
            while (true) {
                Console.WriteLine("Simple Banking System options:");
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Check Balance");
                Console.WriteLine("5. Apply Interest (Savings Account)");
                Console.WriteLine("6. Exit");
                
                int op = ValidityCheck("Choose an option: ","Invalid Input. Plz choose right option!", 1, 6);
                if (op == 1)
                    CreateAccount(ref original, ref dict);
                else if (op == 2) 
                    Deposit(ref original, ref dict);
                else if (op == 3) 
                    Withdraw(ref original, ref dict);
                else if (op == 4) 
                    CheckBalance(ref original, ref dict);
                else if (op == 5) 
                    ApplyInterest(ref original, ref dict);
                else {
                    Console.WriteLine("Exited successfully!\n");
                    break;
                }
                

            }
            Console.ReadKey();
        }
        static int ValidityCheck(String title_msg,String alert_msg, int f, int l)
        {
            while (true)
            {
                try
                {
                    Console.Write(title_msg);
                    int n = Convert.ToInt32(Console.ReadLine());
                    if (n>=f && n<=l)
                    {
                        return n;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch
                {
                    Console.WriteLine(alert_msg);
                }
            }
        }
        static double ValidityCheckForDouble(String title_msg, String alert_msg, double f, double l)
        {
            while (true)
            {
                try
                {
                    Console.Write(title_msg);
                    double n = Convert.ToDouble(Console.ReadLine());
                    if (n >= f && n <= l)
                    {
                        return n;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch
                {
                    Console.WriteLine(alert_msg);
                }
            }
        }
        static void CreateAccount(ref Dictionary<int, BankAccount> original, ref Dictionary<int, SavingsAccount> dict)
        {
            BankAccount Bank = new BankAccount();
            SavingsAccount Ob = new SavingsAccount();

            int type = ValidityCheck("Enter account type(1 - Regular, 2 - Savings): ","Plz choose option 1 or 2", 1, 2);

            int Acn = ValidityCheck("Enter Account Number: ", "Invalid Account no..", 1, 100000000);
            if (dict.ContainsKey(Acn) || original.ContainsKey(Acn))
            {
                Console.WriteLine("Account already existed!\n");
            }
            else if (type == 1)
            {
                Bank.AccountNumber = Acn;

                Console.Write("Enter Account Holder Name: ");
                string Name = Convert.ToString(Console.ReadLine());
                Bank.HolderName = Name;
                double Balance = ValidityCheckForDouble("Enter Initial Balance: ","Invalid Input",1.0,100000000.0);
                Bank.IniBalance = Balance;
                Bank.totalbalance = Balance;
                original.Add(Acn, Bank);
                Console.WriteLine("\nRegular account created successfully !\n");
            }
            else
            {
                Ob.AccountNumber = Acn;

                Console.Write("Enter Account Holder Name: ");
                string Name = Convert.ToString(Console.ReadLine());
                Ob.HolderName = Name;
                double Balance = ValidityCheckForDouble("Enter Initial Balance: ", "Invalid Input", 1.0, 100000000.0);
                Ob.IniBalance = Balance;

                double Interest = ValidityCheckForDouble("Enter Interest Rate(%): ", "Invalid Input", 1.0, 100000000.0);
                Ob.InterestRate = Interest;
                Ob.totalbalance = Balance;
                dict.Add(Acn, Ob);

                Console.WriteLine("Savings account created successfully !\n");

            }
        }
        static void Deposit(ref Dictionary<int, BankAccount> original, ref Dictionary<int, SavingsAccount> dict)
        {
            int Account = ValidityCheck("Enter Account Number: ", "Invalid Account no..", 1, 100000000);

            if (dict.ContainsKey(Account) || original.ContainsKey(Account))
            {
                double Deposit_Amount = ValidityCheckForDouble("Enter Deposit Amount: ", "Invalid Input", 1.0, 100000000.0);
                if (dict.ContainsKey(Account))
                {
                    Console.WriteLine("\nDeposited: ${0}", Deposit_Amount);
                    Console.WriteLine("New Balance: ${0}\n", dict[Account].MoneyDeposit(Deposit_Amount));
                }
                else
                {
                    Console.WriteLine("\nDeposited: ${0}", Deposit_Amount);
                    Console.WriteLine("New Balance: ${0}\n", original[Account].MoneyDeposit(Deposit_Amount));
                }
            }
            else
            {
                Console.WriteLine("Account Not found!\n");
            }
        }
        static void Withdraw(ref Dictionary<int, BankAccount> original, ref Dictionary<int, SavingsAccount> dict)
        {
            int Account = ValidityCheck("Enter Account Number: ", "Invalid Account no..", 1, 100000000);

            if (dict.ContainsKey(Account) || original.ContainsKey(Account))
            {
                double Withdraw_Amount = ValidityCheckForDouble("Enter Withdraw Amount: ", "Invalid Input", 1.0, 100000000.0);

                if (dict.ContainsKey(Account))
                {
                    if (Withdraw_Amount > dict[Account].totalbalance)
                    {
                        Console.WriteLine("\nInsufficient funds.\n");
                    }
                    else
                    {
                        dict[Account].MoneyWithdraw(Withdraw_Amount);
                        Console.WriteLine("\nSuccessfully withdrawn!\nNow remain balance: {0}\n", dict[Account].totalbalance);
                    }
                }
                else
                {
                    if (Withdraw_Amount > original[Account].totalbalance)
                    {
                        Console.WriteLine("\nInsufficient funds.\n");
                    }
                    else
                    {
                        original[Account].MoneyWithdraw(Withdraw_Amount);
                        Console.WriteLine("\nSuccessfully withdrawn!\nNow remain balance: {0}\n", original[Account].totalbalance);
                    }
                }
            }
            else
            {
                Console.WriteLine("Account Not found!\n");
            }
        }
        static void CheckBalance(ref Dictionary<int, BankAccount> original, ref Dictionary<int, SavingsAccount> dict) {
            
            int Account_No = ValidityCheck("Enter Account Number: ", "Invalid Account no..", 1, 100000000);
            if (dict.ContainsKey(Account_No))
            {
                Console.WriteLine("Your total balance is: {0}\n", dict[Account_No].totalbalance);
            }
            else if (original.ContainsKey(Account_No))
            {
                Console.WriteLine("Your total balance is: {0}\n", original[Account_No].totalbalance);
            }
            else
            {
                Console.WriteLine("Account Not found!\n");
            }
        }
        static void ApplyInterest(ref Dictionary<int, BankAccount> original, ref Dictionary<int, SavingsAccount> dict)
        {
            int Acn = ValidityCheck("Enter Account Number: ", "Invalid Account no..", 1, 100000000);
            if (dict.ContainsKey(Acn))
            {
                Console.WriteLine("Interest applied: $" + dict[Acn].TotalBalanceAfterApplyInterest());
                Console.WriteLine("New balance: $" + dict[Acn].totalbalance);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Invalid account or it's not savings account!\n");
            }
        }
    }
}