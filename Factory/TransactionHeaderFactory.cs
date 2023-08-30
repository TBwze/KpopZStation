using ProjectLabPSDT.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectLabPSDT.Factory
{
    public class TransactionHeaderFactory
    {
        public static TransactionHeader createTransactionHeader(int transactionID, DateTime transactiondate, int userID)
        {
            return new TransactionHeader
            {
                TransactionID = transactionID,
                TransactionDate = transactiondate,
                CustomerID = userID
            };
        }
    }
}