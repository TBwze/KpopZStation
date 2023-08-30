using ProjectLabPSDT.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectLabPSDT.Factory
{
    public class TransactionDetailFactory
    {
        public static TransactionDetail createTransactionDetail(int transactionID, int albumID, int qty)
        {
            return new TransactionDetail
            {
                TransactionID = transactionID,
                AlbumID = albumID,
                Qty = qty
            };
        }
    }
}