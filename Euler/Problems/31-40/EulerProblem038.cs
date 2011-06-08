using System;
using System.Collections.Generic;
using System.Linq;
using Euler.BobsMath;

namespace Euler.Problems {

	public class EulerProblem038 : Problem {
		public EulerProblem038()
			: base(null, null, 9) {
			SolutionResponse = 932718654;
		}

		public List<int> Pandigitals = new List<int>();
		public override object Run(RunModes runMode, object input, bool Logging) {
			int pandigitalCheckAmount = (int)input;
			int maxPandigital = 918273645;

			for (int i = 1; i <= 8; i++) {
				int temp = 90 + i;        
        MaxPandigital(temp, pandigitalCheckAmount, ref maxPandigital);        
			}
      for(int i = 12; i <= 87; i++) {
        int temp = 900 + i;
        MaxPandigital(temp, pandigitalCheckAmount, ref maxPandigital);
      }
      for(int i = 123; i <= 876; i++) {
        int temp = 9000 + i;
        MaxPandigital(temp, pandigitalCheckAmount, ref maxPandigital);
      }      
      return maxPandigital;
		}

    void MaxPandigital(int temp, int pandigitalCheckAmount, ref int maxPandigital)
    {
      string tempString = temp.ToString();
      int multiplier = 2;
      while(tempString.Length < pandigitalCheckAmount) {        
        tempString += (temp * multiplier).ToString();
        multiplier++;
      }
      if(tempString.Length == pandigitalCheckAmount && Pandigital.IsPandigital(tempString, pandigitalCheckAmount) && Int32.Parse(tempString) > maxPandigital)
        maxPandigital = Int32.Parse(tempString);
    }
	}
}
