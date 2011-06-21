using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.BobsMath
{
    public static class Combinations
    {
        public static IEnumerable<IEnumerable<int>> ChooseStringIndeces(int indecesToReplace, int stringStartLength)
        {
            var innerList = new List<int>();
            var outerList = new List<List<int>>();

            var indexCombination = new List<string>();
            for (int i = 0; i < stringStartLength; i++)
            {
                indexCombination.Add(i.ToString());
            }

            var combinations = new List<string>();
            Choose("", indecesToReplace, indexCombination, combinations);
            return combinations.Select(i => i.Select(c => Int32.Parse(c.ToString())));
        }

        public static void Choose(string seed, int chooseAmount, List<string> combinationMembers, List<string> combinations) {
			if (seed.Length == chooseAmount){
                if (DistinctCombination(combinations, seed))
                    combinations.Add(seed); 
                return;
			}
			if (combinationMembers.Count() == 1){
			    var tempSeed = seed + combinationMembers[0];
                if((DistinctCombination(combinations, tempSeed)))
				    combinations.Add(tempSeed);
			}
			int index = 0;
			foreach (var combinationMember in combinationMembers) {
				Choose(seed + combinationMember, chooseAmount, combinationMembers.Where((item, i) => i != index).ToList(), combinations);
				index++;
			}
		}

        private static bool DistinctCombination(List<string> combinations, string seed)
        {
            return !(combinations.Exists(i => seed.All(c => i.Contains(c))));
        }
    }
}
