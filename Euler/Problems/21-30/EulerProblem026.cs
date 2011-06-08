using System;
using System.Linq;
using Euler.BobsMath;
using System.Collections.Generic;

namespace Euler.Problems {

  public class EulerProblem026 : Problem {
    public EulerProblem026()
      : base(10, 7, 1000) {
      SolutionResponse = 983;
    }

    private readonly List<LongDivisionMember> LongDivisionCache = new List<LongDivisionMember>();
  	const string LongDivisionSeed = "";
		string LongDivisionResult = LongDivisionSeed;
    public override object Run(RunModes runMode, object input, bool Logging) {
      var upperLimit = (int)input;

      int repeatingTermLength = 0;
      int MaxTerm = 0;
      for(int i = 1; i <= upperLimit; i++) {
      	var repeating = CalcLongDivision(new LongDivisionMember(1, i));
				LongDivisionResult = LongDivisionResult.Insert(1, ".");
      	if (repeating) {
      		var repeatingTerm = LongDivisionCache.Last();
      		var firstRepeatingIndex = LongDivisionCache.IndexOf(repeatingTerm);
					LongDivisionResult = LongDivisionResult.Insert(firstRepeatingIndex + 2, "(");
      		LongDivisionResult += ")";
      		if (LongDivisionCache.Count - 1 - firstRepeatingIndex > repeatingTermLength) {
      			repeatingTermLength = LongDivisionCache.Count;
      			MaxTerm = i;
      		}
      	}
				if (Logging)
					Console.WriteLine(String.Format("{0}->{1}", i, LongDivisionResult));
				LongDivisionResult = LongDivisionSeed;
    		LongDivisionCache.Clear();				
      }
      return MaxTerm;
    }

    private bool CalcLongDivision(LongDivisionMember longDivisionMember) {
      if(longDivisionMember.Numerator < longDivisionMember.Denominator) {
      	LongDivisionResult += "0";
        return CalcLongDivision(new LongDivisionMember(longDivisionMember.Numerator * 10, longDivisionMember.Denominator));        
      }

			
			if (longDivisionMember.Numerator % longDivisionMember.Denominator == 0) {
				LongDivisionResult += (longDivisionMember.Numerator / longDivisionMember.Denominator).ToString();
				return false;
			}

    	if (LongDivisionCache.Contains(longDivisionMember)) {
				LongDivisionCache.Add(longDivisionMember);
				return true;
			}

			LongDivisionResult += (longDivisionMember.Numerator / longDivisionMember.Denominator).ToString();
			LongDivisionCache.Add(longDivisionMember);
      return CalcLongDivision(new LongDivisionMember((longDivisionMember.Numerator % longDivisionMember.Denominator) * 10, longDivisionMember.Denominator));
    }
  }

  public class LongDivisionMember{
    public int Numerator;
    public int Denominator;

    public LongDivisionMember(int num, int denom) {
      Numerator = num;
      Denominator = denom;
    }

    public override bool Equals(object obj) {
      if( !(obj is LongDivisionMember)) return false;

      return Numerator == (obj as LongDivisionMember).Numerator &&
              Denominator == (obj as LongDivisionMember).Denominator;
    }
  }
}
