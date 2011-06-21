using System.Linq;
using Euler.BobsMath;

namespace Euler.Problems {

	public class EulerProblem051 : Problem {
		public EulerProblem051()
			: base(7, (long)56003, 8) {
			SolutionResponse = null;
		}
		
		public override object Run(RunModes runMode, object input, bool Logging) {
			int replacePrimeFamilyCount = (int) input;

            int start = 56000;
			while(true) {
				var stringStart = start.ToString();
				var stringStartLength = stringStart.Length;
				for (int indecesToReplace = 1; indecesToReplace < stringStartLength; indecesToReplace++) {
					var indeces = Combinations.ChooseStringIndeces(indecesToReplace, stringStartLength);
				    foreach (var index in indeces)
				    {                        
                        var permutations = Permutations.GenerateReplacements(stringStart, index);
                        if (permutations.Count() >= replacePrimeFamilyCount && permutations.Count(Primes.IsPrime) >= replacePrimeFamilyCount) return permutations.Min();                        
				    }
					
				}				
				start++;
			}
		}
	}
}
