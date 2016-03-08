using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaxProfit
{
    public class MaxProfit
    {
        /// <summary>
        /// Calcultate the maximum profit that could have been made
        /// Sample data sets
        /// [10, 7, 5, 8, 11, 9] -> 6
        /// [10, 9, 8, 7, 6, 5, 4] -> -1
        /// [10, 9, 8, 6, 5, 4] -> -1
        /// [12.5, 4.75, 13.25, 6.35, 21.01] -> 16.26
        /// </summary>
        /// <param name="stock_price_yesterday">An array of the stock price during the day</param>
        /// <returns>The maximum profit that could have been made</returns>
        public static decimal get_max_profit(decimal[] stock_price_yesterday)
        {
            //Declare a list to hold the maximum profit that could have been realized for every time interval
            List<decimal> profit = new List<decimal>();
            //Iterate throug yesterday's prices
            for (int index = 1; index < stock_price_yesterday.Length; index++)
            {
                //Take the starting price
                decimal price = stock_price_yesterday[index - 1];
                //Create a colletion (enumeralble) of the stock prices after the starting price
                IEnumerable<decimal> stock_price_remaider = stock_price_yesterday.Skip(index);
                //Add the maximum profit to the list of possible profits (the maximum of the remainder of the array minus the starting price)
                profit.Add(stock_price_remaider.Max() - price);
            }
            //Return the maximum value in the list of possible profits
            return profit.Max();
        }
    }
}
