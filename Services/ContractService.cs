using System;
using System.Collections.Generic;
using System.Text;
using Entities;

namespace Services {
    class ContractService {

        private IOnlinePaymentService _onlinePaymentService;

        public ContractService(IOnlinePaymentService onlinePaymentService) {
            _onlinePaymentService = onlinePaymentService;
        }

        public void processContract(Contract contract, int months) {
            double basicQuota = contract.TotalValue / months;

            for(int i = 1; i <= months; i++) {
                DateTime date = contract.Date.AddMonths(i);
                double updateQuota = basicQuota + _onlinePaymentService.Interest(basicQuota, i);
                double fullQuota = updateQuota + _onlinePaymentService.PaymentFee(updateQuota);
                contract.AddInstallmente(new Installment(date, fullQuota));
            }
        }
    }
}
