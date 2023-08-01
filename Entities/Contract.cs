using System;

namespace Fix.Entities
{
    internal class Contract
    {
        public int Number { get; set; }
        public DateTime DateInitial { get; set; }                     // data de inicio do contrato
        public double TotalValue { get; set; }                        // valor total do contrato
        public List<Installment> Installments { get; set; }           // lista das parcelas

        public Contract(int number, DateTime dateInitial, double totalValue)
        {
            Number = number;
            DateInitial = dateInitial;
            TotalValue = totalValue;
            Installments = new List<Installment>();
        }

        public void AddInstallment(Installment installment)          // método que não se precisa pedir.. tendo lista{ fazê-lo! }
        {
            Installments.Add(installment);
        }
    }
}
