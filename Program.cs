using Entities;
using System;
using System.Globalization;
using Services;

namespace ExercicioInterface {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Enter contract number: ");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Date (dd/MM/yyyy): ");
            DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            Console.WriteLine("Enter Contract Value: ");
            double value = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter number of installments: ");
            int months = int.Parse(Console.ReadLine());

            Contract myContract = new Contract(number, date, value);

            ContractService contractService = new ContractService(new PaypalService());
            contractService.processContract(myContract, months);

            Console.WriteLine("Installments: ");
            foreach (Installment i in myContract.Installments) {
                Console.WriteLine(i);
            }
        }
    }
}
