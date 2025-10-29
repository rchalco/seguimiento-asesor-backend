using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorStinger.Core.Interfaces.Infrastructure.PayBridge.PayTransaction
{
    public class PaymentTransactionRequest
    {
        public decimal Amount { get; set; }
        public string CardNumber { get; set; } = string.Empty;
        public string CardType { get; set; } = string.Empty;
        public string Cvv { get; set; } = string.Empty;
        public string PaymentMethod { get; set; } = string.Empty;
        public string ExpirationDate { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
    }
}
