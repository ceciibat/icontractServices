using System.Globalization;

namespace Fix.Entities
{
    internal class Installment   // prestação/parcela
    {
        public DateTime DueDate { get; set; }    // dueDate = data de vencimento
        public double Amount { get; set; }       // quantia

        public Installment(DateTime dueDate, double amount)
        {
            DueDate = dueDate;
            Amount = amount;
        }

        public override string ToString()
        {
            return DueDate.ToString("dd/MM/yyyy") 
                + " - " 
                + Amount.ToString("f2", CultureInfo.InvariantCulture)
                + "\n";
        }
    }
}
