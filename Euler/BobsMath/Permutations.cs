using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.BobsMath {
  public static class Permutations {

    public static void Generate(string seed, List<string> permutationMembers, List<string> permutations) {
      if(permutationMembers.Count() == 1) {
        permutations.Add(seed + permutationMembers[0]);
      }
      int index=0;
      foreach(var permutationMember in permutationMembers) {
        Generate(seed + permutationMember, permutationMembers.Where( (item,i) => i!=index).ToList(), permutations);
        index++;
      }
    }

    public static IEnumerable<long> Generate(long n) {
      List<string> permutationMembers = n.ToString().Select(item => item.ToString()).ToList();
      List<string> permutations = new List<string>();
      Generate("", permutationMembers, permutations);
      return permutations.Select(item=>Int64.Parse(item));
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
  }
}
