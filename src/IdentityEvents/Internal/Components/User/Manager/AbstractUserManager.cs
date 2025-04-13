using System.Security.Claims;

namespace Microsoft.AspNetCore.Identity;

internal abstract class AbstractUserManager<TUser> : UserManager<TUser>
    where TUser : class
{
    public AbstractUserManager(IUserStore<TUser> store)
        : base(store, null!, null!, null!, null!, null!, null!, null!, null!)
    {
    }

    public abstract override string? GetUserName(ClaimsPrincipal principal);

    public abstract override string? GetUserId(ClaimsPrincipal principal);

    public abstract override Task<TUser?> GetUserAsync(ClaimsPrincipal principal);

    public abstract override Task<string> GenerateConcurrencyStampAsync(TUser user);

    public abstract override Task<IdentityResult> CreateAsync(TUser user);

    public abstract override Task<IdentityResult> UpdateAsync(TUser user);

    public abstract override Task<IdentityResult> DeleteAsync(TUser user);

    public abstract override Task<TUser?> FindByIdAsync(string userId);

    public abstract override Task<TUser?> FindByNameAsync(string userName);

    public abstract override Task<IdentityResult> CreateAsync(TUser user, string password);

    public abstract override string? NormalizeName(string? name);

    public abstract override string? NormalizeEmail(string? email);

    public abstract override Task UpdateNormalizedUserNameAsync(TUser user);

    public abstract override Task<string?> GetUserNameAsync(TUser user);

    public abstract override Task<IdentityResult> SetUserNameAsync(TUser user, string? userName);

    public abstract override Task<string> GetUserIdAsync(TUser user);

    public abstract override Task<bool> CheckPasswordAsync(TUser user, string password);

    public abstract override Task<bool> HasPasswordAsync(TUser user);

    public abstract override Task<IdentityResult> AddPasswordAsync(TUser user, string password);

    public abstract override Task<IdentityResult> ChangePasswordAsync(TUser user, string currentPassword, string newPassword);

    public abstract override Task<IdentityResult> RemovePasswordAsync(TUser user);

    public abstract override Task<string> GetSecurityStampAsync(TUser user);

    public abstract override Task<IdentityResult> UpdateSecurityStampAsync(TUser user);

    public abstract override Task<string> GeneratePasswordResetTokenAsync(TUser user);

    public abstract override Task<IdentityResult> ResetPasswordAsync(TUser user, string token, string newPassword);

    public abstract override Task<TUser?> FindByLoginAsync(string loginProvider, string providerKey);

    public abstract override Task<IdentityResult> RemoveLoginAsync(TUser user, string loginProvider, string providerKey);

    public abstract override Task<IdentityResult> AddLoginAsync(TUser user, UserLoginInfo login);

    public abstract override Task<IList<UserLoginInfo>> GetLoginsAsync(TUser user);

    public abstract override Task<IdentityResult> AddClaimAsync(TUser user, Claim claim);

    public abstract override Task<IdentityResult> AddClaimsAsync(TUser user, IEnumerable<Claim> claims);

    public abstract override Task<IdentityResult> ReplaceClaimAsync(TUser user, Claim claim, Claim newClaim);

    public abstract override Task<IdentityResult> RemoveClaimAsync(TUser user, Claim claim);

    public abstract override Task<IdentityResult> RemoveClaimsAsync(TUser user, IEnumerable<Claim> claims);

    public abstract override Task<IList<Claim>> GetClaimsAsync(TUser user);

    public abstract override Task<IdentityResult> AddToRoleAsync(TUser user, string role);

    public abstract override Task<IdentityResult> AddToRolesAsync(TUser user, IEnumerable<string> roles);

    public abstract override Task<IdentityResult> RemoveFromRoleAsync(TUser user, string role);

    public abstract override Task<IdentityResult> RemoveFromRolesAsync(TUser user, IEnumerable<string> roles);

    public abstract override Task<IList<string>> GetRolesAsync(TUser user);

    public abstract override Task<bool> IsInRoleAsync(TUser user, string role);

    public abstract override Task<string?> GetEmailAsync(TUser user);

    public abstract override Task<IdentityResult> SetEmailAsync(TUser user, string? email);

    public abstract override Task<TUser?> FindByEmailAsync(string email);

    public abstract override Task UpdateNormalizedEmailAsync(TUser user);

    public abstract override Task<string> GenerateEmailConfirmationTokenAsync(TUser user);

    public abstract override Task<IdentityResult> ConfirmEmailAsync(TUser user, string token);

    public abstract override Task<bool> IsEmailConfirmedAsync(TUser user);

    public abstract override Task<string> GenerateChangeEmailTokenAsync(TUser user, string newEmail);

    public abstract override Task<IdentityResult> ChangeEmailAsync(TUser user, string newEmail, string token);

    public abstract override Task<string?> GetPhoneNumberAsync(TUser user);

    public abstract override Task<IdentityResult> SetPhoneNumberAsync(TUser user, string? phoneNumber);

    public abstract override Task<IdentityResult> ChangePhoneNumberAsync(TUser user, string phoneNumber, string token);

    public abstract override Task<bool> IsPhoneNumberConfirmedAsync(TUser user);

    public abstract override Task<string> GenerateChangePhoneNumberTokenAsync(TUser user, string phoneNumber);

    public abstract override Task<bool> VerifyChangePhoneNumberTokenAsync(TUser user, string token, string phoneNumber);

    public abstract override Task<bool> VerifyUserTokenAsync(TUser user, string tokenProvider, string purpose, string token);

    public abstract override Task<string> GenerateUserTokenAsync(TUser user, string tokenProvider, string purpose);

    public abstract override void RegisterTokenProvider(string providerName, IUserTwoFactorTokenProvider<TUser> provider);

    public abstract override Task<IList<string>> GetValidTwoFactorProvidersAsync(TUser user);

    public abstract override Task<bool> VerifyTwoFactorTokenAsync(TUser user, string tokenProvider, string token);

    public abstract override Task<string> GenerateTwoFactorTokenAsync(TUser user, string tokenProvider);

    public abstract override Task<bool> GetTwoFactorEnabledAsync(TUser user);

    public abstract override Task<IdentityResult> SetTwoFactorEnabledAsync(TUser user, bool enabled);

    public abstract override Task<bool> IsLockedOutAsync(TUser user);

    public abstract override Task<IdentityResult> SetLockoutEnabledAsync(TUser user, bool enabled);

    public abstract override Task<bool> GetLockoutEnabledAsync(TUser user);

    public abstract override Task<DateTimeOffset?> GetLockoutEndDateAsync(TUser user);

    public abstract override Task<IdentityResult> SetLockoutEndDateAsync(TUser user, DateTimeOffset? lockoutEnd);

    public abstract override Task<IdentityResult> AccessFailedAsync(TUser user);

    public abstract override Task<IdentityResult> ResetAccessFailedCountAsync(TUser user);

    public abstract override Task<int> GetAccessFailedCountAsync(TUser user);

    public abstract override Task<IList<TUser>> GetUsersForClaimAsync(Claim claim);

    public abstract override Task<IList<TUser>> GetUsersInRoleAsync(string roleName);

    public abstract override Task<string?> GetAuthenticationTokenAsync(TUser user, string loginProvider, string tokenName);

    public abstract override Task<IdentityResult> SetAuthenticationTokenAsync(TUser user, string loginProvider, string tokenName, string? tokenValue);

    public abstract override Task<IdentityResult> RemoveAuthenticationTokenAsync(TUser user, string loginProvider, string tokenName);

    public abstract override Task<string?> GetAuthenticatorKeyAsync(TUser user);

    public abstract override Task<IdentityResult> ResetAuthenticatorKeyAsync(TUser user);

    public abstract override string GenerateNewAuthenticatorKey();

    public abstract override Task<IEnumerable<string>?> GenerateNewTwoFactorRecoveryCodesAsync(TUser user, int number);

    public abstract override Task<IdentityResult> RedeemTwoFactorRecoveryCodeAsync(TUser user, string code);

    public abstract override Task<int> CountRecoveryCodesAsync(TUser user);

    public abstract override Task<byte[]> CreateSecurityTokenAsync(TUser user);
}
