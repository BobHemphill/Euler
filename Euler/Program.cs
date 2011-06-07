using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Euler.Problems;
using Euler.BobsMath;

namespace Euler {
	class Program {		
		static void Main(string[] args) {
			new EulerProblemEngine { Logging = false }.Run(new EulerProblem16(), RunModes.Solution);
			Console.ReadLine();
		}							    															

		#region 17 SumOfNumberOfLettersInNumbersSpelledOut
        //21124
		private static int problem17TestUpperLimit = 100;
		private static int problem17SolutionUpperLimit = 1000;
		static void DoProblem17(bool logging = true) {
            Console.WriteLine(String.Format("{0}", SumOfNumberOfLettersInNumbersSpelledOut(problem17SolutionUpperLimit, logging)));
		}

		private static long SumOfNumberOfLettersInNumbersSpelledOut(int upperLimit, bool logging) {            
			var sum = 0;
			for (int j = 1; j <= upperLimit; j++) {
				var temp = GetNumberWordLength(j, logging);
                if (logging)
                {
                    Console.Write(":{0}", temp);
                    Console.WriteLine();
                }
				sum += temp;
			}
			return sum;
		}

		private static int GetNumberWordLength(int i, bool logging) {
			switch(i) {
				case 0:
					return 0;
				case 1:
                    if( logging)
                        Console.Write("One");
					return "One".Length;
				case 2:
					if( logging)
                        Console.Write("Two");
					return "Two".Length;
				case 3:
					if( logging)
                        Console.Write("Three");
					return "Three".Length;
				case 4:
					if( logging)
                        Console.Write("Four");
					return "Four".Length;
				case 5:
					if( logging)
                        Console.Write("Five");
					return "Five".Length;
				case 6:
					if( logging)
                        Console.Write("Six");
					return "Six".Length;
				case 7:
					if( logging)
                        Console.Write("Seven");
					return "Seven".Length;
				case 8:
					if( logging)
                        Console.Write("Eight");
					return "Eight".Length;
				case 9:
					if( logging)
                        Console.Write("Nine");
					return "Nine".Length;
				case 10:
					if( logging)
                        Console.Write("Ten");
					return "Ten".Length;
				case 11:
					if( logging)
                        Console.Write("Eleven");
					return "Eleven".Length;
				case 12:
					if( logging)
                        Console.Write("Twelve");
					return "Twelve".Length;
				case 13:
					if( logging)
                        Console.Write("Thirteen");
					return "Thirteen".Length;
				case 14:
					if( logging)
                        Console.Write("Fourteen");
					return "Fourteen".Length;
				case 15:
					if( logging)
                        Console.Write("Fifteen");
					return "Fifteen".Length;
				case 16:
					if( logging)
                        Console.Write("Sixteen");
					return "Sixteen".Length;
				case 17:
					if( logging)
                        Console.Write("Seventeen");
					return "Seventeen".Length;
				case 18:
					if( logging)
                        Console.Write("Eighteen");
					return "Eighteen".Length;
				case 19:
					if( logging)
                        Console.Write("Nineteen");
					return "Nineteen".Length;
				case 20:
					if( logging)
                        Console.Write("Twenty");
					return "Twenty".Length;
				case 30:
					if( logging)
                        Console.Write("Thirty");
					return "Thirty".Length;
				case 40:
					if( logging)
                        Console.Write("Forty");
					return "Forty".Length;
				case 50:
					if( logging)
                        Console.Write("Fifty");
					return "Fifty".Length;
				case 60:
					if( logging)
                        Console.Write("Sixty");
					return "Sixty".Length;
				case 70:
					if( logging)
                        Console.Write("Seventy");
					return "Seventy".Length;
				case 80:
					if( logging)
                        Console.Write("Eighty");
					return "Eighty".Length;
				case 90:
					if( logging)
                        Console.Write("Ninety");
					return "Ninety".Length;
				case 1000:
					if( logging)
                        Console.Write("One Thousand");
					return "OneThousand".Length;
				default:
					var tempInt = i;
					var tempSum = 0;
					if(i>99) {
						int hundreds = (tempInt / 100);
                        tempSum = GetNumberWordLength(hundreds, logging) + AddSpace(logging) + AddHundred(logging);
						if (tempInt % 100 == 0) return tempSum;

                        tempSum += AddSpace(logging) + AddAnd(logging) + AddSpace(logging);
                        return tempSum + GetNumberWordLength(tempInt - (hundreds * 100), logging);
					}
					int tens = (tempInt / 10) * 10;
                    return tempSum + GetNumberWordLength(tens, logging) + AddSpace(logging) + GetNumberWordLength(tempInt - tens, logging);
			}
		}

		private static int AddAnd(bool logging) {
            if (logging)
                Console.Write("and");
			return "and".Length;
		}

        private static int AddHundred(bool logging)
        {
            if (logging)
                Console.Write("Hundred");
            return "Hundred".Length;
        }

        private static int AddSpace(bool logging)
        {
            if (logging)
                Console.Write("");
			return "".Length;
		}

		#endregion
	}
}
