using Fix.Entities;

namespace Fix.Services
{
     class ContractService 
    {
        private IOnlinePaymentService _onlinePaymentService;                // instanciei uma variável do tipo da interface.

        public ContractService(IOnlinePaymentService onlinePaymentService)
        {
            _onlinePaymentService = onlinePaymentService;                   // que sera paypalservice
        }

        public void ProcessContract(Contract contract, int months)          // processamento do contrato
        {
            // aqui se pega a cota básica do valor total dividido entre os meses
            double basicQuota = contract.TotalValue / months;              
            
            for (int i = 1; i <= months; i++)
            {
                // aqui ele adiciona 1 mês a data inicial
                DateTime date = contract.DateInitial.AddMonths(i);          
                // variavel para atualizar a cota, somando nela o valor dos juros (interest)
                double updatedQuota = basicQuota + _onlinePaymentService.Interest(basicQuota, i);
                //  variavel c/ valor final, é somada ao updateQuota a taxa de pagamento (paymentfee)
                double fullQuota = updatedQuota + _onlinePaymentService.PaymentFee(updatedQuota);
                // aqui pega o contract e adiciona uma parcela na lista
                contract.AddInstallment(new Installment(date, fullQuota));

            }
        }
    }
}
