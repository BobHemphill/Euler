using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Euler.DataStructures;
using Euler.BobsMath;

namespace Euler.Problems {

	public class EulerProblem24 : Problem {
		public EulerProblem24()
			: base(new PermutationInput("0123", 4), "201", new PermutationInput("0123456789", 1000000)) {
			SolutionResponse = "2783915460";
		}

		public override object Run(RunModes runMode, object input, bool Logging) {
			return FindNthOrderedPermutation((PermutationInput)input, Logging);
		}

		private string FindNthOrderedPermutation(PermutationInput input, bool logging) {
			List<string> permutationMembers = input.PermutationString.Select(item => item.ToString()).ToList();
			List<string> permutations = new List<string> ();
			GeneratePermutations("", permutationMembers, permutations, logging);
			foreach (var permutation in permutations) {
				if (logging)
					Console.WriteLine(permutation);
			}
			return permutations.Count()>input.PermutationIndex ? permutations[input.PermutationIndex-1] : "IndexError";
		}

		private void GeneratePermutations(string seed, List<string> permutationMembers, List<string> permutations, bool logging) {
			if( permutationMembers.Count()==1) {
				permutations.Add(seed + permutationMembers[0]);
			}
			foreach (var permutationMember in permutationMembers) {
				GeneratePermutations(seed + permutationMember, permutationMembers.Where(item => item != permutationMember).ToList(), permutations, logging);				
			}						
		}
	}

	public class PermutationInput {
		public string PermutationString;
		public int PermutationIndex;

		public PermutationInput(string permutationString, int permutationIndex) {
			PermutationString = permutationString;
			PermutationIndex = permutationIndex;			
		}
	}
}
