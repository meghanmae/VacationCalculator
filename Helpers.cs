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

        /*
           LengthofContinuousService   |   AnnualPaidVacationBenefit    |    AccrualRateperPayPeriod 
          -------------------------------------------------------------------------------------------
          Up to 1 year                          10 days (80hrs)                      3hrs 20m
          Each additional year                  +1 day (8hrs)                         +20m
          Maximum                               20 days (160hrs)                     6hrs 40m
         */
        private const double BASE_VACATION_HRS = 80;
        private const double BASE_ACCRUAL_RATE_HRS = (3.3333333333333333 * 2);

        private const double ADDITIONAL_VACATION_PER_YR_HRS = 8;
        private const double ADDITIONAL_ACCRUAL_RATE_PER_YR_HRS = (0.3333333333333333 * 2);

        private const double MAX_VACATION_HRS = 160;
        private const double MAX_ACCRUAL_RATE_HRS = (6.6666666666666666 * 2);

        public static double GetVacationHours(DateTime startDate, DateTime endDate)
        {
            // Get number of months total
            if (startDate > endDate) return 0;
            int months = MonthDiff(startDate, endDate);

            int i = 0;
            double vacationTime = 0;

            while(months > 0)
            {
                var period = months > 12 ? 12 : months;

                var accrualRate = BASE_ACCRUAL_RATE_HRS + ADDITIONAL_ACCRUAL_RATE_PER_YR_HRS * i;
                var actualAccrualRate = accrualRate > MAX_ACCRUAL_RATE_HRS ? MAX_ACCRUAL_RATE_HRS : accrualRate;
                vacationTime += (actualAccrualRate) * period;

                months -= 12;
                i++;
            }

            return vacationTime;
        }

        public static double GetFutureVacationHorusFromCurrentVacationTime(DateTime startDate, DateTime endDate, double currentVacation, double daysOff = 0)
        {
            //// Get number of months total
            //if (startDate > endDate) return 0;
            //int months = MonthDiff(DateTime.Now, endDate);

            //// Get number of years after start date for extra time
            //LocalDate start = new(startDate.Year, startDate.Month, startDate.Day);
            //LocalDate end = new(endDate.Year, endDate.Month, endDate.Day);
            //int years = Period.Between(start, end).Years;

            //double futureTime = (months * ((years * ADDITIONAL_VACATION_PER_YR_HRS) + (ADDITIONAL_ACCRUAL_RATE_PER_YR_HRS * 2))) + currentVacation;
            //return futureTime - (daysOff * 8);


            var totalAccruedVacation = GetVacationHours(startDate, DateTime.Now);
            var vacationUsed = totalAccruedVacation - currentVacation;

            var futureAccruedVacation = GetVacationHours(startDate, endDate);

            return futureAccruedVacation - (vacationUsed + daysOff * 8);
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
