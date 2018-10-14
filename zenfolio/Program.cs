using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace zenfolio
{
    class Program
    {
        static void Main(string[] args)
        {
            //Keep looping until we see quit.
            while (true)
            {
                String input = Console.ReadLine();
                if (Regex.Match(input, "quit").Success)
                    return;
                if (Regex.Match(input, "[a-zA-z]").Success)
                    countLetters(input);
                if (Regex.Match(input, "^[0-9 ]+$").Success)
                    countNumbers(input);
            }
        }

        /// <summary>
        /// A function that prints out the count of every letter in the string. (letter being a-z)
        /// </summary>
        /// <param name="input"></param>
        private static void countLetters(string input)
        {
            input = input.ToLower();
            for (char currentChar = 'a'; currentChar <= 'z'; currentChar++)
            {
                int count = Regex.Matches(input, currentChar.ToString()).Count;
                if (count > 0)
                    Console.WriteLine(currentChar + ": " + count);
            }
        }

        /// <summary>
        /// A function that prints out the mean, meadian, mode, and rage of a set of numbers.(Who's sum < maxInt32)
        /// </summary>
        /// <param name="input"></param>
        private static void countNumbers(string input)
        {
            int[] input_nums = Array.ConvertAll(input.Split(), int.Parse);
            Console.WriteLine("mean= " + getMean(input_nums));
            Console.WriteLine("median= " + getMedian(input_nums));
            Console.WriteLine("mode= " + getMode(input_nums));
            Console.WriteLine("range= " + getRange(input_nums));
        }

        /// <summary>
        /// A function that gets the mean.
        /// </summary>
        /// <param name="input_nums"></param>
        /// <returns>The mean as a string</returns>
        private static string getMean(int[] input_nums)
        {
            return ((int)input_nums.Average()).ToString();
        }

        /// <summary>
        /// A function that gets the median.
        /// </summary>
        /// <param name="input_nums"></param>
        /// <returns>The median as a string</returns>
        private static string getMedian(int[] input_nums)
        {
            Array.Sort(input_nums);
            if (input_nums.Length % 2 == 0)//if it is even, return the average of the two middle numbers.
                return ((input_nums[input_nums.Length / 2] + input_nums[input_nums.Length / 2 - 1]) / 2).ToString();
            return ((input_nums[input_nums.Length / 2]) / 2).ToString();//else return the middle number.
        }

        /// <summary>
        /// A function that gets the mode
        /// </summary>
        /// <param name="input_nums"></param>
        /// <returns>The range as string.</returns>
        private static string getMode(int[] input_nums)
        {
            //We create an itterator that has every unique integer in it.
            //We then create a dictionary that has every unique key with it's count.
            //We then search the dictionary for a posible mode.
            //We assume a mode is only valid if there is exactly one.
            var D = new Dictionary<int, int>();
            KeyValuePair<int, int> current = new KeyValuePair<int, int>(0, 0);
            bool ok = false;

            foreach (int number in input_nums)
            {
                if (!D.ContainsKey(number))
                    D.Add(number, 0);
                D[number]++;
            }
            foreach (var num in D)
            {
                ok = !(num.Value == current.Value);

                if (num.Value > current.Value)
                    current = num;
            }
            return ok ? current.Key.ToString() : "";
        }

        /// <summary>
        /// A function that gets the range.
        /// </summary>
        /// <param name="input_nums"></param>
        /// <returns>The range as string.</returns>
        private static string getRange(int[] input_nums)
        {
            return (input_nums.Max() - input_nums.Min()).ToString();
        }

    }
}
