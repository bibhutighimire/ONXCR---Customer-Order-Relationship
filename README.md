# ONXCR---Customer-Order-Relationship
This project is built for the purpose of assessment for ONRCX. The project is built using C# ASP.NET CORE 7 WEB API and SQL server for the backend and database respectively. The project uses an interface layer, repository pattern, and dependency injection design framework to decouple the classes. 

This project has 2 tables, Customers and Orders.  Orders table has the primary key of Customers table as the foreign key. This way they are connected to each other can solve 3 questions provided in the assessment. The questions are mentioned below:

i. how much order was placed on “2023-01-02”?
Answer:
        public async Task<float?> GetTotalOrderByDate(DateTime date)
        {
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
           List<string?>? orders = await _context.Orders.Where(x => x.DateOfOrder == date).Include(z => z.Customer).Select(s => s.Customer!.Name).ToListAsync();
            if (orders == null)
            {
                return null;
            }
            return orders;

        }
 
