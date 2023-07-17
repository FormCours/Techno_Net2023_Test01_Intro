using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing_01_Intro.BLL.CustomExceptions
{
    public class CalculatorException : Exception { }

    public class DivByZeroCalculatorException : CalculatorException { }

    public class OutOfRangeCalculatorException : CalculatorException { }
}
