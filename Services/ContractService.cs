using Fix.Entities;

namespace Fix.Services
{
     class ContractService 
    {
        private IOnlinePaymentService _onlinePaymentService;                // isso serve para esta classe possuir uma instância da Interface
        //               ^^
        // o valor desta || vai ser dado justamente pelo construtor! 
        // ela é instanciada na classe como atributo pois assim ela pode ser utilizada por vários Métodos
        // ela é private por questões de segurança.
          
        public ContractService(IOnlinePaymentService onlinePaymentService)
        {
            _onlinePaymentService = onlinePaymentService;                   // que sera paypalservice = UPCASTING (CASTING IMPLÍCITO)
        }

        public void ProcessContract(Contract contract, int months)          // processamento do contrato
        {
            // aqui se pega a cota básica do valor total dividido entre os meses
            double basicQuota = contract.TotalValue / months;              
            
            for (int i = 1; i <= months; i++)
            {
                DateTime date = contract.DateInitial.AddMonths(i);                                     // aqui ele adiciona 1 mês a data inicial                    
                double updatedQuota = basicQuota + _onlinePaymentService.Interest(basicQuota, i);      // variavel para atualizar a cota, somando nela o valor dos juros (interest)             
                double fullQuota = updatedQuota + _onlinePaymentService.PaymentFee(updatedQuota);      //  variavel c/ valor final, é somada ao updateQuota a taxa de pagamento (paymentfee) 
                contract.AddInstallment(new Installment(date, fullQuota));                             // aqui pega o contract e adiciona uma parcela na lista

            }
        }
    }
}
