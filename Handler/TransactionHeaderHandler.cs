using ProjectLabPSDT.Model;
using ProjectLabPSDT.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectLabPSDT.Handler
{
    public class TransactionHeaderHandler
    {
        public static KpopZtationEntities data = SingletonDatabase.getInstance();

        public static int generateTransactionID()
        {
            if (!data.TransactionHeaders.Any())
            {
                return 1;
            }
            else
            {
                return data.TransactionHeaders.Max(a => a.TransactionID) + 1;
            }
        }
    }
}