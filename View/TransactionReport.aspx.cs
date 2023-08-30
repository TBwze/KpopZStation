using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectLabPSDT.Dataset;
using ProjectLabPSDT.Handler;
using ProjectLabPSDT.Model;
using ProjectLabPSDT.Report;

namespace ProjectLabPSDT.View
{
    public partial class TransactionReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CrystalReport report = new CrystalReport();
            CrystalReportViewer1.ReportSource = report;
            DataSet data = getData(TransactionHandler.getTransactions());
            report.SetDataSource(data);
        }

        private static DataSet getData(List<TransactionHeader> transaction)
        {
            DataSet data = new DataSet();
            var headerTable = data.TransactionHeader;
            var detailTable = data.TransactionDetail;

            foreach(TransactionHeader t in transaction)
            {
                var headerRow = headerTable.NewRow();
                headerRow["TransactionID"] = t.TransactionID;
                headerRow["TransactionDate"] = t.TransactionDate;
                headerRow["CustomerID"] = t.CustomerID;
                headerTable.Rows.Add(headerRow);

                foreach(TransactionDetail td in t.TransactionDetails)
                {
                    var detailRow = detailTable.NewRow();
                    detailRow["TransactionID"] = td.TransactionID;
                    detailRow["AlbumID"] = td.AlbumID;
                    detailRow["Qty"] = td.Qty;
                    detailTable.Rows.Add(detailRow);
                }
            }

            return data;

        }

    }
}