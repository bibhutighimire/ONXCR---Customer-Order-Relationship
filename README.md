# ONXCR---Customer-Order-Relationship
This project is built for the purpose of assessment for ONRCX. The project is built using C# ASP.NET CORE 7 WEB API and SQL server for the backend and database respectively. The project uses an interface layer, repository pattern, and dependency injection design framework to decouple the classes. 

This project has 2 tables, Customers and Orders.  Orders table has the primary key of Customers table as the foreign key. 
The image below shows their relationship as well as data in the table that we are going to work on.
![image](https://user-images.githubusercontent.com/12985759/227745583-4168edd9-4d64-4c50-82f4-712b2f755e47.png)

The image below shows endpoint to get data from the table Customers
![image](https://user-images.githubusercontent.com/12985759/227745618-78db1bb4-e740-45a2-b27a-77409029b312.png)

The image below shows endpoint to get data from the table Orders
![image](https://user-images.githubusercontent.com/12985759/227745628-a29b17fc-aa25-446a-a192-30c5812ad8a9.png)

This way they are connected to each other and can solve 3 questions provided in the assessment. The questions are mentioned below:

**i. how much order was placed on “2023-01-02”?**

Answer:
Code is written from line 22 to 37 on Repository/OrderRepository.cs

![image](https://user-images.githubusercontent.com/12985759/227745486-11a49f8a-a595-444c-a285-cbf2ab81997f.png)
        
**ii. From which countries the order was placed on “2023-01-02”?**

Answer:
Code is written from line 38 to 50 on Repository/OrderRepository.cs

![image](https://user-images.githubusercontent.com/12985759/227745497-690ef833-3bc1-4789-b196-5909ab607341.png)

**iii. Who ordered on “2023-01-02”?**

Answer:
Code is written from line 52 to 65 on Repository/OrderRepository.cs

![image](https://user-images.githubusercontent.com/12985759/227745506-ad1cd787-f393-4c6e-9bad-b9851d078df1.png)

**Thanks for reading,
Bibhuti**

 
