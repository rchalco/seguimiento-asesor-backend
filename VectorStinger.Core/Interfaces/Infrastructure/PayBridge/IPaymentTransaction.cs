using VectorStinger.Core.Interfaces.Infrastructure.PayBridge.PayTransaction;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorStinger.Core.Interfaces.Infrastructure.PayBridge
{
    public interface IPaymentTransaction
    {
        Task<Result<PaymentTransactionResponse>> PayTransaction(PaymentTransactionRequest paymentTransactionRequest);
    }
}
