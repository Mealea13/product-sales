using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;

namespace product_sales
{
    public partial class SalesReport : DevExpress.XtraReports.UI.XtraReport
    {
        
        public SalesReport(DataTable salesData)
        {
            InitializeComponent();
            this.DataSource = salesData;
        }

    }
}
