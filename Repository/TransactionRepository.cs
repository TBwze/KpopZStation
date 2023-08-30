using ProjectLabPSDT.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectLabPSDT.Repository
{
    public class TransactionRepository
    {

        public static KpopZtationEntities data = SingletonDatabase.getInstance();

        public static List<TransactionHeader> getTransactionData()
        {
            return data.TransactionHeaders.ToList();
        }
    }
}