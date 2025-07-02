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
            // Remove Execute button functionality since you don't want it
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=HIM-SOMEALEA\\SQLEXPRESS01;Initial Catalog=PRODUCT_SALES;Integrated Security=True";

            DateTime startDate = dtpStart.Value.Date;
            DateTime endDate = dtpEnd.Value.Date;

            // Show selected date range
            MessageBox.Show($"Start: {startDate}\nEnd: {endDate}");

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Fixed query to include SALEID and match your table structure
                    string query = @"SELECT SALEID, PRODUCTCODE, PRODUCTNAME, QUANTITY, UNITPRICE, SALEDATE
                             FROM PRODUCTSALES
                             WHERE SALEDATE BETWEEN @StartDate AND @EndDate
                             ORDER BY SALEID";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                    cmd.Parameters.AddWithValue("@EndDate", endDate);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        // Add calculated Total column to DataTable
                        dt.Columns.Add("TOTAL", typeof(decimal), "QUANTITY * UNITPRICE");

                        // Simply bind the data - let DataGridView auto-generate columns
                        dgvSales.DataSource = dt;
                        dgvSales.AutoGenerateColumns = true;

                        // Optional: Format the columns for better display
                        if (dgvSales.Columns["UNITPRICE"] != null)
                        {
                            dgvSales.Columns["UNITPRICE"].DefaultCellStyle.Format = "C2"; // Currency format
                        }
                        if (dgvSales.Columns["TOTAL"] != null)
                        {
                            dgvSales.Columns["TOTAL"].DefaultCellStyle.Format = "C2"; // Currency format for Total
                        }
                        if (dgvSales.Columns["SALEDATE"] != null)
                        {
                            dgvSales.Columns["SALEDATE"].DefaultCellStyle.Format = "yyyy-MM-dd"; // Date format
                        }

                        MessageBox.Show("Loaded " + dt.Rows.Count + " records.");
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

        private void Product_Sales_Load(object sender, EventArgs e)
        {
            // Clear any existing columns and let the data loading handle column creation
            dgvSales.Columns.Clear();
            dgvSales.AutoGenerateColumns = true;
            dgvSales.AllowUserToAddRows = false; // Prevent users from adding empty rows
        }

        private void dgvSales_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            // Remove Execute button functionality since you don't want it
        }

        private void dgvSales_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Remove Execute button functionality since you don't want it
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

                // Create a new custom report
                XtraReport report = new XtraReport();
                report.DataSource = reportData;

                // Optional: show the report designer instead of preview
                ReportDesignTool designTool = new ReportDesignTool(report);
                designTool.ShowDesignerDialog(); // Or use ShowPreviewDialog() for preview

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnPrintReport_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Get the current data from DataGridView
                DataTable reportData = (DataTable)dgvSales.DataSource;

                if (reportData == null || reportData.Rows.Count == 0)
                {
                    MessageBox.Show("No data to print. Please load data first.");
                    return;
                }

                // Create a simple report
                XtraReport report = new XtraReport();

                // Set data source
                report.DataSource = reportData;

                // Create a simple table-based report
                report.CreateDocument();

                // Show using ReportPrintTool
                ReportPrintTool printTool = new ReportPrintTool(report);
                printTool.ShowPreview();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating report: " + ex.Message);
            }
        }
    }
}
  