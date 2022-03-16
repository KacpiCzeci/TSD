using System;
using System.Collections;

namespace TSD.Linq.Task2.Lib {

    public class LeapYear {
	    public bool calculateLeapYear(int year) => (year % 4 == 0 && year % 100 != 0) || year % 400 == 0;
    
	    public static void Main() {
    	    int year = 2000;
            LeapYear calculator = new LeapYear();
            Console.WriteLine(calculator.calculateLeapYear(year));
        }
    }

    public class randomCollection: Collection<int> {
        private Random rnd;

        public randomCollection(){
            this.rnd = new Random();
        }

        public void Add(int item){
            base.InsertItem(this.rnd.Next(0, base.Count()), item);
        }

        public int Get(int index){
            return base.Item(this.rnd.Next(0, index <= base.Count()? index : base.Count()));
        }

        public bool isEmpty(){
            return base.Count() == 0;
        }
    }
}