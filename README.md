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
