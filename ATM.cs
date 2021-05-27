using System;
using System.Collections.Generic;
using System.Text;

namespace ATMGroupA
{
    class ATM :Bank, ILogin, IBalance, ITransaction, IWithdrawal
    {
        private static decimal transAmt;
        private static int tries;
        private const int maxTries = 3;
        private const decimal minimumKeptAmount = 1000M;
        private static List<Bank> accountList;
        private static List<Transaction> listOfTransactions;
        private static Bank currentBank;
        private static Bank selectedAccount;
        private string BankName; 

        public ATM(string nameOfBank)
        {
            BankName = nameOfBank;
            transAmt = 0M;
            accountList=new List<Bank>
            {
                new Bank(){AccountName="Oluwasegun",AccountNumber=0165300000,}
            }
        }
        public void CheckCardPin()
        {
            bool pass = false;
            while(!pass)
            {
                currentBank = new Bank();
                Console.Write("Enter 4 Digit PIN : ");
                currentBank.CardPin = Convert.ToInt32(Security.GetHiddenConsoleInput());

                Console.Write("\nChecking Card Pin");
                Security.printDotAnimation();

                foreach(Bank account in accountList)
                {
                    if(currentBank.CardPin.Equals(account.CardPin))
                    {
                        selectedAccount = account;
                        if(selectedAccount.isLocked)
                        {
                            LockAccount();
                        }
                        else
                        {
                            pass = true;
                        }
                        
                    }
                    else
                    {
                        pass = false;
                        tries++;
                        if(tries>maxTries)
                        {
                            selectedAccount.isLocked = true;
                            LockAccount();
                        }
                    }
                }
            }

            if(!pass)
            {
                Console.WriteLine("Invalid PIN");
            }
            Console.Clear();
        }
        private void LockAccount()
        {
            Console.Clear();
            Console.WriteLine("Your account is locked");
            Console.WriteLine("Please visit the nearest branch to unlock your account.");
            Console.WriteLine($"Thank you for using {BankName}");
            Environment.Exit(1);
        }
        public void CheckBalance(Bank bankAcount)
        {
            throw new NotImplementedException();
        }

        public void MakeWithdrawal(Bank bankAccount)
        {
            throw new NotImplementedException();
        }

        void ITransaction.InsertTransaction(Transaction transaction, Bank bank)
        {
            throw new NotImplementedException();
        }

        void ITransaction.ViewTransaction(Bank bankAccount)
        {
            throw new NotImplementedException();
        }
    }
}
