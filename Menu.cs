using System;
using System.Collections.Generic;
using System.Text;

namespace ATMGroupA
{
    public class Menu : Bank
    {
        //Represents the current stage the user is in
        public static int CurrentStage { get; set; }
        private static string bankName;

        public static void BankName(String nameOfBank)
        {
            bankName = nameOfBank;
            Console.WriteLine($"\t\t\t\t\t\tWelcome to {bankName} ATM\n\nPlease insert your atm card to get started\n\n");
        }
        public static void DisplayWelcomeScreen()
        {
            
           
            Console.WriteLine("1 : Insert ATM Card\n2 : Exit");
            string selectedOption = Console.ReadLine();
            Console.Write("\nProcessing Card, Please wait");
            Security.printDotAnimation();
            switch (selectedOption)
            {
                case "1":
                    CurrentStage = 2;
                    break;
                case "2":
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
            Console.Clear();
            

        }
        public static void DisplayHomeScreen()
        {
            Console.WriteLine($"\t\t\t\t\t\tWelcome to {bankName} ATM\n\n\n");
            Console.Write("\t\t\t1 : Check Balance\t\t\t\t\t2 : Withdraw");
            Console.Write("\n\t\t\t3 : View transactions\t\t\t\t\t4 : Cancel\n");
            string optionSelected = Console.ReadLine();
            Console.Write("\nPlease wait");
            Security.printDotAnimation();
            switch (optionSelected)
            {
                case "1":
                    Menu.CurrentStage = 4;
                    break;
                case "2":
                    Menu.CurrentStage = 5;
                    break;
                case "3":
                    Menu.CurrentStage = 6;
                    break;
                case "4":
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
            Console.Clear();

        }
        public static void PerformAnotherTransaction()
        {
            
            Console.WriteLine("\n\n\t\t1 : Perform another transaction?\t\t\t2 : exit");
            Console.Write("\t\t");
            string inputOption = Console.ReadLine();
            Console.Write("\nPlease wait");
            Security.printDotAnimation();
            switch (inputOption)
            {
                case "1":
                    Menu.CurrentStage = 2;
                    break;
                case "2":
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
            Console.Clear();

        }
        //    public void CheckingOption(string option)
        //    {
        //        switch (option)
        //        {
        //            case "b":
        //                this.CurrentStage = 1;
        //                break;
        //            case "a":
        //                this.CurrentStage = 3;
        //                break;
        //            case "e":
        //                Environment.Exit(0);
        //                break;
        //            default:
        //                break;

        //        }
        //        Console.Clear();
        //    }
        //}
    }
}
