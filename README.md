<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="UTF-8">
  <title>Product Sales Report - GitHub ReadMe</title>
</head>
<body>

  <h1>📦 Product Sales Report System</h1>

  <p>This is a C# Windows Forms application using DevExpress to display and print a report of product sales stored in SQL Server.</p>

  <h2>🛠 Setup Instructions</h2>
  <ol>
    <li>Open <strong>SQL Server Management Studio</strong>.</li>
    <li>Run the following SQL script to create the database and table:</li>
  </ol>

  <pre><code>CREATE DATABASE PRODUCT_SALES;
GO
USE PRODUCT_SALES;
GO

CREATE TABLE PRODUCTSALES (
    SaleID INT PRIMARY KEY,
    ProductCode NVARCHAR(10),
    ProductName NVARCHAR(100),
    Quantity INT,
    UnitPrice DECIMAL(10, 2),
    SaleDate DATE
);
GO

INSERT INTO PRODUCTSALES (SaleID, ProductCode, ProductName, Quantity, UnitPrice, SaleDate)
VALUES 
(1, 'P001', 'Pen', 10, 1.50, '2025-06-20'),
(2, 'P001', 'Pen', 5, 1.50, '2025-06-25'),
(3, 'P002', 'Notebook', 3, 3.20, '2025-06-21'),
(4, 'P003', 'Eraser', 15, 0.80, '2025-06-22');
GO</code></pre>

  <h2>🔗 Connection String</h2>
  <p>Use one of the following connection strings in your C# code:</p>

  <pre><code>// For LocalDB
"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PRODUCT_SALES;Integrated Security=True;"

// For SQL Server Express
"Data Source=YOUR_SERVER\\SQLEXPRESS;Initial Catalog=PRODUCT_SALES;Integrated Security=True;"
  </code></pre>

  <h2>📊 Sample Report Output</h2>
  <table>
    <thead>
      <tr>
        <th>Product</th>
        <th>Quantity</th>
        <th>Unit Price</th>
        <th>Total</th>
        <th>Sale Date</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td>Pen</td>
        <td>10</td>
        <td>1.50</td>
        <td>15.00</td>
        <td>2025-06-20</td>
      </tr>
      <tr>
        <td>Notebook</td>
        <td>3</td>
        <td>3.20</td>
        <td>9.60</td>
        <td>2025-06-21</td>
      </tr>
    </tbody>
  </table>

  <div class="screenshot">
  <h2>🖼 Screenshot of Report Output</h2>
  <img src="product-sales/Images/Report.png" alt="Report Preview" width="100%" style="border: 1px solid #ccc; border-radius: 8px; box-shadow: 0 2px 8px rgba(0,0,0,0.1);">
</div>
  <h2>📁 Project Structure</h2>
  <ul>
    <li><code>/FormSales.cs</code> – Form to show sales and connect to database</li>
    <li><code>/SalesReport.cs</code> – DevExpress XtraReport report class</li>
    <li><code>/Program.cs</code> – Entry point</li>
  </ul>

  <h2>🐛Support</h2>
  <p>If you have questions, feel free to open an issue or contact the maintainer.</p>

</body>
</html>
