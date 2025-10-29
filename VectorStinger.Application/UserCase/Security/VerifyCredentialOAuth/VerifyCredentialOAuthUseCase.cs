﻿using VectorStinger.Core.Domain.DTOs.Security.AccountManager.VerifyCredential;
using VectorStinger.Core.Domain.DTOs.Security.AccountManager.VerifyCredentialOAuth;
using VectorStinger.Core.Interfaces.Managers.Security;
using FluentResults;
using VectorStinger.Infrastructure.DataAccess.Interface;
using Microsoft.Extensions.Logging;
using VectorStinger.Foundation.Abstractions.UserCase;

namespace VectorStinger.Application.UserCase.Security.VerifyCredentialOAuth
{
    public class VerifyCredentialOAuthUseCase : BaseUseCase<VerifyCredentialOAuthInput, VerifyCredentialOAuthOutput, VerifyCredentialOAuthValidation>
    {
        IAccountManager _accountManager;
        public VerifyCredentialOAuthUseCase(VerifyCredentialOAuthInput _userCaseInput, VerifyCredentialOAuthValidation _validationRules,
            IRepository repository, IAccountManager accountManager, ILogger<VerifyCredentialOAuthUseCase> logger) :
            base(_userCaseInput, _validationRules, repository, logger)
        {
            Description = $"Valida la credencial del administrador del sistema";
            _accountManager = accountManager;
        }

        public override async Task<Result<VerifyCredentialOAuthOutput>> ExecuteBusinessAsync(VerifyCredentialOAuthInput input)
        {
            var resultAuthentication = await _accountManager.VerifyCredentialOAuthAsync(new VerifyCredentialOAuthRequestDTO
            {
                Provider = input.Provider,
                Token = input.Token,
            });

            if (resultAuthentication.IsFailed)
            {
                return Result.Fail<VerifyCredentialOAuthOutput>(resultAuthentication.Errors);
            }

            var verifyCredentialOutput = new VerifyCredentialOAuthOutput
            {
                IsValid = true,
                IdUser = resultAuthentication.Value.IdUser,
                Token = resultAuthentication.Value.Token,
                Expiration = resultAuthentication.Value.Expiration,
                Message = resultAuthentication.Value.Message,
                NamePerson = resultAuthentication.Value.NamePerson,
                PictureUrl = resultAuthentication.Value.PictureUrl,
                IdSession = resultAuthentication.Value.IdSesion
            };

            return Result.Ok(verifyCredentialOutput);
        }
    }
}
