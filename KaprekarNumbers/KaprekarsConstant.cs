using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaprekarNumbers
{

    public class KaprekarsConstant
    {
        private static int[] invalidNumList = new int[10] { 0, 1111, 2222, 3333, 4444, 5555, 6666, 7777, 8888, 9999 };
       public static void Main(string[] args)
        {
            
        }

        /* This class will eventually be used to print out a text document that contains al  the numebr s with the highest routine
         
         */
        private static void printHighestRoutineNumbers()
        {
            

            int highestRoutine = 0;
            List<string> highestRoutineNumbers = new List<string>();

            for (int i = 0; i < 10000; i++)
            {
                bool isValid = true;
                foreach (int nonValidNum in invalidNumList)
                { 
                    if (i == nonValidNum)
                    {
                        isValid = false;
                    }
                }

                if (isValid == true)
                {
                    int k_num = kaprekarsRoutine(i);
                    if (k_num > highestRoutine)
                    {
                        highestRoutineNumbers.Clear();
                        highestRoutine = k_num;
                        highestRoutineNumbers.Add(i.ToString());
                    }else if(k_num == highestRoutine)
                    {
                        highestRoutineNumbers.Add(i.ToString());
                    }
                }
            }


          
            //write all the numbers to a file 
            System.IO.File.WriteAllLines(@".\routine_numbers.txt", highestRoutineNumbers);
        }

        public static int kaprekarsRoutine(int num)
        {
            foreach(int i in invalidNumList)
            {
                if (num == i)
                {
                    throw new InvalidOperationException();
                }
            }

            const int KCONST = 6174;
            int routineNum = 0;

            int result = num;

            while (result != KCONST)
            {
                routineNum++; 
                result = ((getDescendingOrder(result)) - (getAscendingOrder(result)));
            }
            return routineNum;
        }
        //Write a function that, given a 4-digit number, returns the largest 
        //digit in that number. Numbers between 0 and 999 are counted as 4-digit 
        //numbers with leading 0's.
        private static int getLargest(List<int> numList)
        {
            int largest = 0;
            foreach (int i in numList)
            {
                if (i > largest)
                {
                    largest = i;
                }
            }
            return largest;
        }

        //Write a function that, given a 4-digit number, returns the largest 
        //digit in that number. Numbers between 0 and 999 are counted as 4-digit 
        //numbers with leading 0's.
        private static int getSmallest(List<int> numList)
        {
            int smallest = 10;
            foreach (int i in numList)
            {
                if (i < smallest)
                {
                    smallest = i;
                }
            }
            return smallest;
        }

        //Takes in a number and returns a list of all the individual digits within the number
        private static List<int> getDigitList(int number)
        {

            var num = number;
            var numList = new List<int>();

            for (int i = 4; i > 0; i--)
            {
                var lastNum = (int)num % 10;
                numList.Add(lastNum);
                num = num / 10;
            }
            return numList;
            
        }

        //Prints all the digits the list contains
        private static void printList(List<int> numList)
        {
            foreach (var i in numList)
            {
                Console.Write(i + " ");
            }
        }

        //Takes in a number and returns it in descending order.
        private static int getDescendingOrder(int num)
        {
            List<int> digitList = getDigitList(num);
            List<int> descending = new List<int>();

            var digitNum = digitList.Count;

            while (digitNum > 0)
            {
                int largest = getLargest(digitList);
                descending.Add(largest);
                digitList.Remove(largest);
                digitNum--;
            }

            int orderedNum = listToNumberConvert(descending);
            return orderedNum;
        }
        //Gets the ascending order of the number
        private static int getAscendingOrder(int num)
        {
            List<int> digitList = getDigitList(num);
            List<int> ascending = new List<int>();

            var digitNum = digitList.Count;

            while (digitNum > 0)
            {
                int smallest = getSmallest(digitList);
                ascending.Add(smallest);
                digitList.Remove(smallest);
                digitNum--;
            }

            int orderedNum = listToNumberConvert(ascending);
            return orderedNum;
        }

        //helper class that converts lists to numbers
        private static int listToNumberConvert(List<int> numList)
        {
            double place = Math.Pow( 10, (numList.Count - 1) );
            int finalNum = 0;
            foreach (int i in numList)
            {
                finalNum += (i * (int)place);
                place = place / 10;
            }
            return finalNum;
        }
    }
}
