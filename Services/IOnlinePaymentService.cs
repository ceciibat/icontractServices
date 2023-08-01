using System;

namespace Fix.Services
{
     interface IOnlinePaymentService                        // seviço de pagamento online
    {
        double Interest(double amount, int months);         // juros ; juro mensal
        double PaymentFee(double amount);                   // taxa de pagamento ; taxa por pagamento
        
    }
}
