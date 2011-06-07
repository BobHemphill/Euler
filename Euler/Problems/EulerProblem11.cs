using System;
using System.Linq;
using Euler.BobsMath;

namespace Euler.Problems {

	public class EulerProblem11 : Problem {
		public EulerProblem11()
			: base(new EulerProblem11Input(testArray, 2), null, new EulerProblem11Input(productArray, 4)) {
				SolutionResponse = 70600674;
		}

		public override object Run(RunModes runMode, object input, bool Logging) {
			var max = 0;
			var eulerProblem11Input = (EulerProblem11Input) input;
			for (int row = 0; row < eulerProblem11Input.Matrix.Length; row++) {
				for (int column = 0; column < eulerProblem11Input.Matrix[row].Length; column++) {
					int temp;
					if (TestVerticalDownExists(row, eulerProblem11Input.Matrix.Length, eulerProblem11Input.ConsecutiveCount)) {
						temp = ProductVertical(eulerProblem11Input.Matrix, row, column, eulerProblem11Input.ConsecutiveCount);
						if (temp > max)
							max = temp;
					}
					if (TestHorizontalExists(column, eulerProblem11Input.Matrix[row].Length, eulerProblem11Input.ConsecutiveCount)) {
						temp = ProductHorizontal(eulerProblem11Input.Matrix, row, column, eulerProblem11Input.ConsecutiveCount);
						if (temp > max)
							max = temp;
					}
					if (TestDiagonalRightDownExists(row, eulerProblem11Input.Matrix.Length, column, eulerProblem11Input.Matrix[row].Length, eulerProblem11Input.ConsecutiveCount)) {
						temp = ProductDiagonalRightDown(eulerProblem11Input.Matrix, row, column, eulerProblem11Input.ConsecutiveCount);
						if (temp > max)
							max = temp;
					}
					if (TestDiagonalRightUpExists(row, eulerProblem11Input.Matrix.Length, column, eulerProblem11Input.Matrix[row].Length, eulerProblem11Input.ConsecutiveCount)) {
						temp = ProductDiagonalRightUp(eulerProblem11Input.Matrix, row, column, eulerProblem11Input.ConsecutiveCount);
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
	}

	public class EulerProblem11Input
	{
		public int[][] Matrix;
		public int ConsecutiveCount;

		public EulerProblem11Input(int[][] matrix, int consecutiveCount)
		{
			Matrix = matrix;
			ConsecutiveCount = consecutiveCount;
		}
	}
}
