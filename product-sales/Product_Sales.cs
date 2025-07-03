using product_sales.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.ReportGeneration;

namespace product_sales
{
    public partial class Product_Sales : Form
    {
        private DetailBand Detail;
        private TopMarginBand TopMargin;
        private BottomMarginBand BottomMargin;
        private ReportHeaderBand ReportHeader;
        private PageHeaderBand PageHeader;
        private ReportFooterBand ReportFooter;
        public Product_Sales()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dgvSales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=HIM-SOMEALEA\\SQLEXPRESS01;Initial Catalog=PRODUCT_SALES;Integrated Security=True";

            DateTime startDate = dtpStart.Value.Date;
            DateTime endDate = dtpEnd.Value.Date;

            MessageBox.Show($"Start: {startDate}\nEnd: {endDate}");

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    string query = @"SELECT SALEID, PRODUCTCODE, PRODUCTNAME, QUANTITY, UNITPRICE, SALEDATE
                             FROM PRODUCTSALES
                             WHERE SALEDATE BETWEEN @StartDate AND @EndDate
                             ORDER BY PRODUCTCODE";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                    cmd.Parameters.AddWithValue("@EndDate", endDate);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable originalDt = new DataTable();
                    adapter.Fill(originalDt);

                    if (originalDt.Rows.Count > 0)
                    {
                        var groupedData = originalDt.AsEnumerable()
                            .GroupBy(row => new
                            {
                                ProductCode = row.Field<string>("PRODUCTCODE"),
                                ProductName = row.Field<string>("PRODUCTNAME"),
                                UnitPrice = row.Field<decimal>("UNITPRICE")
                            })
                            .Select(group => new
                            {
                                SALEID = group.First().Field<int>("SALEID"), 
                                PRODUCTCODE = group.Key.ProductCode,
                                PRODUCTNAME = group.Key.ProductName,
                                QUANTITY = group.Sum(row => row.Field<int>("QUANTITY")), 
                                UNITPRICE = group.Key.UnitPrice,
                                SALEDATE = group.Min(row => row.Field<DateTime>("SALEDATE")),
                                TOTAL = group.Sum(row => row.Field<int>("QUANTITY")) * group.Key.UnitPrice
                            });
                        DataTable groupedDt = new DataTable();
                        groupedDt.Columns.Add("SALEID", typeof(int));
                        groupedDt.Columns.Add("PRODUCTCODE", typeof(string));
                        groupedDt.Columns.Add("PRODUCTNAME", typeof(string));
                        groupedDt.Columns.Add("QUANTITY", typeof(int));
                        groupedDt.Columns.Add("UNITPRICE", typeof(decimal));
                        groupedDt.Columns.Add("SALEDATE", typeof(DateTime));
                        groupedDt.Columns.Add("TOTAL", typeof(decimal));

                        foreach (var item in groupedData)
                        {
                            groupedDt.Rows.Add(
                                item.SALEID,
                                item.PRODUCTCODE,
                                item.PRODUCTNAME,
                                item.QUANTITY,
                                item.UNITPRICE,
                                item.SALEDATE,
                                item.TOTAL
                            );
                        }

                        dgvSales.DataSource = groupedDt;
                        dgvSales.AutoGenerateColumns = true;

                        if (dgvSales.Columns["UNITPRICE"] != null)
                        {
                            dgvSales.Columns["UNITPRICE"].DefaultCellStyle.Format = "C2";
                        }
                        if (dgvSales.Columns["TOTAL"] != null)
                        {
                            dgvSales.Columns["TOTAL"].DefaultCellStyle.Format = "C2";
                        }
                        if (dgvSales.Columns["SALEDATE"] != null)
                        {
                            dgvSales.Columns["SALEDATE"].DefaultCellStyle.Format = "yyyy-MM-dd";
                        }

                        MessageBox.Show("Loaded " + groupedDt.Rows.Count + " product groups.");

                        ShowGrandTotal();
                    }
                    else
                    {
                        dgvSales.DataSource = null;
                        MessageBox.Show("No data found for selected date range.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnPrintSummary_Click(object sender, EventArgs e)
        {
            DataTable data = (DataTable)dgvSales.DataSource;

            if (data == null || data.Rows.Count == 0)
            {
                MessageBox.Show("Please load data first.");
                return;
            }

            ProductSalesReport report = new ProductSalesReport(data);
            ReportPrintTool printTool = new ReportPrintTool(report);
            printTool.ShowPreviewDialog();
        }


        private void Product_Sales_Load(object sender, EventArgs e)
        {
            dgvSales.Columns.Clear();
            dgvSales.AutoGenerateColumns = true;
            dgvSales.AllowUserToAddRows = false;
        }

        private void dgvSales_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

        }

        private void dgvSales_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCreateReportWithWizard_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable reportData = (DataTable)dgvSales.DataSource;

                if (reportData == null || reportData.Rows.Count == 0)
                {
                    MessageBox.Show("No data to print. Please load data first.");
                    return;
                }


                XtraReport report = new XtraReport();
                report.DataSource = reportData;


                ReportDesignTool designTool = new ReportDesignTool(report);
                designTool.ShowDesignerDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnPrintReport_Click(object sender, EventArgs e)
        {
            
            DataTable data = new DataTable();

            foreach (DataGridViewColumn column in dgvSales.Columns)
            {
                data.Columns.Add(column.Name, column.ValueType ?? typeof(string));
            }

            foreach (DataGridViewRow row in dgvSales.Rows)
            {
                if (!row.IsNewRow)
                {
                    DataRow dataRow = data.NewRow();
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        dataRow[cell.OwningColumn.Name] = cell.Value ?? DBNull.Value;
                    }
                    data.Rows.Add(dataRow);
                }
            }

            if (data.Rows.Count == 0)
            {
                MessageBox.Show("No data available to print.");
                return;
            }

            // Pass data to report
            SalesReport report = new SalesReport(data);
            ReportPrintTool printTool = new ReportPrintTool(report);
            printTool.ShowPreviewDialog(); // or .PrintDialog(), .Print(), etc.
        }


        private void dgvTotal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ShowGrandTotal()
        {
            if (dgvSales.DataSource == null || dgvSales.Rows.Count == 0)
            {
                dgvTotal.DataSource = null;
                return;
            }

            int totalQuantity = 0;
            decimal totalSales = 0;

            foreach (DataGridViewRow row in dgvSales.Rows)
            {
                if (row.IsNewRow) continue;

                try
                {
                    if (row.Cells["QUANTITY"].Value != null && row.Cells["QUANTITY"].Value != DBNull.Value)
                    {
                        totalQuantity += Convert.ToInt32(row.Cells["QUANTITY"].Value);
                    }

                    if (row.Cells["TOTAL"].Value != null && row.Cells["TOTAL"].Value != DBNull.Value)
                    {
                        totalSales += Convert.ToDecimal(row.Cells["TOTAL"].Value);
                    }
                }
                catch (Exception ex)
                {
                    continue;
                }
            }

            DataTable totalTable = new DataTable();
            totalTable.Columns.Add("PRODUCT_NAME", typeof(string));
            totalTable.Columns.Add("QTY", typeof(int));
            totalTable.Columns.Add("TOTAL", typeof(decimal));

            DataRow totalRow = totalTable.NewRow();
            totalRow["PRODUCT_NAME"] = "TOTAL PRICE";
            totalRow["QTY"] = totalQuantity;
            totalRow["TOTAL"] = totalSales;
            totalTable.Rows.Add(totalRow);

            dgvTotal.DataSource = totalTable;

            if (dgvTotal.Columns.Contains("TOTAL"))
            {
                dgvTotal.Columns["TOTAL"].DefaultCellStyle.Format = "C2";
            }

            if (dgvTotal.Columns.Contains("QTY"))
            {
                dgvTotal.Columns["QTY"].DefaultCellStyle.Format = "N0";
            }

            string[] columnsToHide = {"UPRICE", "SALE_DATE"};
            foreach (string columnName in columnsToHide)
            {
                if (dgvTotal.Columns.Contains(columnName))
                {
                    dgvTotal.Columns[columnName].Visible = true;
                }
            }
        }
    }
}
  