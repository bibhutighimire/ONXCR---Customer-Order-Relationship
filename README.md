# ONXCR---Customer-Order-Relationship
This project is built for the purpose of assessment for ONRCX. The project is built using C# ASP.NET CORE 7 WEB API and SQL server for the backend and database respectively. The project uses an interface layer, repository pattern, and dependency injection design framework to decouple the classes. 

This project has 2 tables, Customers and Orders.  Orders table has the primary key of Customers table as the foreign key. This way they are connected to each other can solve 3 questions provided in the assessment. The questions are mentioned below:

i. how much order was placed on “2023-01-02”?
Answer:
        public async Task<float?> GetTotalOrderByDate(DateTime date)
        {
            //LINQ query below connects woth Orders table and using where() clause it filters rows and gets data whose date of order was passed in parameter. Then using SumAsync() it sums the AmountOfOrder of all the rows. This is asynchronous call. The sum of AmountOfOrder is stored in orders and checked for null reference error and returned.

            float? orders = (float)Convert.ToDecimal(await _context.Orders.Where(x => x.DateOfOrder == date).SumAsync(y => y.AmountOfOrder));

            if (orders.Value == 0)
            {
                return null;
            }

            return orders;
        }

ii. From which countries the order was placed on “2023-01-02”?
Answer:

 public async Task<List<string?>?> GetCustomerCountryByDate(DateTime date)
        {
            //LINQ query below connects woth Orders table and using where() clause it filters rows and gets data whose date of order was passed in parameter. Then using Include() it does quick eager loading to get data from Customer table whose Id is equal to CustomerId in Order table. Finally using Select() it gets data of only the Country column. Since this is asynchronous call, it's using ToListAsync() to list the data and store in List of string.

            List<string?>? orders = await _context.Orders.Where(x => x.DateOfOrder == date).Include(z => z.Customer).Select(s => s.Customer!.Country).ToListAsync();
            if (orders == null)
            {
                return null;
            }
            return orders;
        }

iii. Who ordered on “2023-01-02”?
Answer:

public async Task<List<string?>?> GetOrderNameByDate(DateTime date)
        {
            //LINQ query below connects woth Orders table and using where() clause it filters rows and gets data whose date od order was passed in parameter. Then using Include() it does quick eager loading to get data from Customer table whose Id is equal to CustomerId in Order table. Finally using Select() it gets data of only the Name column. Since this is asynchronous call, it's using ToListAsync() to list the data and store in List of string.
            List<string?>? orders = await _context.Orders.Where(x => x.DateOfOrder == date).Include(z => z.Customer).Select(s => s.Customer!.Name).ToListAsync();
            if (orders == null)
            {
                return null;
            }
            return orders;

        }
 
