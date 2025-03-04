using Microsoft.VisualBasic;
using Sample_Banking_System;
using System;
using System.Diagnostics.Metrics;


BankAccount Bank = new BankAccount();
SavingsAccount Ob = new SavingsAccount();
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
    
    try
    {
        Console.Write("Choose an option: ");
        int op = Convert.ToInt32(Console.ReadLine());
        if (op == 1)
        {
            Console.Write("Enter account type (1 - Regular, 2 - Savings): ");
            int ac = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Account Number: ");
            int Acn = Convert.ToInt32(Console.ReadLine());
            if ((dict.ContainsKey(Acn) == true) || (original.ContainsKey(Acn) == true))
            {
                Console.WriteLine("Account already existed!\n");
            }
            else if (ac == 1)
            {
                Bank.AccountNumber = Acn;

                Console.Write("Enter Account Holder Name: ");
                string Name = Convert.ToString(Console.ReadLine());
                Bank.HolderName = Name;

                Console.Write("Enter Initial Balance: ");
                double Balance = Convert.ToDouble(Console.ReadLine());
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

                Console.Write("Enter Initial Balance: ");
                double Balance = Convert.ToDouble(Console.ReadLine());
                Ob.IniBalance = Balance;

                Console.Write("Enter Interest Rate(%): ");
                double Interest = Convert.ToDouble(Console.ReadLine());
                Ob.InterestRate = Interest;
                dict.Add(Acn, Ob);

                double total_amount = dict[Acn].SavingsAccountTotalBalance();
                Console.WriteLine("\nTotal Balance is: {0}\n", total_amount);

                Console.WriteLine("Savings account created successfully !\n");

            }

        }
        else if (op == 2)
        {
            Console.Write("Enter Account Number: ");
            int Account = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Deposit Amount: ");
            double Deposit_Amount = Convert.ToDouble(Console.ReadLine());

            if (dict.ContainsKey(Account))
            {
                Console.WriteLine("\nDeposited: ${0}", Deposit_Amount);
                Console.WriteLine("New Balance: ${0}\n", dict[Account].Deposit(Deposit_Amount));
            }
            else if (original.ContainsKey(Account))
            {
                Console.WriteLine("\nDeposited: ${0}", Deposit_Amount);
                Console.WriteLine("New Balance: ${0}\n", original[Account].Deposit(Deposit_Amount));
            }
            else
            {
                Console.WriteLine("Account Not found!\n");
            }
        }
        else if (op == 3)
        {
            Console.Write("Enter Account Number: ");
            int Account = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter withdraw amount : ");
            double Withdraw_Amount = Convert.ToDouble(Console.ReadLine());

            if (dict.ContainsKey(Account))
            {
                if (Withdraw_Amount > dict[Account].totalbalance)
                {
                    Console.WriteLine("\nInsufficient funds.\n");
                }
                else
                {
                    dict[Account].Withdraw(Withdraw_Amount);
                    Console.WriteLine("\nSuccessfully withdrawn!\nNow total balance: {0}\n", dict[Account].totalbalance);
                }
            }
            else if (original.ContainsKey(Account))
            {
                if (Withdraw_Amount > original[Account].totalbalance)
                {
                    Console.WriteLine("\nInsufficient funds.\n");
                }
                else
                {
                    original[Account].Withdraw(Withdraw_Amount);
                    Console.WriteLine("\nSuccessfully withdrawn!\nNow total balance: {0}\n", original[Account].totalbalance);
                }
            }
            else
            {
                Console.WriteLine("Account Not found!\n");
            }
        }
        else if (op == 4)
        {
            Console.Write("Enter account no: ");
            int Account_No = Convert.ToInt32(Console.ReadLine());
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
        else if (op == 5)
        {
            Console.Write("Enter Account Number: ");
            int Acn = Convert.ToInt32(Console.ReadLine());
            if (dict.ContainsKey(Acn))
            {
                Console.Write("Enter interest rate: ");
                double int_rate = Convert.ToDouble(Console.ReadLine());
                dict[Acn].totalbalance += (dict[Acn].totalbalance * int_rate / 100);
                Console.WriteLine("\nTotal Balance is: {0}\n", dict[Acn].totalbalance);
            }
            else
            {
                Console.WriteLine("Invalid account or it's not savings account!\n");
            }
        }
        else if (op == 6)
        {
            Console.WriteLine("Exited successfully!\n");
            break;
        }
        else
        {
            Console.WriteLine("Invalid Option selected. Plz choose right option!\n");
        }
    }
    catch(Exception e)
    {
        Console.WriteLine("The type of error is : " + e.Message);
    }
}
Console.ReadKey();