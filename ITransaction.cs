using System;
using System.Collections.Generic;
using System.Text;

namespace ATMGroupA
{
    public interface ITransaction
    {
        public void InsertTransaction(Transaction transaction, Bank bank);
        public void ViewTransaction(Bank bankAccount);
        
    }
}
