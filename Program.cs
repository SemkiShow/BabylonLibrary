using System;
using System.Numerics;

namespace BabylonLibrary
{
	public class Compression
	{
		public static int FindSymbolIndexInAString(string symbol, string input)
		{
			for (int i = 0; i < input.Length; i++)
			{
				if (Convert.ToString(input[i]) == Convert.ToString(symbol))
				{
					return i;
				}
			}
			Console.WriteLine("Error: FindSymbolIndexInAString (for loop reached the end)");
			return 0;
		}

		public static BigInteger Compress(string message, string letters)
		{
			BigInteger compressedText = 0;
			for (int i = 0; i < message.Length; i++)
			{
				compressedText += (letters.Length ^ (message.Length - i + 1)) * (FindSymbolIndexInAString(Convert.ToString(message[i]), message) + 1);
			}
			return compressedText;
		}
	}

	public class Program
	{
		static void Main()
		{
			string letters = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm ,.?!\":;`~@#$%^&*()_-+=[]{}\\|<>№\n\t0123456789";

			// Mode selection
			Console.WriteLine("Would you like to compress(c) or decompress(d)?");
			string mode = Console.ReadLine().ToLower();

			// Text input
			Console.WriteLine("Enter text");
			string message = Console.ReadLine();

			// Compressing/decompressing
			if (mode == "c")
			{
				Console.WriteLine("The compressed text is:\n" + Compression.Compress(message, letters));
				Console.WriteLine("The estimated number is more than:\n" + (letters.Length ^ (message.Length - 1)) + "\nCalculate " + letters.Length + "^(" + message.Length + "-1)");
				if (Compression.Compress(message, letters) < (letters.Length ^ (message.Length - 1)))
				{
					Console.WriteLine("Error: compressed text is too small!");
				}
			}
		}
	}
}

