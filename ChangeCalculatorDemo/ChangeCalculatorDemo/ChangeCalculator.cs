using System.Collections.Generic;
using System.Linq;

namespace ChangeCalculatorDemo
{
    public class ChangeCalculator
    {
        public static int GetChange(int receivedMoney, int productPrice)
        {
            return receivedMoney - productPrice;
        }

        public List<string> DisplayChange(int change)
        {
            List<string> changeList = new List<string>();

            List<int> denominations = Denominations.GetDenominations();

            foreach (var denomination in denominations)
            {
                int money = change / denomination;
                change -= money * denomination;

                if (money > 0)
                {
                    if (denomination % 100 == 0)
                        changeList.Add(money + " x £" + denomination / 100);
                    else
                        changeList.Add(money + " x " + denomination + "p");
                }

                if (change == 0)
                    break;
            }

            return changeList;
        }

        public int ConvertMoney(string money)
        {
            money = money.Trim().ToLower();

            string cleanMoney = money.Replace("£", "").Replace("p", "");

            var isDecimal = decimal.TryParse(cleanMoney, out _);

            if (!isDecimal)
                return 0;

            int poundCount = money.Count(f => f == '£');
            int penceCount = money.Count(f => f == 'p');
            int dotCount = money.Count(f => f == '.');

            if (penceCount == 1 && !money.EndsWith("p"))
                return 0;

            if (poundCount == 1 && !money.StartsWith("£"))
                return 0;

            if (poundCount > 1 || penceCount > 1 || dotCount > 1)
                return 0;

            if (money.StartsWith("£"))
            {
                money = money.Replace("£", "").Replace("p","");

                if (money.Contains("."))
                {
                    return MoneyContainsDot(money);
                }

                return int.Parse(money) * 100;
            }

            if (money.EndsWith("p"))
            {
                money = money.Replace("p", "");

                if (money.Length == 2)
                { 
                    return int.Parse(money);
                }

                return 0;
            }

            if (money.Contains("."))
            {
                return MoneyContainsDot(money);
            }

            return int.Parse(money);
        }

        public int MoneyContainsDot(string money)
        {
            int pence = 0;

            string[] dotSplit = money.Split('.');

            var pounds = 0;

            if(dotSplit[0] != string.Empty)
                pounds = int.Parse(dotSplit[0]);

            if (!string.IsNullOrEmpty(dotSplit[1]))
            {
                if (dotSplit[1].Length > 2)
                    return 0;

                pence = int.Parse(dotSplit[1]);

                if (dotSplit[1].Length == 1)
                {
                    pence = int.Parse(dotSplit[1] + "0");
                }
            }

            return (pounds * 100) + pence;
        }
    }
}
