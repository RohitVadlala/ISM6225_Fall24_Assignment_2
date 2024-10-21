﻿using System;
using System.Collections.Generic;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: Find Missing Numbers in Array
            Console.WriteLine("Question 1:");
            int[] nums1 = { 4, 3, 2, 7, 8, 2, 3, 1 };
            IList<int> missingNumbers = FindMissingNumbers(nums1);
            Console.WriteLine(string.Join(",", missingNumbers));

            // Question 2: Sort Array by Parity
            Console.WriteLine("Question 2:");
            int[] nums2 = { 3, 1, 2, 4 };
            int[] sortedArray = SortArrayByParity(nums2);
            Console.WriteLine(string.Join(",", sortedArray));

            // Question 3: Two Sum
            Console.WriteLine("Question 3:");
            int[] nums3 = { 2, 7, 11, 15 };
            int target = 9;
            int[] indices = TwoSum(nums3, target);
            Console.WriteLine(string.Join(",", indices));

            // Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 2, 3, 4 };
            int maxProduct = MaximumProduct(nums4);
            Console.WriteLine(maxProduct);

            // Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5:");
            int decimalNumber = 42;
            string binary = DecimalToBinary(decimalNumber);
            Console.WriteLine(binary);

            // Question 6: Find Minimum in Rotated Sorted Array
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 4, 5, 1, 2 };
            int minElement = FindMin(nums5);
            Console.WriteLine(minElement);

            // Question 7: Palindrome Number
            Console.WriteLine("Question 7:");
            int palindromeNumber = 121;
            bool isPalindrome = IsPalindrome(palindromeNumber);
            Console.WriteLine(isPalindrome);

            // Question 8: Fibonacci Number
            Console.WriteLine("Question 8:");
            int n = 4;
            int fibonacciNumber = Fibonacci(n);
            Console.WriteLine(fibonacciNumber);
        }

        // Question 1: Find Missing Numbers in Array
        public static IList<int> FindMissingNumbers(int[] nums)
        {
            try
            {
                List<int> missingNumbers = new List<int>();
                // Mark numbers by using their values as indices
                for (int i = 0; i < nums.Length; i++)
                {
                    int val = Math.Abs(nums[i]) - 1; // Adjust to 0-index
                    if (nums[val] > 0) nums[val] = -nums[val]; // Mark as negative to indicate presence
                }
                // Find indices that are still positive, indicating missing numbers
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] > 0) missingNumbers.Add(i + 1); // Add missing number (1-based index)
                }
                return missingNumbers;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }

        
        // Question 2: Sort Array by Parity
        public static int[] SortArrayByParity(int[] nums)
        {
            try
            {
                // Lists to store even and odd numbers
                List<int> evens = new List<int>();
                List<int> odds = new List<int>();

                // Traverse the array and segregate even and odd numbers
                foreach (int num in nums)
                {
                    if (num % 2 == 0)
                        evens.Add(num); // Add even numbers to the evens list
                    else
                        odds.Add(num);  // Add odd numbers to the odds list
                }

                // Combine even numbers followed by odd numbers
                evens.AddRange(odds);

                return evens.ToArray(); // Convert list to array and return
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }



        // Question 3: Two Sum
        public static int[] TwoSum(int[] nums, int target)
        {
            try
            {
                Dictionary<int, int> map = new Dictionary<int, int>(); // Map to store value and index
                for (int i = 0; i < nums.Length; i++)
                {
                    int complement = target - nums[i]; // Calculate complement
                    if (map.ContainsKey(complement))
                    {
                        return new int[] { map[complement], i }; // Return indices if complement exists
                    }
                    map[nums[i]] = i; // Add current number and index to map
                }
                return new int[0]; // Return empty array if no solution
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }

        // Question 4: Find Maximum Product of Three Numbers
        public static int MaximumProduct(int[] nums)
        {
            try
            {
                Array.Sort(nums); // Sort the array
                int n = nums.Length;
                // Compare the product of the two smallest (possibly negative) numbers with the largest number
                // And the product of the three largest numbers
                return Math.Max(nums[0] * nums[1] * nums[n - 1], nums[n - 1] * nums[n - 2] * nums[n - 3]);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }

        // Question 5: Decimal to Binary Conversion
        public static string DecimalToBinary(int decimalNumber)
        {
            try
            {
                if (decimalNumber == 0) return "0"; // Handle the case for 0
                string binary = "";
                while (decimalNumber > 0)
                {
                    binary = (decimalNumber % 2) + binary; // Append remainder to binary string
                    decimalNumber /= 2; // Divide the number by 2
                }
                return binary;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }

        // Question 6: Find Minimum in Rotated Sorted Array
        public static int FindMin(int[] nums)
        {
            try
            {
                int left = 0, right = nums.Length - 1;
                while (left < right)
                {
                    int mid = left + (right - left) / 2; // Find middle element
                    if (nums[mid] > nums[right])
                        left = mid + 1; // If mid is greater than right, minimum is in the right half
                    else
                        right = mid; // Otherwise, it's in the left half
                }
                return nums[left]; // Return the minimum element
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }

        // Question 7: Palindrome Number
        public static bool IsPalindrome(int x)
        {
            try
            {
                if (x < 0) return false; // Negative numbers are not palindromes
                int original = x, reversed = 0;
                while (x > 0)
                {
                    reversed = reversed * 10 + x % 10; // Reverse the number
                    x /= 10;
                }
                return original == reversed; // Check if the original is equal to the reversed number
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }

        // Question 8: Fibonacci Number
        public static int Fibonacci(int n)
        {
            try
            {
                if (n <= 1) return n; // Base cases for 0 and 1
                return Fibonacci(n - 1) + Fibonacci(n - 2); // Recursive case
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }
    }
}
