using System;

namespace Fix.Services
{
     class PaypalService : IOnlinePaymentService
    {
        public double Interest(double amount, int months)         // juro simples de 1% a cada parcela
        {
            return amount * 1.0 / 100.0 * months;
        }

        public double PaymentFee(double amount)                   // taxa de pagamento de 2%
        {
            return amount * 2.0 / 100.00;
        }
        
    }
}
