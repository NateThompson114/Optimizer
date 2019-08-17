using System;
using System.Collections.Generic;
using System.Text;

namespace Optimizer.Methods
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Checks if a DateTime is in a block of time.
        /// </summary>
        /// <param name="dateToCheck">DateTime to check.</param>
        /// <param name="startDate">Start of DateTime block.</param>
        /// <param name="endDate">End of DateTime block.</param>
        /// <returns>true if the date is in the timeblock or false if it is not.</returns>
        public static bool InRange(this DateTime dateToCheck, DateTime startDate, DateTime endDate) => dateToCheck >= startDate && dateToCheck < endDate;
    }
}
