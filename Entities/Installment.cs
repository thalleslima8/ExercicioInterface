using System;
using System.Globalization;


namespace Entities {
    class Installment {

        public DateTime DueDate { get;private set; }
        public double Amount { get;private set; }

        

        public Installment(DateTime date, double amount) {
            DueDate = date;
            Amount = amount;
        }

        public override string ToString() {
            return DueDate.ToString("dd/MM/yyyy") +
                " - " + Amount.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
