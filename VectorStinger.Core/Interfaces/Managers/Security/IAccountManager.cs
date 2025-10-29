using VectorStinger.Core.Domain.DTOs.Security.AccountManager.ValidateToken;
using VectorStinger.Core.Domain.DTOs.Security.AccountManager.VerifyCredential;
using VectorStinger.Core.Domain.DTOs.Security.AccountManager.VerifyCredentialOAuth;
using FluentResults;

namespace VectorStinger.Core.Interfaces.Managers.Security
{
    public interface IAccountManager
    {
        Result<VerifyCredentialResponseDTO> VerifyCredentialAsync(VerifyCredentialRequestDTO request);
        Result<ValidateTokenResponse> ValidateTokenAsync(ValidateTokenRequest request);
        Task<Result<VerifyCredentialOAuthResponseDTO>> VerifyCredentialOAuthAsync(VerifyCredentialOAuthRequestDTO request);
    }
}
