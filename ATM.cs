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
        private Bank currentBank=new Bank();
        private static Bank selectedAccount;
        private string BankName;
        private Random transId = new Random();
        //private Transaction transaction = new Transaction();



        public ATM(string nameOfBank)
        {
            BankName = nameOfBank;
            transAmt = 0M;
            accountList = new List<Bank>
            {
                new Bank(){AccountName="Oluwasegun Akinpelu",AccountNumber=0165300000,CardPin=7089,Balance=50000m,isLocked=false},
                new Bank(){AccountName="Michael Musediku",AccountNumber=1456789090,CardPin=6757,Balance=150000m,isLocked=false},
                new Bank(){AccountName="Bernice Apkas",AccountNumber=2093465739,CardPin=6783,Balance=500000m,isLocked=false},
                new Bank(){AccountName="SBSC",AccountNumber=1789890909,CardPin=2543,Balance=5000000m,isLocked=true},
            };
            listOfTransactions = new List<Transaction>();
        }
        public void CheckCardPin()
        {
            bool pass = false;
            while(!pass)
            {
                Console.Write("Enter account number : ");
                string AccountNumberInputString = Console.ReadLine();
                int AccountNumberInput;
                while (!int.TryParse(AccountNumberInputString,out AccountNumberInput ))
                {
                    Console.Clear();
                    Console.WriteLine("Invalid Input");
                    Console.Write("Enter account number : ");
                    AccountNumberInputString = Console.ReadLine();
                }
                currentBank.AccountNumber = AccountNumberInput;
                Console.Write("Enter 4 Digit PIN : ");
                string pin = Security.GetHiddenConsoleInput();
                int cardPin;
                while(!int.TryParse(pin,out cardPin))
                {
                    Console.WriteLine("Invalid Input");
                    Console.Write("Enter 4 Digit PIN : ");
                    pin = Security.GetHiddenConsoleInput();
                }
                currentBank.CardPin = cardPin;
               // currentBank.CardPin = Convert.ToInt32(Security.GetHiddenConsoleInput());


                Console.Write("\nChecking Account Number and Card Pin");
                Security.printDotAnimation();

                foreach(Bank account in accountList)
                {
                    if (currentBank.AccountNumber.Equals(account.AccountNumber))
                    {
                        selectedAccount = account;
                        if (currentBank.CardPin.Equals(account.CardPin))
                        {

                            if (selectedAccount.isLocked)
                            {
                                LockAccount();
                            }
                            else
                            {
                                pass = true;
                                Menu.CurrentStage = 3;
                            }

                        }
                        else
                        {
                            pass = false;
                            Console.Clear();
                            Console.WriteLine("Account Number or Password is not Correct");
                            tries++;
                            if (tries >= maxTries)
                            {
                                selectedAccount.isLocked = true;
                               
                                LockAccount();
                            }
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
        public void CheckBalance()
        {
            Console.WriteLine($"\nYour bank account balance is : {selectedAccount.Balance}");
           
        }

        public void MakeWithdrawal()
        {
            //Menu.CurrentStage = 5;
            Console.WriteLine("Can Only Witdraw in #1000 notes");
            Console.Write("Enter amount to withdraw : ");
            string amount = Console.ReadLine();
            while(!decimal.TryParse(amount,out transAmt))
            {
                Console.Write("\nPlease enter a money value\nEnter amount to withdraw : ");
                amount = Console.ReadLine();
            }
            if(transAmt<=0)
            {
                Console.WriteLine("Amount needs to be more than zero.");
                MakeWithdrawal();
            }
            else if(transAmt>selectedAccount.Balance)
            {
                Console.WriteLine($"Withdrawal failed. You do not have enough fund to withdraw\n\nYour Balance is : {currentBank.Balance}");
                MakeWithdrawal();
            }
            else if((selectedAccount.Balance-transAmt)<minimumKeptAmount)
            {
                Console.WriteLine($"Withdrawal failed. You do not have enough funds to withdraw\n\nAvailable balance : {currentBank.Balance-minimumKeptAmount}\n\nLedger Balance : {currentBank.Balance}");
                MakeWithdrawal();
            }
            else if(transAmt%1000!=0)
            {
                MakeWithdrawal();
            }
            else
            {
                Console.Write("\nPlease Wait");
                Security.printDotAnimation();
                Transaction transaction=new Transaction()
                {
                    TransactionAmount = transAmt,
                    TransactionDate = DateTime.Now,
                    TransactionId = transId.Next(10000, 99999),
                };
                
                InsertTransaction(selectedAccount, transaction);
                
                selectedAccount.Balance = selectedAccount.Balance - transAmt;
                Console.WriteLine("Please collect your Money");
            }



        }

        public void InsertTransaction(Bank bankAccount, Transaction transaction)
        {
           // listOfTransactions = new List<Transaction>();
            
           listOfTransactions.Add(transaction);
        }

        public void ViewTransaction()
        {
            if(listOfTransactions.Count<=0)
            {
                Console.WriteLine("\nNo Transaction has been made");
               
            }
            else
            {
                Console.WriteLine($"\n\t\t\t\tTransaction history for {selectedAccount.AccountName}\n");
                Console.WriteLine("\t\t\tDate\t\t\tId\t\t\tAmount");
                    foreach (var transaction in listOfTransactions)
                {
                    Console.Write($"\n\n\t\t{transaction.TransactionDate}\t\t{transaction.TransactionId}\t\t\t{transaction.TransactionAmount}");
                }

                Console.WriteLine($"\nYou have Performed {listOfTransactions.Count} Transactions");
            }
        }
    }
}
