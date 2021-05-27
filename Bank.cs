using System;
using System.Collections.Generic;
using System.Text;

namespace ATMGroupA
{
    public class Bank
    {
        
        public decimal Balance { get; set; }
        public int CardPin { get; set; }
        public string  AccountName { get; set; }
        public int AccountNumber { get; set; }
        public bool isLocked { get; set; }
        //cardPin.ToString("0000")
    }
}
