using System;
using System.Linq;
using Euler.BobsMath;
using System.Collections.Generic;

namespace Euler.Problems {

  public class EulerProblem26 : Problem {
    public EulerProblem26()
      : base(10, (long)7, 1000) {
      SolutionResponse = null;
    }

    private readonly List<LongDivisionMember> LongDivisionCache = new List<LongDivisionMember>();
    public override object Run(RunModes runMode, object input, bool Logging) {
      var upperLimit = (int)input;

      int repeatingTermLength = 0;
      int MaxTerm = 0;
      for(int i = 1; i <= upperLimit; i++) {
        CalcLongDivision(new LongDivisionMember(1, i));
        if( LongDivisionCache.Count > repeatingTermLength){
          repeatingTermLength = LongDivisionCache.Count;
          MaxTerm = i;
        }
        LongDivisionCache.Clear();
      }
      return MaxTerm;
    }

    private void CalcLongDivision(LongDivisionMember longDivisionMember) {
      if(longDivisionMember.Numerator < longDivisionMember.Denominator){
        CalcLongDivision(new LongDivisionMember(longDivisionMember.Numerator * 10, longDivisionMember.Denominator));
        return;
      }

      if( longDivisionMember.Numerator % longDivisionMember.Denominator == 0 || LongDivisionCache.Contains(longDivisionMember))
        return;
      LongDivisionCache.Add(longDivisionMember);
      CalcLongDivision(new LongDivisionMember(longDivisionMember.Numerator % longDivisionMember.Denominator, longDivisionMember.Denominator));
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
