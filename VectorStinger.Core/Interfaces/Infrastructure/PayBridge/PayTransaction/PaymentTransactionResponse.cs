using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorStinger.Core.Interfaces.Infrastructure.PayBridge.PayTransaction
{
    public class PaymentTransactionResponse
    {
        public string TransactionId { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string ErrorCode { get; set; } = string.Empty;
        public string ErrorDescription { get; set; } = string.Empty;
        public string PaymentMethod { get; set; } = string.Empty;
        public string PaymentMethodType { get; set; } = string.Empty;
        public string PaymentMethodProvider { get; set; } = string.Empty;
        public string PaymentMethodProviderType { get; set; } = string.Empty;
     
    }
}
