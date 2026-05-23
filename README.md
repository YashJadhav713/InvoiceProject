# Invoice Management System

A modern ASP.NET Core MVC web application for managing invoices efficiently. This project allows users to create, manage, update, and organize invoices with a clean and user-friendly interface.

## 🚀 Features

* Create and manage invoices
* Add customer and invoice details
* Edit and delete invoices
* ASP.NET Core MVC architecture
* Entity Framework Core integration
* Responsive UI using Bootstrap
* Organized project structure with Controllers, Models, and Views
* Configuration management using `appsettings.json`

---

## 🛠️ Tech Stack

* **Backend:** ASP.NET Core MVC
* **Frontend:** HTML, CSS, Bootstrap
* **Database:** SQL Server / Entity Framework Core
* **Language:** C#
* **Tools:** Visual Studio, .NET SDK

---

## 📁 Project Structure

```bash
InvoiceProject/
│
├── Controllers/        # Handles application logic
├── Models/             # Entity and data models
├── Views/              # Razor views for UI
├── wwwroot/            # Static assets (CSS, JS, Images)
├── Properties/         # Launch settings and project properties
├── appsettings.json    # Application configuration
├── Program.cs          # Entry point of the application
└── InvoiceProject.csproj
```

---

## ⚙️ Installation & Setup

### Prerequisites

Make sure you have the following installed:

* [.NET SDK 6.0 or later](https://dotnet.microsoft.com/download)
* SQL Server
* Visual Studio 2022 or VS Code

### Clone the Repository

```bash
git clone https://github.com/YashJadhav713/InvoiceProject.git
```

### Navigate to the Project Directory

```bash
cd InvoiceProject/InvoiceProject
```

### Restore Dependencies

```bash
dotnet restore
```

### Configure Database

Update the connection string in:

```json
appsettings.json
```

Example:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=InvoiceDB;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

### Run Migrations (If Applicable)

```bash
dotnet ef database update
```

### Run the Application

```bash
dotnet run
```

The application will start on:

```bash
https://localhost:5001
```

---

## 📸 Screenshots
---
invoice Page

<img width="1898" height="930" alt="image" src="https://github.com/user-attachments/assets/6daa8629-20db-42dd-b907-df1deb6cbfab" />


---

## 🧩 Future Enhancements

* PDF invoice export
* Email invoice functionality
* Authentication & authorization
* Dashboard analytics
* Invoice status tracking
* Payment integration

---

## 🤝 Contributing

Contributions are welcome!

1. Fork the repository
2. Create a feature branch
3. Commit your changes
4. Push to your branch
5. Create a Pull Request

---

## 📄 License

This project is licensed under the MIT License.

---

## 👨‍💻 Author

Developed by entity["people","Yash Jadhav","GitHub developer"]

GitHub Repository: [InvoiceProject Repository](https://github.com/YashJadhav713/InvoiceProject?utm_source=chatgpt.com)

---

## ⭐ Support

If you found this project helpful, please consider giving it a star on GitHub.


# DATA BASE ................................................................................(SQL SERVER)

create database apis

use apis

create table TblCustomers
(
Customer_ID int identity primary key,
Customer_Name varchar (100),
Mobile varchar (20),
Email varchar(30),
City varchar (20)
)

create table TblProducts
(
Product_ID int identity primary key,
Product_Name varchar(100),
Rate float,
Gst float,
Stock int
)

create table Tblinvoice_details
(
Invoice_ID int identity primary key,
Invoice_Date date,
Customer_ID int constraint cusid references TblCustomers(Customer_ID) ,
TotalAmount varchar (30)
)

create table Tblinvoice_products
(
Invoiceproduct_ID int identity primary key,
Invoice_ID int constraint iid references Tblinvoice_details(Invoice_ID),
Product_ID int constraint pid references TblProducts(Product_ID),
Quantity int
)

create table Tblinvoice_payments
(
Payment_ID int identity primary key,
Invoice_ID int constraint invoiceid references Tblinvoice_details(Invoice_ID),
Product_ID int constraint productid references TblProducts(Product_ID),
Payment_Amount float,
Payment_Mode varchar (50),
Payment_Description varchar (100)
)

------------------------------Scaffold Mamand--------------------------
Scaffold-DbContext "Server = ; Database = ; Trusted_Connection = True; TrustServerCertificate = True" 
Microsoft.EntityframeworkCore.SqlServer -OutputDir Models -Tables TblCustomers,TblProducts,Tblinvoice_details,Tblinvoice_products,Tblinvoice_payments -force
