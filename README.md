# ONXCR---Customer-Order-Relationship
This project is built for the purpose of assessment for ONRCX. The project is built using C# ASP.NET CORE 7 WEB API and SQL server for the backend and database respectively. The project uses an interface layer, repository pattern, and dependency injection design framework to decouple the classes. 

## INSTRUCTION:

### 1. Clone the repository with the code below:
> git clone https://github.com/bibhutighimire/ONXCR---Customer-Order-Relationship

### 2. Create  database in SQL Server named dbCustomerOrder.

### 3. Open the code on your Visual Studio and perform migration by typing the code below on your Package Manager Console.
> dotnet ef migrations add InitialCreate

### 4. Once the migration is success, update the database by typing the code below:
> dotnet ef database update

### 5. Please use SQL Script attached in the repository named "sql script to onrcx" and execute it on your SQL Server. This will create Orders and Customers tables and populate them with data.

### 6. Now run the code such that we can test the API endpoints.

### 7. Test your result with the endpoints below:

**For Question One:** > https://localhost:7046/api/orders/GetTotalOrderByDate/2023-01-02 (Code is written from line 22 to 37 on Repository/OrderRepository.cs)

**For Question Two:** > https://localhost:7046/api/orders/GetCustomerCountryByDate/2023-01-02 (Code is written from line 38 to 50 on Repository/OrderRepository.cs)

**For Question Three:** > https://localhost:7046/api/orders/GetOrderNameByDate/2023-01-02 (Code is written from line 52 to 65 on Repository/OrderRepository.cs)


 
