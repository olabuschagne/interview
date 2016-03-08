using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace MaxProfit
{
    public class MatchingDates
    {
        /// <summary>
        /// find the valid training days for the provided list of employee availabilities
        /// 
        /// Test Data:
        /// Employee 1: Days 1,2,5
        /// Employee 2: Days 2,3,7
        /// Employee 3: Days 5,7,9
        /// Result: 2,5
        /// 
        /// Employee 1: Days 3,12,15
        /// Employee 2: Days 1,2,9
        /// Employee 3: Days 4,6 
        /// Result: 1,3,4
        /// 
        /// Employee 1: Days 3,12,15
        /// Employee 2: Days 1,2,9
        /// Employee 3: Days 4,6 
        /// Employee 4: Days 6,11,18 
        /// Result: 1,3,6
        /// 
        /// Employee 1: Days 3,12,15,18
        /// Employee 2: Days 1,2,9
        /// Employee 3: Days 4,6 
        /// Employee 4: Days 7,11,18 
        /// Result: 1,4,18
        /// 
        /// Employee 1: Days 1,2,7
        /// Employee 2: Days 2,3,7
        /// Employee 3: Days 5,7,9
        /// Result: 7
        /// 
        /// </summary>
        /// <param name="employeeAvailability">A list of listst of available days fore each employee</param>
        /// <returns></returns>
        public static SortedSet<int> findValidTrainingDays(List<List<int>> employeeAvailability)
        {
            //build a collection of who are available on the dates provided
            Dictionary<int, List<int>> availableDays = new Dictionary<int, List<int>>();
            //for every employee
            for (int index = 0; index < employeeAvailability.Count; index++)
            {
                //for every day
                for (int index2 = 0; index2 < employeeAvailability[index].Count; index2++)
                {
                    int day = employeeAvailability[index][index2];
                    //ensure that there is a member for the day in the available days collection
                    if (!availableDays.ContainsKey(day))
                    {
                        availableDays.Add(day, new List<int>());
                    }
                    //Add the person's day to the list of the day in the available days
                    availableDays[day].Add(index);
                }
            }

            SortedSet<int> retVal = new SortedSet<int>();

            do
            {
                //find the day on which most employees are available
                int maxDay = 0;
                int maxCount = 0;
                foreach (int day in availableDays.Keys)
                {
                    if (availableDays[day].Count > maxCount)
                    {
                        maxDay = day;
                        maxCount = availableDays[day].Count;
                    }
                }

                //remove the employees from the other days to ensure that a person is only schedule once
                foreach (int index in availableDays.Keys)
                {
                    if (index != maxDay)
                    {
                        //for every person in the max day list
                        foreach (int person in availableDays[maxDay])
                        {
                            //Remove the person form the list
                            availableDays[index].Remove(person);
                        }
                    }
                }

                //remove the max day list from the available days
                availableDays.Remove(maxDay);

                //remove any day where there are no more persons in the list
                int[] dayKeys = availableDays.Keys.ToArray();
                foreach (int day in dayKeys)
                {
                    if (availableDays[day].Count == 0)
                        availableDays.Remove(day);
                }

                //add the day to the return value
                retVal.Add(maxDay);
            }
            while (availableDays.Count > 0);
            return retVal;
        }

    }
}
