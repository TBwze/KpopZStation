using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectLabPSDT.Model;
using ProjectLabPSDT.Repository;

namespace ProjectLabPSDT.Handler
{
    public class TransactionHandler
    {
        public static List<TransactionHeader> getTransactions()
        {
            return TransactionRepository.getTransactionData();
        }
    }
}