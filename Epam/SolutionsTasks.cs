using System;
using System.Collections.Generic;
using System.Linq;

namespace Epam2
{
	public class SolutionsTasks
	{
		public static int GetGCD(int a, int b)
		{
			int max;
			int min;
			if (a > b)
			{
				max = a;
				min = b;
			}
			else
			{
				max = b;
				min = a;
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

		public static int GetGCD2(int a, int b)
		{
			if (a == 0 || b == 0)
			{
				Console.WriteLine("GCD does not exist.");
				return 0;
			}

			int max = Math.Max(a, b);
			int min = Math.Min(a, b);
			while (max % min != 0)
			{
				max = Math.Max(min, max - min);
				min = Math.Min(min, max - min);
			}

			return min;
		}

		public static int GetGCD3(int max, int min)
		{
			if (max == 0 || min == 0)
			{
				Console.WriteLine("GCD does not exist.");
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

		public static int GetCountVowels_old(string s)
		{
			int count = 0;
			for (int i = 0; i < s.Length; i++)
			{
				switch (s[i])
				{
					case 'a':
						count++;
						break;
					case 'e':
						count++;
						break;
					case 'i':
						count++;
						break;
					case 'o':
						count++;
						break;
					case 'u':
						count++;
						break;
				}
			}

			return count;
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

		public static string RemoveDuplicateWords_old(string s)
		{
			string[] dirtyWords = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
			IEnumerable<string> pureWords = s.Split(new char[] { ' ', '.', ',', '!', '?', '-', ':', ';' }, StringSplitOptions.RemoveEmptyEntries).Distinct();
			foreach (string pureWord in pureWords)
			{
				int wordPosition = 0;
				for (int i = 0; i < dirtyWords.Length; i++)
				{
					if (dirtyWords[i] == pureWord)
					{
						wordPosition++;
					}
					else if (dirtyWords[i].Contains(pureWord))
					{
						int startPos = dirtyWords[i].IndexOf(pureWord);
						int[] checkPositions;
						if (startPos == 0)
						{
							checkPositions = new int[] { pureWord.Length };
						}
						else if (startPos + pureWord.Length == dirtyWords[i].Length)
						{
							checkPositions = new int[] { startPos - 1 };
						}
						else
						{
							checkPositions = new int[] { startPos - 1, startPos + pureWord.Length };
						}

						foreach (int checkPos in checkPositions)
						{
							switch (dirtyWords[i][checkPos])
							{
								case '.':
									break;
								case ',':
									break;
								case '!':
									break;
								case '?':
									break;
								case '-':
									break;
								case ':':
									break;
								case ';':
									break;
								default:
									goto LoopEnd;

							}
						}
						wordPosition++;
					}

					if (wordPosition > 1)
						dirtyWords[i] = dirtyWords[i].Replace(pureWord, "");

					LoopEnd:;
				}
			}

			string newS = dirtyWords[0];
			for (int i = 1; i < dirtyWords.Length; i++)
			{
				if (dirtyWords[i] != "")
					newS += " " + dirtyWords[i];
			}

			return newS;
		}

		public static string RemoveDuplicateWords()
		{
			string s = "to to. toy to. to.. bottom ko?to.do what? why, why net sqrt.world, world apple www-site site.";
			List<string> listWords = new List<string>();
			char[] separators = new char[] { ' ', '.', ',', '!', '?', '-', ':', ';' };
			string currWord = "";
			for (int i = 0; i < s.Length; i++)
			{
				if (separators.Contains(s[i]))
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
