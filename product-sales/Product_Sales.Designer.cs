namespace product_sales
{
    partial class Product_Sales
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvTotal = new System.Windows.Forms.DataGridView();
            this.dgvSales = new System.Windows.Forms.DataGridView();
            this.SALEID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUCTCODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUCTNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QUANTITY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UNITPRICE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SALEDATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnPrintReport = new System.Windows.Forms.Button();
            this.labelEndDate = new System.Windows.Forms.Label();
            this.labelStartDate = new System.Windows.Forms.Label();
            this.btnLoad = new System.Windows.Forms.Button();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSales)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(-10, -3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1054, 707);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel3.Controls.Add(this.dgvTotal);
            this.panel3.Controls.Add(this.dgvSales);
            this.panel3.Location = new System.Drawing.Point(0, 125);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1054, 589);
            this.panel3.TabIndex = 1;
            // 
            // dgvTotal
            // 
            this.dgvTotal.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
            this.dgvTotal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTotal.Location = new System.Drawing.Point(559, 466);
            this.dgvTotal.Name = "dgvTotal";
            this.dgvTotal.RowHeadersWidth = 51;
            this.dgvTotal.RowTemplate.Height = 24;
            this.dgvTotal.Size = new System.Drawing.Size(457, 98);
            this.dgvTotal.TabIndex = 1;
            this.dgvTotal.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTotal_CellContentClick);
            // 
            // dgvSales
            // 
            this.dgvSales.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
            this.dgvSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SALEID,
            this.PRODUCTCODE,
            this.PRODUCTNAME,
            this.QUANTITY,
            this.UNITPRICE,
            this.SALEDATE});
            this.dgvSales.Location = new System.Drawing.Point(16, 16);
            this.dgvSales.Name = "dgvSales";
            this.dgvSales.RowHeadersWidth = 51;
            this.dgvSales.RowTemplate.Height = 24;
            this.dgvSales.Size = new System.Drawing.Size(1000, 447);
            this.dgvSales.TabIndex = 0;
            this.dgvSales.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSales_CellContentClick);
            this.dgvSales.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSales_CellContentDoubleClick);
            this.dgvSales.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvSales_RowsAdded);
            // 
            // SALEID
            // 
            this.SALEID.HeaderText = "SALEID";
            this.SALEID.MinimumWidth = 6;
            this.SALEID.Name = "SALEID";
            this.SALEID.Width = 50;
            // 
            // PRODUCTCODE
            // 
            this.PRODUCTCODE.HeaderText = "PRODUCTCODE";
            this.PRODUCTCODE.MinimumWidth = 6;
            this.PRODUCTCODE.Name = "PRODUCTCODE";
            this.PRODUCTCODE.Width = 125;
            // 
            // PRODUCTNAME
            // 
            this.PRODUCTNAME.HeaderText = "PRODUCTNAME";
            this.PRODUCTNAME.MinimumWidth = 6;
            this.PRODUCTNAME.Name = "PRODUCTNAME";
            this.PRODUCTNAME.Width = 130;
            // 
            // QUANTITY
            // 
            this.QUANTITY.HeaderText = "QUANTITY";
            this.QUANTITY.MinimumWidth = 6;
            this.QUANTITY.Name = "QUANTITY";
            this.QUANTITY.Width = 125;
            // 
            // UNITPRICE
            // 
            this.UNITPRICE.HeaderText = "UNITPRICE";
            this.UNITPRICE.MinimumWidth = 6;
            this.UNITPRICE.Name = "UNITPRICE";
            this.UNITPRICE.Width = 125;
            // 
            // SALEDATE
            // 
            this.SALEDATE.HeaderText = "SALEDATE";
            this.SALEDATE.MinimumWidth = 6;
            this.SALEDATE.Name = "SALEDATE";
            this.SALEDATE.Width = 140;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel2.Controls.Add(this.btnPrintReport);
            this.panel2.Controls.Add(this.labelEndDate);
            this.panel2.Controls.Add(this.labelStartDate);
            this.panel2.Controls.Add(this.btnLoad);
            this.panel2.Controls.Add(this.dtpEnd);
            this.panel2.Controls.Add(this.dtpStart);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1054, 119);
            this.panel2.TabIndex = 0;
            // 
            // btnPrintReport
            // 
            this.btnPrintReport.BackColor = System.Drawing.Color.Red;
            this.btnPrintReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintReport.ForeColor = System.Drawing.Color.White;
            this.btnPrintReport.Location = new System.Drawing.Point(915, 54);
            this.btnPrintReport.Name = "btnPrintReport";
            this.btnPrintReport.Size = new System.Drawing.Size(82, 44);
            this.btnPrintReport.TabIndex = 5;
            this.btnPrintReport.Text = "Print";
            this.btnPrintReport.UseVisualStyleBackColor = false;
            this.btnPrintReport.Click += new System.EventHandler(this.btnPrintReport_Click);
            // 
            // labelEndDate
            // 
            this.labelEndDate.AutoSize = true;
            this.labelEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEndDate.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.labelEndDate.Location = new System.Drawing.Point(404, 25);
            this.labelEndDate.Name = "labelEndDate";
            this.labelEndDate.Size = new System.Drawing.Size(99, 25);
            this.labelEndDate.TabIndex = 4;
            this.labelEndDate.Text = "End Date:";
            // 
            // labelStartDate
            // 
            this.labelStartDate.AutoSize = true;
            this.labelStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStartDate.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.labelStartDate.Location = new System.Drawing.Point(31, 25);
            this.labelStartDate.Name = "labelStartDate";
            this.labelStartDate.Size = new System.Drawing.Size(105, 25);
            this.labelStartDate.TabIndex = 3;
            this.labelStartDate.Text = "Start Date:";
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.ForeColor = System.Drawing.SystemColors.Menu;
            this.btnLoad.Location = new System.Drawing.Point(780, 54);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(114, 44);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Filter";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // dtpEnd
            // 
            this.dtpEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEnd.Location = new System.Drawing.Point(407, 61);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(345, 30);
            this.dtpEnd.TabIndex = 1;
            // 
            // dtpStart
            // 
            this.dtpStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStart.Location = new System.Drawing.Point(34, 61);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(345, 30);
            this.dtpStart.TabIndex = 0;
            this.dtpStart.Value = new System.DateTime(2025, 6, 20, 0, 0, 0, 0);
            this.dtpStart.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // Product_Sales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 701);
            this.Controls.Add(this.panel1);
            this.Name = "Product_Sales";
            this.Text = "Product Sales";
            this.Load += new System.EventHandler(this.Product_Sales_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSales)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label labelEndDate;
        private System.Windows.Forms.Label labelStartDate;
        private System.Windows.Forms.DataGridView dgvSales;
        private System.Windows.Forms.DataGridViewTextBoxColumn SALEID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCTCODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCTNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn QUANTITY;
        private System.Windows.Forms.DataGridViewTextBoxColumn UNITPRICE;
        private System.Windows.Forms.DataGridViewTextBoxColumn SALEDATE;
        private System.Windows.Forms.Button btnPrintReport;
        private System.Windows.Forms.DataGridView dgvTotal;
    }
}

