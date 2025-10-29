using VectorStinger.Core.Domain.DTOs.Security.AccountManager.ValidateToken;
using VectorStinger.Core.Interfaces.Infrastructure.PayBridge;
using VectorStinger.Core.Interfaces.Managers.Security;
using FluentResults;
using VectorStinger.Infrastructure.DataAccess.Interface;
using Microsoft.Extensions.Logging;
using VectorStinger.Foundation.Abstractions.UserCase;
using VectorStinger.Foundation.Utilities.Mapper;

namespace VectorStinger.Application.UserCase.Security.ValidateToken
{
    public class ValidateTokenUseCase : BaseUseCase<ValidateTokenInput, ValidateTokenOutPut, ValidateTokenValidation>
    {
        IAccountManager _accountManager;
        IPaymentTransaction _paymentTransaction;

        public ValidateTokenUseCase(
            ValidateTokenInput userCaseInput,
            ValidateTokenValidation validationRules,
            IRepository repository,
            IAccountManager accountManager,
            IPaymentTransaction paymentTransaction,
             ILogger<ValidateTokenUseCase> logger)
            : base(userCaseInput, validationRules, repository, logger)
        {
            Description = $"Realiza la validacion de un token";
            _accountManager = accountManager;
            _paymentTransaction = paymentTransaction;
        }

        public override async Task<Result<ValidateTokenOutPut>> ExecuteBusinessAsync(ValidateTokenInput input)
        {
            var resulValidation =  _accountManager.ValidateTokenAsync(new ValidateTokenRequest
            {
                Token = input.Token
            });
            if (resulValidation.IsFailed)
            {
                return Result.Fail<ValidateTokenOutPut>(resulValidation.Errors);
            }

            var resul = MapUtil.MapTo<ValidateTokenResponse, ValidateTokenOutPut>(resulValidation.Value);

            return Result.Ok(resul);
        }
    }
}
