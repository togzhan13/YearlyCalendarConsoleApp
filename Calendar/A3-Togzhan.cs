using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Calendar
{
    internal class Program
    {
        private static int firstDayofMonth;

        enum Month
        {
            January = 1, February, March, April, May, June, July, August, September, October, November, December
        }
        enum DayOfWeek
        {
            Sunday = 0, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday
        }

        static void Main(string[] args)
        {
            //Declaring variables
            int year, firstDayOfWeek;
            bool validYear = false, validDayOfWeek = false;
            int x, y, day;
            int daysInMonth = 0;
            int firstDayOfMonth = 0;
            int quit;

            do
            {
                
                //Prompting the user for year information input.
                WriteLine("Enter the year for which you wish to generate the calendar: ");
                /*
                year = Convert.ToInt32(Console.ReadLine());
                //Checking validation for year information input.
                if (year == 0)
                {
                    validYear = true;
                }
                else
                {
                    Console.WriteLine("Invalid year. Please enter a year in the right format.");
                }
                */

                while(! int.TryParse(ReadLine(), out year))
                {
                    Console.WriteLine("Invalid year. Please enter a year in the right format.");
                    Console.WriteLine("Reenter the year for which you wish to generate the calendar: ");
                }

                while (!int.TryParse(ReadLine(), out firstDayOfWeek) && (firstDayOfWeek < 0 || firstDayOfWeek > 6))
                {
                    Console.WriteLine("Invalid year. Please enter a year in the right format.");
                    Console.WriteLine("Reenter the year for which you wish to generate the calendar: ");
                }

                //Prompt the user for the first day of Januray in the week input.
                Console.WriteLine("Enter the day of the week that January first is on: ");
                firstDayOfWeek = Convert.ToInt32(Console.ReadLine());

                //Checking validation for the first day of Januray in the week input.
                if (firstDayOfWeek == 0)
                {
                    if (firstDayOfWeek >= 0 && firstDayOfWeek <= 6)
                    {
                        validDayOfWeek = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid day. Please enter a number between 0 and 6 for the day of the week.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input for day of the week. Please enter the valid day.");
                }

                Console.WriteLine("\nCalendar for year {0}\n", year);

                //Going throught each month.
                for (x = 1; x <= 12; x++)
                {
                    //Creating all 12 months with the days.
                    switch ((Month)x)
                    {
                        //Grouping case of months that has 31 days.
                        case Month.January:
                        case Month.March:
                        case Month.May:
                        case Month.July:
                        case Month.August:
                        case Month.October:
                        case Month.December:
                            daysInMonth = 31;
                            break;

                        //Grouping case of months that has 30 days.
                        case Month.April:
                        case Month.June:
                        case Month.September:
                        case Month.November:
                            daysInMonth = 30;
                            break;

                        //Grouping case of months that has 29 or 28 days.
                        //Checking for leap year to set up correct number of days in February.
                        case Month.February:
                            if ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0)
                            {
                                daysInMonth = 29;
                            }
                            else
                            {
                                daysInMonth = 28;
                            }
                            break;

                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                    Console.WriteLine("{0}\nSun\tMon\tTue\tWed\tThu\tFri\tSat", (Month)x);
                    //int spaceCount = 0;
                    for (y = 0; y < firstDayOfMonth; y++)
                    {
                        Console.Write("\t");
                        //++spaceCount;
                    }

                    for (day = (1+firstDayOfMonth); day <= (firstDayOfMonth + daysInMonth) ; day++)
                    {
                        Console.Write("{0}\t", (day-firstDayOfMonth));

                        //if ((firstDayOfWeek + day) % 7 == 0)
                        if(day % 7 == 0)
                        {
                            Console.WriteLine();
                        }
              
                    }

                    firstDayOfMonth = (firstDayOfMonth + daysInMonth) % 7;

                    Console.WriteLine("\n");
                }
                WriteLine("Do you want to display another year's calendar? (1 to quit)");
                quit = Convert.ToInt32(ReadLine());

            } while (quit != 1);
        } 
    }
}
