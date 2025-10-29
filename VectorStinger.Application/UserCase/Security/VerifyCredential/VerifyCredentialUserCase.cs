using VectorStinger.Application.UserCase.Security.ValidateToken;
using VectorStinger.Core.Domain.DTOs.Security.AccountManager.VerifyCredential;
using VectorStinger.Core.Interfaces.Managers.Security;
using FluentResults;
using VectorStinger.Infrastructure.DataAccess.Interface;
using Microsoft.Extensions.Logging;
using VectorStinger.Foundation.Abstractions.UserCase;

namespace VectorStinger.Application.UserCase.Security.VerifyCredential
{
    public class VerifyCredentialUseCase : BaseUseCase<VerifyCredentialInput, VerifyCredentialOutput, VerifyCredentialValidation>
    {
        private readonly IAccountManager _accountManager;

        public VerifyCredentialUseCase(VerifyCredentialInput userCaseInput,
            VerifyCredentialValidation validationRules,
            IRepository repository,
            IAccountManager accountManager,
             ILogger<VerifyCredentialUseCase> logger)
            : base(userCaseInput, validationRules, repository, logger)
        {
            Description = "Valida la credencial del administrador del sistema";
            _accountManager = accountManager;
        }

        public override async Task<Result<VerifyCredentialOutput>> ExecuteBusinessAsync(VerifyCredentialInput input)
        {
            var resultAuthentication =  _accountManager.VerifyCredentialAsync(new VerifyCredentialRequestDTO
            {
                User = input.User,
                Password = input.Password,
                VersionApplication = input.VersionApplication
            });

            if (resultAuthentication.IsFailed)
            {
                return Result.Fail<VerifyCredentialOutput>(resultAuthentication.Errors);
            }

            var verifyCredentialOutput = new VerifyCredentialOutput
            {
                IsValid = true,
                Token = resultAuthentication.Value.Token,
                Expiration = resultAuthentication.Value.Expiration,
                Message = resultAuthentication.Value.Message
            };

            return Result.Ok(verifyCredentialOutput);
        }
    }
}
