using NodaTime;
using System;
using System.Globalization;

namespace VacationCalculator
{
    public enum DateType
    {
        START,
        END
    }

    class Helpers
    {
        private static double MonthlyVacation { get; } = 6.667; // 6 hours and 40 minutes accumulated per month
        private static double ExtraVacationPerYear { get; } = 0.667; // Extra 40 minutes accumulated per year there

        public static double GetVacationHours(DateTime startDate, DateTime endDate, double daysOff = 0)
        {
            // Get number of months total
            if (startDate > endDate) return 0;
            int months = MonthDiff(startDate, endDate);

            // Get number of years after start date for extra time
            LocalDate start = new(startDate.Year, startDate.Month, startDate.Day);
            LocalDate end = new(endDate.Year, endDate.Month, endDate.Day);
            int years = Period.Between(start, end).Years;

            return (months * ((years * ExtraVacationPerYear) + MonthlyVacation)) - (daysOff * 8);
        }

        public static double GetFutureVacationHorusFromCurrentVacationTime(DateTime startDate, DateTime endDate, double currentVacation, double daysOff = 0)
        {
            // Get number of months total
            if (startDate > endDate) return 0;
            int months = MonthDiff(DateTime.Now, endDate);

            // Get number of years after start date for extra time
            LocalDate start = new(startDate.Year, startDate.Month, startDate.Day);
            LocalDate end = new(endDate.Year, endDate.Month, endDate.Day);
            int years = Period.Between(start, end).Years;

            double futureTime = (months * ((years * ExtraVacationPerYear) + MonthlyVacation)) + currentVacation;
            return futureTime - (daysOff * 8);
        }

        public static int MonthDiff(DateTime d1, DateTime d2)
        {
            int m1;
            int m2;

            if (d1.Month == d2.Month && d1.Year == d2.Year) return 0;

            m1 = (d2.Month - d1.Month);//for years
            m2 = (d2.Year - d1.Year) * 12; //for months


            return m1 + m2 - 1;
        }
    }
}
