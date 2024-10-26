using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace financial_banking.Domain.Entities
{
    public class Transaction
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}