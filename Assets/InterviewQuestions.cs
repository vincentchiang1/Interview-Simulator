using System;
using System.Collections.Generic;

namespace Assets
{
	public class InterviewQuestions
	{
        public InterviewQuestions()
        {
        }

		public List<string> BehaviouralQuestions =>
            new List<string>
            {
                "Tell me about a time when you had a conflict with a co-worker, how did you solve it?",
                "Tell me about the project you are most proud of, and what your contribution was.",
                "Tell me about a time when you received negative feedback, how did you deal with it?",
                "What elements are necessary for a successful team and why?",
                "Describe a time when you were able to improve upon the design that was originally suggested."
            };

        public List<string> TechnicalNonCodingQuestions =>
            new List<string> {
                "What is the difference between a queue and a stack?",
                "What is the difference between storing data on the heap vs. on the stack?",
                "How would you test a pen?",
                "What is the time complexity of a Binary Search?",
                "How do you find if two given rectangles overlap?",
                "Given a big string of characters, how to efficiently find the first unique character in it?"

            };

        public List<Tuple<string, string>> TechnicalCodingQuestions =>
            new List<Tuple<string, string>> {
                Tuple.Create("1","Write a function that reverses a string. The input string is given as an array of characters char[]."),
                Tuple.Create("2","Given an array of integers, return indices of the two numbers such that they add up to a specific target."),
                Tuple.Create("3","Given a string, find the first non-repeating character in it and return it's index. If it doesn't exist, return -1."),
                Tuple.Create("4","Write a program that outputs the string representation of numbers from 1 to n. But for multiples of three it should output “Fizz” instead of the number and for the multiples of five output “Buzz”. For numbers which are multiples of both three and five output “FizzBuzz”."),
                Tuple.Create("5","Reverse a singly linked list."),
                Tuple.Create("6","Given a binary tree, find its maximum depth."),
                Tuple.Create("7","Given an array containing n distinct numbers taken from 0, 1, 2, ..., n, find the one that is missing from the array."),
                Tuple.Create("8","Given an array of size n, find the majority element. The majority element is the element that appears more than ⌊ n/2 ⌋times."),
                Tuple.Create("9","Given an array of integers, find if the array contains any duplicates."),
                Tuple.Create("10","Given a sorted array nums, remove the duplicates in-place such that each element appear only once and return the new length."),
                Tuple.Create("11","Given an array nums, write a function to move all 0's to the end of it while maintaining the relative order of the non-zero elements.")
            };
    }
}
