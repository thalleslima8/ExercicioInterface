using System;
using System.Collections.Generic;
using System.Text;

namespace Services {
    interface IOnlinePaymentService {

        public double PaymentFee(Double amount);
        public double Interest(double amount, int months);
        

    }
}
