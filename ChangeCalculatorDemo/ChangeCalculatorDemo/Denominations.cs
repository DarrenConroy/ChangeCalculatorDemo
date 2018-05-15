using System.Collections.Generic;

namespace ChangeCalculatorDemo
{
    public class Denominations
    {
        public static List<int> GetDenominations()
        {
            return new List<int>()
            {
                5000, 2000, 1000, 500, 200, 100, 50, 20, 10, 5, 2, 1
            };
        }
    }
}