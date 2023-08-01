using Fix.Entities;
using Fix.Services;
using System.Globalization;

namespace Fix.Entities;

class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("Enter contract data");
        Console.Write("Number: ");
        int number = int.Parse(Console.ReadLine());
        Console.Write("Date: ");
        DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
        Console.Write("Contract value: ");
        double totalValue = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        Console.Write("Enter number of installments: ");
        int months = int.Parse(Console.ReadLine());                            // aqui ele lê os meses p/ parcelamento do contrato

        Contract contrato = new Contract(number, date, totalValue);

        // instancia um serviço de contrato, e dentro dele instancia o serviço utilizado que é o PayPal 
        ContractService contractService = new ContractService(new PaypalService());

        // pega o serviço de contrato instanciado e aí sim chama o processamento de contrato processContract
        contractService.ProcessContract(contrato, months);

        Console.WriteLine("Installments: ");
        foreach (Installment installment in contrato.Installments)
        {
            Console.WriteLine(installment);
        }

    }
}
