using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler {
	class Program {
		static readonly List<long> Primes = new List<long>{2};
		static readonly List<long> SievePrimes = new List<long> {  };
		static void Main(string[] args) {
			DateTime start = DateTime.Now;
			DoProblem12();			
			var elapsed = DateTime.Now - start;
			Console.WriteLine(String.Format("{0}.{1}.{2}", elapsed.Minutes, elapsed.Seconds, elapsed.Milliseconds));
			Console.ReadLine();
		}

		#region Problem 1 Sum Multiples of 3 and 5 below 1000
		//233168
		static void DoProblem1() {
			Console.WriteLine(String.Format("{0}", SumThreeAndFiveMultiplesBelow1000(1000)));
		}

		static long SumThreeAndFiveMultiplesBelow1000(int limit) {
			int count = 0;
			for (int i = 3; i < 1000; i+=3) {
				count += i;
			}
			for (int i = 5; i < limit; i+=5) {
				count += (i%3 == 0) ? 0 : i;
			}
			return count;
		}
		#endregion
		
		#region Problem 2 Sum Even Fibonacci Numbers less than 4000000
		static void DoProblem2() {
			//4613732
			Console.WriteLine(String.Format("{0}", SumEvenFibonnaciBelow(4000000)));
		}

		private static long SumEvenFibonnaciBelow(long limit) {
			long fibSum = 0;
			long fibCur = 1;
			long fibPrev = 1;

			while (fibCur<limit) {
				if (fibCur % 2 == 0)
					fibSum += fibCur;
				long temp = fibCur;
				fibCur += fibPrev;
				fibPrev = temp;
			}

			return fibSum;
		}

		#endregion

		#region Problem 3 Largest Prime Factor
		static void DoProblem3() {
			//600851475143
			//6857
			Console.WriteLine(String.Format("{0}", FindLargestPrimeFactor(600851475143)));
		}

		static readonly Dictionary<long, int> PrimeFactors = new Dictionary<long, int>();
		private static long FindLargestPrimeFactor(long composite) {
			FactorComposite(composite, PrimeFactors);			
			return PrimeFactors.Keys.Max();
		}

		private static void FactorComposite(long composite, Dictionary<long, int> primeFactors) {
			for (long i = 2; i <= Math.Sqrt(composite); i++) {
				if (IsPrime(i))
					if (composite % i == 0) {
						AddToPrimeFactors(i, primeFactors);
						FactorComposite(composite / i, primeFactors);
						return;
					}
			}
			if (IsPrime(composite))
				AddToPrimeFactors(composite, primeFactors);
		}

		private static void AddToPrimeFactors(long primeFactor, Dictionary<long, int> primeFactors) {
			if (primeFactors.ContainsKey(primeFactor))
				primeFactors[primeFactor]++;
			else
				primeFactors.Add(primeFactor, 1);
		}
		private static void AddToPrimeFactors(Dictionary<long, int> primeFactors, Dictionary<long, int> tempPrimeFactors) {
			foreach(KeyValuePair<long, int> tempPrimeFactorsKVP in tempPrimeFactors) {
				if (primeFactors.ContainsKey(tempPrimeFactorsKVP.Key)) {
					if(primeFactors[tempPrimeFactorsKVP.Key] < tempPrimeFactorsKVP.Value)
						primeFactors[tempPrimeFactorsKVP.Key] = tempPrimeFactorsKVP.Value;
				}					
				else
					primeFactors.Add(tempPrimeFactorsKVP.Key, tempPrimeFactorsKVP.Value);
			}
			
		}
		#endregion

		#region Problem 4 Largest Palindrome that is a Composite of Two Three Digit Numbers	
		//3
		//906609
		static readonly List<long> palidromes = new List<long>();
		static void DoProblem4() {
			Console.WriteLine(String.Format("{0}", FindLargestPalindromeCompositeOfTwoThreeDigitNumbers(3)));
		}

		static long FindLargestPalindromeCompositeOfTwoThreeDigitNumbers(int compositeDigitLength) {
			for (var i = (long)Math.Pow(10, compositeDigitLength)- 1; i > (long)Math.Pow(10, compositeDigitLength-1); i--) {
				for (var j = (long)Math.Pow(10, compositeDigitLength) - 1; j > (long)Math.Pow(10, compositeDigitLength-1); j--) {
					if (IsPalidrome(i * j))
						palidromes.Add(i*j);
				}
			}
			return palidromes.Max();
		}

		static bool IsPalidrome(long palidrome) {
			string palidromeString = palidrome.ToString();
			for (int i = 0; i < palidromeString.Length/2; i++) {
				if (palidromeString[i] != palidromeString[palidromeString.Length - 1 - i])
					return false;
			}
			return true;
		}
		#endregion

		#region Problem 5 Smallest Number Divisible by 2-20
		//20
		//232792560
		static void DoProblem5() {
			Console.WriteLine(String.Format("{0}", FindSmallestNumberDivisibleByFirstXIntegers(20)));
		}

		static long FindSmallestNumberDivisibleByFirstXIntegers(int limit) {
			for (int i = 2; i <= limit; i++) {
				if(IsPrime(i))
					AddToPrimeFactors(i,PrimeFactors);
				else {
					var tempPrimeFactors = new Dictionary<long, int>();
					FactorComposite(i, tempPrimeFactors);
					AddToPrimeFactors(PrimeFactors, tempPrimeFactors);
				}
			}
			return LeastCommonMultiple(PrimeFactors);
		}

		static long LeastCommonMultiple(Dictionary<long, int> primeFactors) {
			long lcm = 1;
			foreach (KeyValuePair<long, int> primeFactorKVP in primeFactors) {
				for (int i = 0; i < primeFactorKVP.Value; i++) {
					lcm *= primeFactorKVP.Key;
				}
			}
			return lcm;
		}
		#endregion

		#region Problem 6 Difference between sum of squares and square of sums
		//100
		//25164150
		static void DoProblem6() {
			Console.WriteLine(String.Format("{0}", DifferenceBetweenSumOfSquaresAndSquareOfSum(100)));
		}

		private static long DifferenceBetweenSumOfSquaresAndSquareOfSum(int limit) {
			long sigmaX = 1;
			long sigma_XSquared = 1;
			for (int i = 2; i <= limit; i++) {
				sigma_XSquared += (long)Math.Pow(i, 2);
				sigmaX += i;
			}
			return ((long) Math.Pow(sigmaX, 2)) - sigma_XSquared;
		}

		#endregion

		#region Problem 7 10001st Prime
		static void DoProblem7() {
			//10001
			//104743
			Console.WriteLine(String.Format("{0}", FindPrime(10001)));
		}

		static bool IsPrime(long prime) {
			if (prime == 1) return false;
			if (prime == 2) return true;
			if (Primes.Contains(prime)) return true;

			foreach(var item in Primes) {
				if (prime % item == 0) return false;
			}
			Primes.Add(prime);					
			return true;
		}

		static long FindPrime(int index) {
			if (index == 1) return 2;
			var primeCount = 1;
			long primeTest = 1;
			while (primeCount!=index) {
				primeTest += 2;
				if (IsPrime(primeTest))
					primeCount++;				
			}
			return primeTest;
		}
		#endregion		

		#region 8 Greatest product of consecutive digits
		static void DoProblem8() {
			const string testString = "98612398746813";
			string solutionString = "73167176531330624919225119674426574742355349194934" +
															"96983520312774506326239578318016984801869478851843" +
															"85861560789112949495459501737958331952853208805511" +
															"12540698747158523863050715693290963295227443043557" +
															"66896648950445244523161731856403098711121722383113" +
															"62229893423380308135336276614282806444486645238749" +
															"30358907296290491560440772390713810515859307960866" +
															"70172427121883998797908792274921901699720888093776" +
															"65727333001053367881220235421809751254540594752243" +
															"52584907711670556013604839586446706324415722155397" +
															"53697817977846174064955149290862569321978468622482" +
															"83972241375657056057490261407972968652414535100474" +
															"82166370484403199890008895243450658541227588666881" +
															"16427171479924442928230863465674813919123162824586" +
															"17866458359124566529476545682848912883142607690042" +
															"24219022671055626321111109370544217506941658960408" +
															"07198403850962455444362981230987879927244284909188" +
															"84580156166097919133875499200524063689912560717606" +
															"05886116467109405077541002256983155200055935729725" +
															"71636269561882670428252483600823257530420752963450";
			//40824
			Console.WriteLine(String.Format("{0}", GreatestProductConsectutiveDigits(5, solutionString)));
		}

		private static long GreatestProductConsectutiveDigits(int numDigits, string longNumber) {
			var max = 0;
			for (int position = 0; position + numDigits < longNumber.Length; position++) {
				var temp = longNumber.Where((digit, index) => index >= position && index < position + numDigits).Select(ch => Int32.Parse(ch.ToString())).Aggregate(1, (item1, item2) => item1 * item2, item => item);
				if (temp > max) {
					max = temp;
				}
			}

			return max;
		}
		#endregion

		#region 9 Pythagorean triplet Sum
		const int testSum = 12;
		const int solutionSum = 1000;
		//31875000
		static void DoProblem9() {
			Console.WriteLine(String.Format("{0}", PythagoreanSumofTriplets(solutionSum)));
		}

		private static long PythagoreanSumofTriplets(int tripletSquaredProduct) {
			long solution = tripletSquaredProduct * tripletSquaredProduct;
			for (int a = 3; a < tripletSquaredProduct; a++) {
				for (int b = a + 1; b < tripletSquaredProduct; b++) {
					if (((2 * tripletSquaredProduct * a) + (2 * tripletSquaredProduct * b) + (-2 * a * b)) == solution) {
						return (a * b * (int)Math.Sqrt(a * a + b * b));
					}
				}
			}
			return 0;
		}
		#endregion

		#region 10 Sum Prime Numbers
		const int testLimit10 = 10;
		const int solutionLimit10 = 2000000;
		//142913828922
		static void DoProblem10() {
			Console.WriteLine(String.Format("{0}", SumPrimeNumbers(solutionLimit10)));
		}

		private static long SumPrimeNumbers(int upperLimit) {
			SetupSievePrimes(upperLimit);			
			return SievePrimes.Sum();
		}

		private static void SetupSievePrimes(int upperLimit) {
			SievePrimes.Add(2);
			for (int i = 3; i < upperLimit; i+=2) {
				SievePrimes.Add(i);
			}

			var index = 1;
			while (index < SievePrimes.Count && SievePrimes[index] <= upperLimit) {
				var temp = SievePrimes[index];
				SievePrimes.RemoveAll(item => item != temp && item%temp == 0);
				index++;
			}

		}
		#endregion

		#region 11 Product 4 consecutive numbers in 20x20
		static int[] testRow0 = new int[4] { 08, 02, 22, 97 };
		static int[] testRow1 = new int[4] { 49, 49, 99, 40 };
		static int[] testRow2 = new int[4] { 81, 49, 31, 73 };
		static int[] testRow3 = new int[4] { 52, 70, 95, 23 };
		static int[][] testArray = new int[4][] { testRow0, testRow1, testRow2, testRow3 };

		static int[] row0 = new int[20] { 08, 02, 22, 97, 38, 15, 00, 40, 00, 75, 04, 05, 07, 78, 52, 12, 50, 77, 91, 08 };
		static int[] row1 = new int[20] { 49, 49, 99, 40, 17, 81, 18, 57, 60, 87, 17, 40, 98, 43, 69, 48, 04, 56, 62, 00 };
		static int[] row2 = new int[20] { 81, 49, 31, 73, 55, 79, 14, 29, 93, 71, 40, 67, 53, 88, 30, 03, 49, 13, 36, 65 };
		static int[] row3 = new int[20] { 52, 70, 95, 23, 04, 60, 11, 42, 69, 24, 68, 56, 01, 32, 56, 71, 37, 02, 36, 91 };
		static int[] row4 = new int[20] { 22, 31, 16, 71, 51, 67, 63, 89, 41, 92, 36, 54, 22, 40, 40, 28, 66, 33, 13, 80 };
		static int[] row5 = new int[20] { 24, 47, 32, 60, 99, 03, 45, 02, 44, 75, 33, 53, 78, 36, 84, 20, 35, 17, 12, 50 };
		static int[] row6 = new int[20] { 32, 98, 81, 28, 64, 23, 67, 10, 26, 38, 40, 67, 59, 54, 70, 66, 18, 38, 64, 70 };
		static int[] row7 = new int[20] { 67, 26, 20, 68, 02, 62, 12, 20, 95, 63, 94, 39, 63, 08, 40, 91, 66, 49, 94, 21 };
		static int[] row8 = new int[20] { 24, 55, 58, 05, 66, 73, 99, 26, 97, 17, 78, 78, 96, 83, 14, 88, 34, 89, 63, 72 };
		static int[] row9 = new int[20] { 21, 36, 23, 09, 75, 00, 76, 44, 20, 45, 35, 14, 00, 61, 33, 97, 34, 31, 33, 95 };
		static int[] row10 = new int[20] { 78, 17, 53, 28, 22, 75, 31, 67, 15, 94, 03, 80, 04, 62, 16, 14, 09, 53, 56, 92 };
		static int[] row11 = new int[20] { 16, 39, 05, 42, 96, 35, 31, 47, 55, 58, 88, 24, 00, 17, 54, 24, 36, 29, 85, 57 };
		static int[] row12 = new int[20] { 86, 56, 00, 48, 35, 71, 89, 07, 05, 44, 44, 37, 44, 60, 21, 58, 51, 54, 17, 58 };
		static int[] row13 = new int[20] { 19, 80, 81, 68, 05, 94, 47, 69, 28, 73, 92, 13, 86, 52, 17, 77, 04, 89, 55, 40 };
		static int[] row14 = new int[20] { 04, 52, 08, 83, 97, 35, 99, 16, 07, 97, 57, 32, 16, 26, 26, 79, 33, 27, 98, 66 };
		static int[] row15 = new int[20] { 88, 36, 68, 87, 57, 62, 20, 72, 03, 46, 33, 67, 46, 55, 12, 32, 63, 93, 53, 69 };
		static int[] row16 = new int[20] { 04, 42, 16, 73, 38, 25, 39, 11, 24, 94, 72, 18, 08, 46, 29, 32, 40, 62, 76, 36 };
		static int[] row17 = new int[20] { 20, 69, 36, 41, 72, 30, 23, 88, 34, 62, 99, 69, 82, 67, 59, 85, 74, 04, 36, 16 };
		static int[] row18 = new int[20] { 20, 73, 35, 29, 78, 31, 90, 01, 74, 31, 49, 71, 48, 86, 81, 16, 23, 57, 05, 54 };
		static int[] row19 = new int[20] { 01, 70, 54, 71, 83, 51, 54, 69, 16, 92, 33, 48, 61, 43, 52, 01, 89, 19, 67, 48 };
		static int[][] productArray = new int[20][] { 
			row0, row1, row2, row3, row4,
		  row5 ,row6, row7, row8, row9,
		  row10, row11, row12, row13, row14,
		  row15, row16, row17, row18, row19};

		//70600674
		static void DoProblem11() {
			Console.WriteLine(String.Format("{0}", GreatestProductOfXConsecutiveNumbersInAMatrix(productArray, 4)));
		}

		private static long GreatestProductOfXConsecutiveNumbersInAMatrix(int[][] matrix, int consecutiveCount)
		{
			var max = 0;
			for (int row = 0; row < matrix.Length; row++) {
				for (int column = 0; column < matrix[row].Length; column++)
				{
					int temp;
					if (TestVerticalDownExists(row, matrix.Length, consecutiveCount)) {
						temp = ProductVertical(matrix, row, column, consecutiveCount);
						if (temp > max)
							max = temp;
					}
					if (TestHorizontalExists(column, matrix[row].Length, consecutiveCount)) {
						temp = ProductHorizontal(matrix, row, column, consecutiveCount);
						if (temp > max)
							max = temp;
					}
					if (TestDiagonalRightDownExists(row, matrix.Length, column, matrix[row].Length, consecutiveCount)) {
						temp = ProductDiagonalRightDown(matrix, row, column, consecutiveCount);
						if (temp > max)
							max = temp;
					}
					if (TestDiagonalRightUpExists(row, matrix.Length, column, matrix[row].Length, consecutiveCount)) {
						temp = ProductDiagonalRightUp(matrix, row, column, consecutiveCount);
						if (temp > max)
							max = temp;
					}
				}
			}
			return max;
		}

		static bool TestVerticalDownExists(int rowIndex, int verticalArrayLength, int consecutiveCount) {
			return rowIndex + consecutiveCount <= verticalArrayLength;
		}
		static bool TestVerticalUpExists(int rowIndex, int consecutiveCount) {
			return rowIndex + 1 - consecutiveCount >= 0;
		}

		static bool TestHorizontalExists(int columnIndex, int horizontalArrayLength, int consecutiveCount) {
			return columnIndex + consecutiveCount <= horizontalArrayLength;
		}
		static bool TestDiagonalRightDownExists(int rowIndex, int verticalArrayLength, int columnIndex, int horizontalArrayLength, int consecutiveCount) {
			return TestVerticalDownExists(rowIndex, verticalArrayLength, consecutiveCount) &&
						 TestHorizontalExists(columnIndex, horizontalArrayLength, consecutiveCount);
		}
		static bool TestDiagonalRightUpExists(int rowIndex, int verticalArrayLength, int columnIndex, int horizontalArrayLength, int consecutiveCount) {
			return TestVerticalUpExists(rowIndex, consecutiveCount) &&
						 TestHorizontalExists(columnIndex, horizontalArrayLength, consecutiveCount);
		}

		static int ProductVertical(int[][] matrix, int rowIndex, int columnIndex, int consecutiveCount) {
			var tempProduct = 1;
			for (int i = 0; i < consecutiveCount; i++) {
				tempProduct *= matrix[rowIndex + i][columnIndex];
			}
			return tempProduct;
		}
		static int ProductHorizontal(int[][] matrix, int rowIndex, int columnIndex, int consecutiveCount)
		{
			var tempProduct = 1;
			for (int i = 0; i < consecutiveCount; i++) {
				tempProduct *= matrix[rowIndex][columnIndex + i];
			}
			return tempProduct;
		}
		static int ProductDiagonalRightDown(int[][] matrix, int rowIndex, int columnIndex, int consecutiveCount) {
			var tempProduct = 1;
			for (int i = 0; i < consecutiveCount; i++) {
				tempProduct *= matrix[rowIndex + i][columnIndex + i];
			}
			return tempProduct;
		}
		static int ProductDiagonalRightUp(int[][] matrix, int rowIndex, int columnIndex, int consecutiveCount) {
			var tempProduct = 1;
			for (int i = 0; i < consecutiveCount; i++) {
				tempProduct *= matrix[rowIndex - i][columnIndex + i];
			}
			return tempProduct;
		}
		#endregion

		#region 12 Triangle number with 500 divisors
		//76576500
		const int testdivisors = 5;
		const int solutiondivisors = 500;

		static void DoProblem12() {
			Console.WriteLine(String.Format("{0}", FirstTriangleNumberWith500Divisors(solutiondivisors)));
		}

		private static long FirstTriangleNumberWith500Divisors(int numberOfDivisors) {
			int triangleIndex = 1;
			while (!HasAtLeastNumberOfDivisors(numberOfDivisors, GenerateTriangle(triangleIndex))) {
				triangleIndex++;
			}

			return GenerateTriangle(triangleIndex);
		}

		static long GenerateTriangle(int triangleIndex) {
			var triangleNumber = 0;
			for (var i = 1; i <= triangleIndex; i++) {
				triangleNumber += i;
			}
			return triangleNumber;
		}

		static bool HasAtLeastNumberOfDivisors(int numberOfDivisors, long triangleNumber) {
			return GetDivisors(triangleNumber).Count() >= numberOfDivisors;
		}

		static IEnumerable<long> GetDivisors(long triangleNumber) {
			var upperLimit = triangleNumber;
			var divisors = new List<long>();			
						
			for (var i = 1; i <= upperLimit; i++) {
				if (triangleNumber%i != 0) continue;
				divisors.Add(i);
				var tempUpperLimit = triangleNumber / i;
				if(tempUpperLimit>i)
					divisors.Add(triangleNumber/i);
				upperLimit = tempUpperLimit-1;
			}
			return divisors;
		}

		#endregion
	}	
}
