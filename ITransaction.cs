using System;
using System.Collections.Generic;
using System.Text;

namespace ATMGroupA
{
    public interface ITransaction
    {
        public void InsertTransaction(Bank bankAccount, Transaction transaction);
        public void ViewTransaction();
        
    }
}
