using System;
using System.Collections.Generic;
using System.Text;

namespace ATMGroupA
{
    public class Menu :Bank
    {
        //Represents the current stage the user is in
        public int CurrentStage { get; set; }
        public Menu()
        {
            CurrentStage = 1;
        }
        public void DisplayWelcomeScreen()
        {
            Console.WriteLine($"\t\t\t\t\t\tWelcome to {BankName} ATM\n\nPlease insert your atm card to get started\n");
            Console.WriteLine("1 : Insert ATM Card\n2 : Exit");
            string selectedOption = Console.ReadLine();
            switch(selectedOption)
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
        public void DisplayHomeScreen()
        {

        }
        public void CheckingOption(string option)
        {
            switch (option)
            {
                case "b":
                    this.CurrentStage = 1;
                    break;
                case "a":
                    this.CurrentStage = 3;
                    break;
                case "e":
                    Environment.Exit(0);
                    break;
                default:
                    break;

            }
            Console.Clear();
        }
    }
}
