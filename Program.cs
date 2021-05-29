using System;

namespace ATMGroupA
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu.CurrentStage = 1;
            bool appIsRunning = true;
            ATM myAtm = new ATM("GT Bank");
            while (appIsRunning)
            {
                Menu.BankName("GT Bank");
                while (Menu.CurrentStage == 1)
                {
                    Menu.DisplayWelcomeScreen();
                }
                while (Menu.CurrentStage==2)
                {
                    Console.Clear();
                    myAtm.CheckCardPin();
                }
                while (Menu.CurrentStage==3)
                {
                    Menu.DisplayHomeScreen();
                }
                while(Menu.CurrentStage==4)
                {
                    Console.Clear();
                    myAtm.CheckBalance();
                    Menu.PerformAnotherTransaction();
                }
                while(Menu.CurrentStage==5)
                {
                    myAtm.MakeWithdrawal();
                    Menu.PerformAnotherTransaction();
                }
                while(Menu.CurrentStage==6)
                {
                    myAtm.ViewTransaction();
                    Menu.PerformAnotherTransaction();
                }
            }
        }
    }
}
