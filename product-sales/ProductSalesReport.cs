using DevExpress.XtraReports.UI;
using DevExpress.XtraPrinting;
using DevExpress.Utils;
using System;
using System.Data;
using System.Drawing;

public class ProductSalesReport : XtraReport
{
    public ProductSalesReport(DataTable reportData)
    {
        this.DataSource = reportData;

        // Bands
        GroupHeaderBand groupHeader = new GroupHeaderBand();
        DetailBand detail = new DetailBand();
        GroupFooterBand groupFooter = new GroupFooterBand();
        ReportFooterBand reportFooter = new ReportFooterBand();

        groupHeader.HeightF = 30;
        detail.HeightF = 25;
        groupFooter.HeightF = 30;
        reportFooter.HeightF = 40;

        this.Bands.AddRange(new Band[] {
            groupHeader,
            detail,
            groupFooter,
            reportFooter
        });

        // Group by PRODUCTCODE
        groupHeader.GroupFields.Add(new GroupField("PRODUCTCODE"));

        // Group Header - Product Info
        XRLabel groupLabel = new XRLabel
        {
            ExpressionBindings = {
                new ExpressionBinding("BeforePrint", "Text", "'Product Code: ' + [PRODUCTCODE] + ' | Name: ' + [PRODUCTNAME]")
            },
            Font = new Font("Arial", 10, FontStyle.Bold),
            WidthF = 700,
            HeightF = 25
        };
        groupHeader.Controls.Add(groupLabel);

        // Detail Row - SALEID, QUANTITY, UNITPRICE, TOTAL
        string[] fields = { "SALEID", "QUANTITY", "UNITPRICE", "TOTAL" };
        float[] widths = { 100, 100, 150, 150 };
        float x = 0;

        for (int i = 0; i < fields.Length; i++)
        {
            XRLabel detailLabel = new XRLabel
            {
                ExpressionBindings = {
                    new ExpressionBinding("BeforePrint", "Text", $"[{fields[i]}]")
                },
                Font = new Font("Arial", 9),
                Borders = BorderSide.All,
                LocationF = new PointF(x, 0),
                SizeF = new SizeF(widths[i], 20),
                TextAlignment = TextAlignment.MiddleLeft
            };

            if (fields[i] == "UNITPRICE" || fields[i] == "TOTAL")
                detailLabel.TextFormatString = "{0:C2}";

            detail.Controls.Add(detailLabel);
            x += widths[i];
        }

        // Group Footer - Summary per product
        XRLabel qtySum = new XRLabel
        {
            ExpressionBindings = {
                new ExpressionBinding("BeforePrint", "Text", "'Total Qty: ' + sumSum([QUANTITY])")
            },
            Font = new Font("Arial", 9, FontStyle.Bold),
            LocationF = new PointF(0, 0),
            WidthF = 300
        };

        XRLabel totalSum = new XRLabel
        {
            ExpressionBindings = {
                new ExpressionBinding("BeforePrint", "Text", "'Total Revenue: ' + sumSum([TOTAL])")
            },
            Font = new Font("Arial", 9, FontStyle.Bold),
            LocationF = new PointF(300, 0),
            WidthF = 300,
            TextFormatString = "{0:C2}"
        };

        groupFooter.Controls.Add(qtySum);
        groupFooter.Controls.Add(totalSum);

        // Report Footer - Grand Totals
        XRLabel grandQty = new XRLabel
        {
            ExpressionBindings = {
                new ExpressionBinding("BeforePrint", "Text", "'GRAND TOTAL Quantity: ' + sumSum([QUANTITY])")
            },
            Font = new Font("Arial", 10, FontStyle.Bold),
            LocationF = new PointF(0, 0),
            WidthF = 300
        };

        XRLabel grandTotal = new XRLabel
        {
            ExpressionBindings = {
                new ExpressionBinding("BeforePrint", "Text", "'GRAND TOTAL Revenue: ' + sumSum([TOTAL])")
            },
            Font = new Font("Arial", 10, FontStyle.Bold),
            LocationF = new PointF(300, 0),
            WidthF = 300,
            TextFormatString = "{0:C2}"
        };

        reportFooter.Controls.Add(grandQty);
        reportFooter.Controls.Add(grandTotal);
    }
}

