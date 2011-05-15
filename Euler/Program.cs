using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Euler.Problems;
using Euler.BobsMath;

namespace Euler {
	class Program {
		static readonly List<long> Primes = new List<long> { 2 };
		static readonly List<long> SievePrimes = new List<long> { };
		static void Main(string[] args) {
      new EulerProblemEngine { Logging = false }.Run(new EulerProblem22(), RunModes.Solution);
		}							    

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
			return ((long)Math.Pow(sigmaX, 2)) - sigma_XSquared;
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

			foreach (var item in Primes) {
				if (prime % item == 0) return false;
			}
			Primes.Add(prime);
			return true;
		}

		static long FindPrime(int index) {
			if (index == 1) return 2;
			var primeCount = 1;
			long primeTest = 1;
			while (primeCount != index) {
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
			for (int i = 3; i < upperLimit; i += 2) {
				SievePrimes.Add(i);
			}

			var index = 1;
			while (index < SievePrimes.Count && SievePrimes[index] <= upperLimit) {
				var temp = SievePrimes[index];
				SievePrimes.RemoveAll(item => item != temp && item % temp == 0);
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

		private static long GreatestProductOfXConsecutiveNumbersInAMatrix(int[][] matrix, int consecutiveCount) {
			var max = 0;
			for (int row = 0; row < matrix.Length; row++) {
				for (int column = 0; column < matrix[row].Length; column++) {
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
		static int ProductHorizontal(int[][] matrix, int rowIndex, int columnIndex, int consecutiveCount) {
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
      return Factors.GetFactors(triangleNumber).Count() >= numberOfDivisors;
		}		
		#endregion

		#region 13 First 10 Digits of Sum of 100 50 digit numbers
		#region 13 Fields
		const int testSubStringCount = 2;
		static List<string> testNumbers = new List<string> { "123", "245", "345", "345", "234", "997", "998" };

		const int solutionSubStringCount = 10;
		static List<string> solutionNumbers = new List<string> { 
			"37107287533902102798797998220837590246510135740250",
			"46376937677490009712648124896970078050417018260538",
			"74324986199524741059474233309513058123726617309629",
			"91942213363574161572522430563301811072406154908250",
			"23067588207539346171171980310421047513778063246676",
			"89261670696623633820136378418383684178734361726757",
			"28112879812849979408065481931592621691275889832738",
			"44274228917432520321923589422876796487670272189318",
			"47451445736001306439091167216856844588711603153276",
			"70386486105843025439939619828917593665686757934951",
			"62176457141856560629502157223196586755079324193331",
			"64906352462741904929101432445813822663347944758178",
			"92575867718337217661963751590579239728245598838407",
			"58203565325359399008402633568948830189458628227828",
			"80181199384826282014278194139940567587151170094390",
			"35398664372827112653829987240784473053190104293586",
			"86515506006295864861532075273371959191420517255829",
			"71693888707715466499115593487603532921714970056938",
			"54370070576826684624621495650076471787294438377604",
			"53282654108756828443191190634694037855217779295145",
			"36123272525000296071075082563815656710885258350721",
			"45876576172410976447339110607218265236877223636045",
			"17423706905851860660448207621209813287860733969412",
			"81142660418086830619328460811191061556940512689692",
			"51934325451728388641918047049293215058642563049483",
			"62467221648435076201727918039944693004732956340691",
			"15732444386908125794514089057706229429197107928209",
			"55037687525678773091862540744969844508330393682126",
			"18336384825330154686196124348767681297534375946515",
			"80386287592878490201521685554828717201219257766954",
			"78182833757993103614740356856449095527097864797581",
			"16726320100436897842553539920931837441497806860984",
			"48403098129077791799088218795327364475675590848030",
			"87086987551392711854517078544161852424320693150332",
			"59959406895756536782107074926966537676326235447210",
			"69793950679652694742597709739166693763042633987085",
			"41052684708299085211399427365734116182760315001271",
			"65378607361501080857009149939512557028198746004375",
			"35829035317434717326932123578154982629742552737307",
			"94953759765105305946966067683156574377167401875275",
			"88902802571733229619176668713819931811048770190271",
			"25267680276078003013678680992525463401061632866526",
			"36270218540497705585629946580636237993140746255962",
			"24074486908231174977792365466257246923322810917141",
			"91430288197103288597806669760892938638285025333403",
			"34413065578016127815921815005561868836468420090470",
			"23053081172816430487623791969842487255036638784583",
			"11487696932154902810424020138335124462181441773470",
			"63783299490636259666498587618221225225512486764533",
			"67720186971698544312419572409913959008952310058822",
			"95548255300263520781532296796249481641953868218774",
			"76085327132285723110424803456124867697064507995236",
			"37774242535411291684276865538926205024910326572967",
			"23701913275725675285653248258265463092207058596522",
			"29798860272258331913126375147341994889534765745501",
			"18495701454879288984856827726077713721403798879715",
			"38298203783031473527721580348144513491373226651381",
			"34829543829199918180278916522431027392251122869539",
			"40957953066405232632538044100059654939159879593635",
			"29746152185502371307642255121183693803580388584903",
			"41698116222072977186158236678424689157993532961922",
			"62467957194401269043877107275048102390895523597457",
			"23189706772547915061505504953922979530901129967519",
			"86188088225875314529584099251203829009407770775672",
			"11306739708304724483816533873502340845647058077308",
			"82959174767140363198008187129011875491310547126581",
			"97623331044818386269515456334926366572897563400500",
			"42846280183517070527831839425882145521227251250327",
			"55121603546981200581762165212827652751691296897789",
			"32238195734329339946437501907836945765883352399886",
			"75506164965184775180738168837861091527357929701337",
			"62177842752192623401942399639168044983993173312731",
			"32924185707147349566916674687634660915035914677504",
			"99518671430235219628894890102423325116913619626622",
			"73267460800591547471830798392868535206946944540724",
			"76841822524674417161514036427982273348055556214818",
			"97142617910342598647204516893989422179826088076852",
			"87783646182799346313767754307809363333018982642090",
			"10848802521674670883215120185883543223812876952786",
			"71329612474782464538636993009049310363619763878039",
			"62184073572399794223406235393808339651327408011116",
			"66627891981488087797941876876144230030984490851411",
			"60661826293682836764744779239180335110989069790714",
			"85786944089552990653640447425576083659976645795096",
			"66024396409905389607120198219976047599490197230297",
			"64913982680032973156037120041377903785566085089252",
			"16730939319872750275468906903707539413042652315011",
			"94809377245048795150954100921645863754710598436791",
			"78639167021187492431995700641917969777599028300699",
			"15368713711936614952811305876380278410754449733078",
			"40789923115535562561142322423255033685442488917353",
			"44889911501440648020369068063960672322193204149535",
			"41503128880339536053299340368006977710650566631954",
			"81234880673210146739058568557934581403627822703280",
			"82616570773948327592232845941706525094512325230608",
			"22918802058777319719839450180888072429661980811197",
			"77158542502016545090413245809786882778948721859617",
			"72107838435069186155435662884062257473692284509516",
			"20849603980134001723930671666823555245252804609722",
			"53503534226472524250874054075591789781264330331690" };
		#endregion
		//5537376230
		static void DoProblem13() {
			Console.WriteLine(String.Format("{0}", SubStringSumNumbers(solutionSubStringCount, solutionNumbers)));
		}

		static string SubStringSumNumbers(int stringDigits, List<string> stringNumbers) {
			string result = SumBigIntNumbers(stringNumbers);
			return result.Substring(0, stringDigits);
		}

		private static string SumBigIntNumbers(List<string> stringNumbers) {
			var maxIndex = stringNumbers.Max(s => s.Length) - 1;
			var carry = 0;
			string result = "";
			while (maxIndex>=0) {
				result = AddStringAtIndex(stringNumbers, maxIndex, ref carry) + result;
				maxIndex--;
			}
			result = carry.ToString() + result;
			return result;
		}

		static string AddStringAtIndex(IEnumerable<string> stringNumbers, int index, ref int carry) {
			int sum = carry%10;
			carry = carry/10;

			sum += stringNumbers.Where(stringNumber => stringNumber.Length > index).Sum(stringNumber => Int32.Parse(stringNumber[index].ToString()));

			carry += sum/10;

			return sum.ToString().Last().ToString();
		}

		#endregion

		#region 14 Longest Chain created by two functions
		//837799
		private static long testUpperLimit = 14;
		private static long solutionUpperLimit = 1000000;

		private static Func<long, long> EvenFunc = (long i) => { return (i / 2); };
		private static Func<long, long> OddFunc = (long i) => { return (3 * i + 1); };
		private static Func<long, long> ChainFunc = (long i) => { return (i % 2 == 0) ? EvenFunc(i) : OddFunc(i); };

		static readonly Dictionary<long, long> ChainLengthDictionary = new Dictionary<long, long>();
		static void DoProblem14(bool logging=false) {
			Console.WriteLine(String.Format("{0}", FindSeedOfLongestChain(solutionUpperLimit, logging)));
		}

		private static long FindSeedOfLongestChain(long upperLimit, bool logging) {
			long maxSeed = 0;
			long maxChain = 0;
			for (long i = 1; i < upperLimit; i++) {
				long temp = ChainLength(i, logging);
				if (temp > maxChain) {
					maxChain = temp;
					maxSeed = i;
				}
				if (logging) {
					Console.Write(String.Format(":{0}", temp));
					Console.WriteLine();
				}
			}
			if (logging) {
				Console.WriteLine();
				Console.WriteLine();
			}
			return maxSeed;
		}

		private static long ChainLength(long i, bool logging) {
			if (i <= 1) {
				if(logging)
					Console.Write("1");
				return 1;
			}
			if (logging)
				Console.Write(String.Format("{0}=>", i));
			if (ChainLengthDictionary.ContainsKey(i)) {
				if (logging)
					Console.Write(String.Format(" -{0}- ", ChainLengthDictionary[i]-1));
				return ChainLengthDictionary[i];
			}
				

			long intermediateChainLength = 1 + ChainLength(ChainFunc(i), logging);
			ChainLengthDictionary.Add(i, intermediateChainLength);
			return intermediateChainLength;
		}

		#endregion

		#region 15 FindPaths
		//137846528820
		private static int testPathGridSize = 20;
		private static int solutionPathGridSize = 20;
		private static readonly Dictionary<int, Dictionary<int, long>> HopsDictionary = new Dictionary<int, Dictionary<int, long>>();
		static void DoProblem15(bool logging = false) {
			Console.WriteLine(String.Format("{0}", FindPaths(testPathGridSize, logging)));
		}

		private static long FindPaths(int gridSize, bool logging) {
			return FindPaths(0, 0, gridSize);
		}
		private static long FindPaths(int i, int j, int gridSize) {
			if (i == gridSize || j == gridSize) return 1;

			if (HopsDictionary.ContainsKey(i) && HopsDictionary[i].ContainsKey(j)) return HopsDictionary[i][j];

			long rightPathHops = FindPaths(i + 1, j, gridSize);
			AddToHopDictionary(i + 1, j, rightPathHops);
			long downPathHops = FindPaths(i, j + 1, gridSize);
			AddToHopDictionary(i, j + 1, downPathHops);
			AddToHopDictionary(i, j, rightPathHops+downPathHops);
			return rightPathHops + downPathHops;
		}

		private static void AddToHopDictionary(int i, int j, long hops) {
			if (!HopsDictionary.ContainsKey(i)) HopsDictionary.Add(i, new Dictionary<int, long>());

			if(!HopsDictionary[i].ContainsKey(j)) HopsDictionary[i].Add(j, hops);
		}

		#endregion

		#region 16 SumOfDigitsBigInt
		//1366
		private static int testExponent = 15;
		private static int solutionExponent = 1000;
		static void DoProblem16(bool logging = false) {
			Console.WriteLine(String.Format("{0}", SumOfDigitsBigInt(solutionExponent, logging)));
		}

		private static long SumOfDigitsBigInt(int exponent, bool logging) {
			var result = "1";
			for (int i = 0; i < exponent; i++) {
				var stringArrary = new List<string> {result, result};
				result = SumBigIntNumbers(stringArrary);
			}

			return result.Sum(i => Int32.Parse(i.ToString()));
		}
		#endregion

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
