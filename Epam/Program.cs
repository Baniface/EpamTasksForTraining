using System;
using System.Collections.Generic;
using System.Linq;

namespace Epam
{
	class Program
	{
		static void Main(string[] args)
		{
			{
				////Test GetGCD
				//Console.WriteLine(GetGCD(2147483646, 21474));
				//Console.WriteLine(GetGCD(36, 16));
				//Console.WriteLine(GetGCD(0, 5));
				//Console.WriteLine(GetGCD(10, 100));
				//Console.WriteLine(GetGCD(19, 11));
				//Console.WriteLine(GetGCD(256, 64));
			}

			{
				////Test GetCountVowels & Test OrderStringsByLength
				//string[] arr = new string[] { "qwert", "yuio", "p", "asd", "fghjkl", "zxc", "vbnm" };
				//for (int i = 0; i < arr.Length; i++)
				//{
				//	Console.WriteLine(arr[i] + ": " + GetCountVowels(arr[i]));
				//}

				//OrderStringsByLength(arr);
				//for (int i = 0; i < arr.Length; i++)
				//{
				//	Console.WriteLine(arr[i]);
				//}
			}

			{
				////Test RemoveDuplicateWords
				//string s = "to to. toy to.. bottom who?to.do what? why, why net sqrt.world, world apple www-site site.";
				//Console.WriteLine(RemoveDuplicateWords(s));
			}

			//Console.ReadKey();
		}

		public static int GetGCD(int max, int min)
		{
			if (max == 0 || min == 0)
			{
				Console.WriteLine($"GCD does not exist for numbers {max} and {min}.");
				return 0;
			}

			if (max < min)
			{
				max = max + min;
				min = max - min;
				max = max - min;
			}

			while (max % min != 0)
			{
				if (min > max - min)
				{
					min = max - min;
					max = max - min;
				}
				else
				{
					max = max - min;
				}
			}

			return min;
		}

		public static int GetCountVowels(string s)
		{
			int count = 0;
			char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };
			for (int i = 0; i < s.Length; i++)
			{
				if (vowels.Contains(s[i]))
					count++;
			}

			return count;
		}

		public static void OrderStringsByLength(string[] arr)
		{
			string buf;
			for (int i = 0; i < arr.Length - 1; i++)
			{
				for (int j = 0; j < arr.Length - i - 1; j++)
				{
					if (arr[j].Length > arr[j + 1].Length)
					{
						buf = arr[j];
						arr[j] = arr[j + 1];
						arr[j + 1] = buf;
					}
				}
			}
		}

		public static string RemoveDuplicateWords(string s)
		{
			List<string> listWords = new List<string>();
			char[] separators = new char[]{ ' ', '.', ',', '!', '?', '-', ':', ';' };
			string currWord = "";
			for (int i = 0; i < s.Length; i++)
			{
				if(separators.Contains(s[i]))
				{
					if (currWord != "")
					{
						if (listWords.Contains(currWord))
						{
							s = s.Remove(i - currWord.Length, currWord.Length);
							i -= currWord.Length;
						}
						else
						{
							listWords.Add(currWord);
						}

						currWord = "";
					}
				}
				else
				{
					currWord += s[i];
				}
			}

			return s;
		}

	}
}
