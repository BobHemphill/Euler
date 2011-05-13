using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems
{
    public class EulerProblem1 : Problem
    {
        public EulerProblem1() : base(10, 23, 1000)
        {
            SolutionResponse = 233168;
        }

        public override object Run(RunModes runMode, object input, bool Logging)
        {
            return SumThreeAndFiveMultiplesBelow1000((int)input);            
        }

        long SumThreeAndFiveMultiplesBelow1000(int limit)
        {
            int count = 0;
            for (int i = 3; i < 1000; i += 3)
            {
                count += i;
            }
            for (int i = 5; i < limit; i += 5)
            {
                count += (i % 3 == 0) ? 0 : i;
            }
            return count;
        }
    }
}
