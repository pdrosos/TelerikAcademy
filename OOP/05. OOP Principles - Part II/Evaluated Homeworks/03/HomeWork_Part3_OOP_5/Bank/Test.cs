using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Test
    {
        static void Main(string[] args)
        {
            DepositAccount test = new DepositAccount(new Customer("Pesho"), 1001, 0.3m);

            Console.WriteLine(test.CalculateIntrestForPeriodOfMonths(10));

            LoanAccount testTwo = new LoanAccount(new Company("Something"), 55000, 0.3m);

            Console.WriteLine(testTwo.CalculateIntrestForPeriodOfMonths(10));

            MortgageAccount testThree = new MortgageAccount(new Individual("Gosho"), 4000, 0.5m);

            Console.WriteLine(testThree.CalculateIntrestForPeriodOfMonths(10));

            MortgageAccount testFour = new MortgageAccount(new Company("SomethingElse"), 700000, 0.3m);

            Console.WriteLine(testFour.CalculateIntrestForPeriodOfMonths(10));
            Console.WriteLine(testFour.CalculateIntrestForPeriodOfMonths(15));

            while (true)
            {
                
            }
        }
    }
}
