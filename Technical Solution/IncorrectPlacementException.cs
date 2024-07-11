using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Technical_Solution
{
    public class IncorrectPlacementException : ArgumentOutOfRangeException
    {
        public IncorrectPlacementException(string e) : base(e){ }
        public IncorrectPlacementException() : base() { }
    }
}
