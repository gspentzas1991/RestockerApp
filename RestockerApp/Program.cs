using System;

namespace RestockerApp
{
    public class Restocker
    {
        static void Main()
        {
            var stock = new List<int>() { 0, 2, 2 };
            var supplierStock = new List<int>() { 0, 0, 2, 3 };
            int demand = 2;
            int expectedResult = 3;
            Console.WriteLine($"Expected result: {expectedResult} ");
            Console.WriteLine($"Actual result: {Restock(stock, supplierStock, demand)} ");
        }

        public static int Restock(List<int> stock, List<int> supplierStock, int demand)
        {
            var stockToBuy = 0;
            //The higherst expiration date of supplier stock. This is the maximum possible day we should check
            var maxSupplierExpiration = supplierStock.Max();
            var orderedStock = stock.OrderBy(x => x).ToList();
            var orderedSupplierStock = supplierStock.OrderBy(x => x).ToList();
            //counters that shows which stock item we checked last
            var stockCounter = 0;
            var supplierCounter = 0;
            //For each possible day we make sure we have enough ingredients to meet demand. If not we buy the closest expiring
            //ingredient from the supplier
            for (int dayCounter = 0; dayCounter < maxSupplierExpiration; dayCounter++)
            {
                //The expiration day that we search for in the items. We try to get the items that expire the soonest
                //either from our stock or the supplier
                var expirationDayToCheck = dayCounter;
                //The amount of stock we gathered for the day
                var dailyStockUsed = 0;
                do
                {

                    //We check our stock for supplies expiring at expirationDayToCheck, until we fill our demand, or until supplies stop expiring
                    while (dailyStockUsed < demand && stockCounter < orderedStock.Count && orderedStock[stockCounter] <= expirationDayToCheck)
                    {
                        //ignore expired items
                        if (orderedStock[stockCounter] < dayCounter)
                        {
                            stockCounter++;
                            continue;
                        }
                        if (orderedStock[stockCounter] == expirationDayToCheck)
                        {
                            dailyStockUsed++;
                            stockCounter++;
                        }
                    }
                    //If we didn't use enough items from the stock for the day, we check the supplier
                    if (dailyStockUsed < demand)
                    {
                        while (dailyStockUsed < demand && supplierCounter < orderedSupplierStock.Count && orderedSupplierStock[supplierCounter] <= expirationDayToCheck)
                        {
                            //ignore expired items
                            if (orderedSupplierStock[supplierCounter] < dayCounter)
                            {
                                supplierCounter++;
                                continue;
                            }
                            if (orderedSupplierStock[supplierCounter] == expirationDayToCheck)
                            {
                                supplierCounter++;
                                dailyStockUsed++;
                                stockToBuy++;
                            }
                        }
                    }
                    //If we searched both stocks, then we return our result
                    if (stockCounter == orderedStock.Count && supplierCounter == orderedSupplierStock.Count)
                    {
                        return stockToBuy;
                    }
                    expirationDayToCheck++;
                } while (dailyStockUsed < demand);


            }
            return stockToBuy;
        }
    }
}
