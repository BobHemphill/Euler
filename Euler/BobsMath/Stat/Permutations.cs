using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.BobsMath {
	public static class Permutations {

		public static readonly List<char> Chars = new List<char> { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
		public static void Generate(string seed, List<string> permutationMembers, List<string> permutations) {
			if (permutationMembers.Count() == 1) {
				permutations.Add(seed + permutationMembers[0]);
			}
			int index = 0;
			foreach (var permutationMember in permutationMembers) {
				Generate(seed + permutationMember, permutationMembers.Where((item, i) => i != index).ToList(), permutations);
				index++;
			}
		}

		public static IEnumerable<long> Generate(long n) {
			List<string> permutationMembers = n.ToString().Select(item => item.ToString()).ToList();
			List<string> permutations = new List<string>();
			Generate("", permutationMembers, permutations);
			return permutations.Select(item => Int64.Parse(item));
		}

		public static IEnumerable<string> Generate(string n) {
			List<string> permutationMembers = n.Select(item => item.ToString()).ToList();
			List<string> permutations = new List<string>();
			Generate("", permutationMembers, permutations);
			return permutations;
		}

		public static IEnumerable<long> GenerateRotations(long n) {
			List<long> rotations = new List<long>();
			string temp = n.ToString();
			int rotationCount = temp.Length;
			rotations.Add(n);
			for (int i = 1; i < rotationCount; i++) {
				var first = temp[0].ToString();
				temp = temp.Substring(1) + first;
				rotations.Add(Int64.Parse(temp));
			}
			return rotations;
		}

		public static IEnumerable<long> GenerateReplacements(string stringStart, IEnumerable<int> indeces) {
			var ret = new List<long>();

			for (int replacingDigit = 0; replacingDigit <= 9; replacingDigit++) {
				if (replacingDigit == 0 && indeces.Contains(0) || (replacingDigit == 0 || replacingDigit == 2 || replacingDigit == 4 || replacingDigit == 5 || replacingDigit == 6 || replacingDigit == 8) && indeces.Contains(stringStart.Length - 1))
					continue;

				//var temp = new string(stringStart.Select((c, i) => indeces.Contains(i) ? Chars[replacingDigit] : c).ToArray());
				var temp = stringStart;
				foreach (var index in indeces) {
					temp = temp.Remove(index, 1);
					temp = temp.Insert(index, replacingDigit.ToString());
				}
				var tempLong = Int64.Parse(temp);
				ret.Add(tempLong);
			}

			return ret;
		}

		public static bool IsPermutations(long a, long b) {
			var aString = a.ToString();
			var bString = b.ToString();

			if (aString.Length != bString.Length) return false;

			for (int i = 0; i <= 9; i++) {
				Func<char, bool> predicate = c => c == i.ToString().First();
				if (aString.Count(predicate) != bString.Count(predicate)) return false;
			}
			return true;
		}

		public static bool UniqueDigits(int start) {
			string temp = start.ToString();
			return temp.All(c => temp.Count(c2 => c2 == c) == 1);
		}
	}
}
