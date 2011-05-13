using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler
{
    public class RunResponse
    {
        public readonly object Input;
        public readonly object Response;
        public readonly object Solution;

        public RunResponse(object input, object response, object solution)
        {
            Input = input;
            Response = response;
            Solution = solution;
        }
    }
}
