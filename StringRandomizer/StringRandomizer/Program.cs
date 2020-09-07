using System;
using System.Diagnostics;
using System.Linq;


namespace StringRandomizer
{
    class Program
    {
        public static string recursionItem { get; set; }
        public static string recursionDestination { get; set; }
        public static Random random = new Random();

        static void Main(string[] args)
        {
            #region variables
            var timer = new Stopwatch();   
            var data = Data.wordsSetOne;
            var data2 = Data.wordsSetTwo;
            #endregion variables

            #region printing results
            //foreach (var item in data) { Console.WriteLine("{0,-20}{1,-20}", item, randomizerImplementationOne(item)); }
            //foreach (var item in data) { Console.WriteLine("{0,-25}{1,-25}", item, randomizerImplementationOne(item)); }
            //foreach (var item in data) { Console.WriteLine("{0,-20}{1,-20}", item, randomizerImplementationTwo(item)); }
            //foreach (var item in data) { Console.WriteLine("{0,-25}{1,-25}", item, randomizerImplementationTwo(item)); }
            //foreach (var item in data) { Console.WriteLine("{0,-20}{1,-20}", item, randomizerImplementationThree(item)); }
            //foreach (var item in data2) { Console.WriteLine("{0,-25}{1,-25}", item, randomizerImplementationThree(item)); }
            #endregion printing results

            //Implementation 1
            Console.WriteLine("Implementation 1, 1-1 swap:");
            timer.Start();
            foreach (var item in data) { randomizerImplementationOne(item); }
            foreach (var item in data2) { randomizerImplementationOne(item); }
            timer.Stop();
            Console.WriteLine("Diagnostics:");
            Console.WriteLine(timer.ElapsedMilliseconds + "ms");


            //Implementation 2
            Console.WriteLine("\nImplementation 2, LINQ:");
            timer.Restart();
            foreach (var item in data) { randomizerImplementationTwo(item); }
            foreach (var item in data2) { randomizerImplementationTwo(item); }
            timer.Stop();
            Console.WriteLine("Diagnostics:");
            Console.WriteLine(timer.ElapsedMilliseconds + "ms");


            //Implementation 3
            Console.WriteLine("\nImplementation 3, Recursion: \n");
            timer.Restart();
            foreach (var item in data) { randomizerImplementationThree(item); }
            foreach (var item in data2) { randomizerImplementationThree(item); }
            timer.Stop();
            Console.WriteLine("Diagnostics:");
            Console.WriteLine(timer.ElapsedMilliseconds + "ms");


            //Allows for readable results
            Console.ReadKey();
        }



        /// <summary>
        /// Shuffles the characters inside an string for the length of the input, returning the randomized result
        /// </summary>
        /// <param name="input">String to randomize</param>
        /// <returns>String randomized</returns>
        public static string randomizerImplementationOne(string input)
        {
            char[] data = input.ToCharArray();
            for (int i = 0; i < input.Length; i++)
            {
                int ran = random.Next(input.Length - 1);
                var hold = data[ran];
                data[ran] = data[i];
                data[i] = hold;
            }

            string output = new string(data);
            return output;
        }


        /// <summary>
        /// Uses LINQ and the OrderBy extension method to randomly order the array
        /// </summary>
        /// <param name="input">String to randomize</param>
        /// <returns>String randomized</returns>
        public static string randomizerImplementationTwo(string input)
        {
            string output = new string(input.ToCharArray().OrderBy(x => (random.Next(2) % 2 == 0)).ToArray());
            return output;
        }


        /// <summary>
        /// Accepts a string input, which is set to a class string, which is randomized into a new return string
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string randomizerImplementationThree(string input)
        {
            recursionItem = input; 
            recursionDestination = "";
            recursion(recursionItem.Length);

            return recursionDestination;
        }


        /// <summary>
        /// Recursive function to set public string to random characters removed from another public string
        /// </summary>
        /// <param name="counter">Length of array</param>
        /// <returns>randomized string</returns>
        private static string recursion(int counter)
        {
            if (counter == 0) return "";
            else
            {
                int item = random.Next(0, counter);
                recursionDestination += recursionItem[item];
                recursionItem = recursionItem.Remove(item, 1);
                return recursion(counter - 1);
            }
        }

    }

}
