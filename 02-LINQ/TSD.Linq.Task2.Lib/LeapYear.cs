using System;

namespace TSD.Linq.Task2.Lib {

    public class LeapYear {
	    public bool calculateLeapYear(int year) => (year % 4 == 0 && year % 100 != 0) || year % 400 == 0;
    
	    public static void Main() {
    	    int year = 2000;
            LeapYear calculator = new LeapYear();
            Console.WriteLine(calculator.calculateLeapYear(year));
        }
    }
}