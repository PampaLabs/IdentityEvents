using System.Security.Claims;

namespace Microsoft.AspNetCore.Identity;

internal class ProxyUserManager<TUser> : AbstractUserManager<TUser>
    where TUser : class
{
    private readonly UserManager<TUser> _target;

    public ProxyUserManager(UserManager<TUser> target)
        : base(new DummyUserStore<TUser>())
    {
        ArgumentNullException.ThrowIfNull(target);

        _target = target;
    }

    public override string? GetUserName(ClaimsPrincipal principal)
        => _target.GetUserName(principal);

    public override string? GetUserId(ClaimsPrincipal principal)
        => _target.GetUserId(principal);

    public override Task<TUser?> GetUserAsync(ClaimsPrincipal principal)
        => _target.GetUserAsync(principal);

    public override Task<string> GenerateConcurrencyStampAsync(TUser user)
        => _target.GenerateConcurrencyStampAsync(user);

    public override Task<IdentityResult> CreateAsync(TUser user)
        => _target.CreateAsync(user);

    public override Task<IdentityResult> UpdateAsync(TUser user)
        => _target.UpdateAsync(user);

    public override Task<IdentityResult> DeleteAsync(TUser user)
        => _target.DeleteAsync(user);

    public override Task<TUser?> FindByIdAsync(string userId)
        => _target.FindByIdAsync(userId);

    public override Task<TUser?> FindByNameAsync(string userName)
        => _target.FindByNameAsync(userName);

    public override Task<IdentityResult> CreateAsync(TUser user, string password)
        => _target.CreateAsync(user, password);

    public override string? NormalizeName(string? name)
        => _target.NormalizeName(name);

    public override string? NormalizeEmail(string? email)
        => _target.NormalizeEmail(email);

    public override Task UpdateNormalizedUserNameAsync(TUser user)
        => _target.UpdateNormalizedUserNameAsync(user);

    public override Task<string?> GetUserNameAsync(TUser user)
        => _target.GetUserNameAsync(user);

    public override Task<IdentityResult> SetUserNameAsync(TUser user, string? userName)
        => _target.SetUserNameAsync(user, userName);

    public override Task<string> GetUserIdAsync(TUser user)
        => _target.GetUserIdAsync(user);

    public override Task<bool> CheckPasswordAsync(TUser user, string password)
        => _target.CheckPasswordAsync(user, password);

    public override Task<bool> HasPasswordAsync(TUser user)
        => _target.HasPasswordAsync(user);

    public override Task<IdentityResult> AddPasswordAsync(TUser user, string password)
        => _target.AddPasswordAsync(user, password);

    public override Task<IdentityResult> ChangePasswordAsync(TUser user, string currentPassword, string newPassword)
        => _target.ChangePasswordAsync(user, currentPassword, newPassword);

    public override Task<IdentityResult> RemovePasswordAsync(TUser user)
        => _target.RemovePasswordAsync(user);

    public override Task<string> GetSecurityStampAsync(TUser user)
        => _target.GetSecurityStampAsync(user);

    public override Task<IdentityResult> UpdateSecurityStampAsync(TUser user)
        => _target.UpdateSecurityStampAsync(user);

    public override Task<string> GeneratePasswordResetTokenAsync(TUser user)
        => _target.GeneratePasswordResetTokenAsync(user);

    public override Task<IdentityResult> ResetPasswordAsync(TUser user, string token, string newPassword)
        => _target.ResetPasswordAsync(user, token, newPassword);

    public override Task<TUser?> FindByLoginAsync(string loginProvider, string providerKey)
        => _target.FindByLoginAsync(loginProvider, providerKey);

    public override Task<IdentityResult> RemoveLoginAsync(TUser user, string loginProvider, string providerKey)
        => _target.RemoveLoginAsync(user, loginProvider, providerKey);

    public override Task<IdentityResult> AddLoginAsync(TUser user, UserLoginInfo login)
        => _target.AddLoginAsync(user, login);

    public override Task<IList<UserLoginInfo>> GetLoginsAsync(TUser user)
        => _target.GetLoginsAsync(user);

    public override Task<IdentityResult> AddClaimAsync(TUser user, Claim claim)
        => _target.AddClaimAsync(user, claim);

    public override Task<IdentityResult> AddClaimsAsync(TUser user, IEnumerable<Claim> claims)
        => _target.AddClaimsAsync(user, claims);

    public override Task<IdentityResult> ReplaceClaimAsync(TUser user, Claim claim, Claim newClaim)
        => _target.ReplaceClaimAsync(user, claim, newClaim);

    public override Task<IdentityResult> RemoveClaimAsync(TUser user, Claim claim)
        => _target.RemoveClaimAsync(user, claim);

    public override Task<IdentityResult> RemoveClaimsAsync(TUser user, IEnumerable<Claim> claims)
        => _target.RemoveClaimsAsync(user, claims);

    public override Task<IList<Claim>> GetClaimsAsync(TUser user)
        => _target.GetClaimsAsync(user);

    public override Task<IdentityResult> AddToRoleAsync(TUser user, string role)
        => _target.AddToRoleAsync(user, role);

    public override Task<IdentityResult> AddToRolesAsync(TUser user, IEnumerable<string> roles)
        => _target.AddToRolesAsync(user, roles);

    public override Task<IdentityResult> RemoveFromRoleAsync(TUser user, string role)
        => _target.RemoveFromRoleAsync(user, role);

    public override Task<IdentityResult> RemoveFromRolesAsync(TUser user, IEnumerable<string> roles)
        => _target.RemoveFromRolesAsync(user, roles);

    public override Task<IList<string>> GetRolesAsync(TUser user)
        => _target.GetRolesAsync(user);

    public override Task<bool> IsInRoleAsync(TUser user, string role)
        => _target.IsInRoleAsync(user, role);

    public override Task<string?> GetEmailAsync(TUser user)
        => _target.GetEmailAsync(user);

    public override Task<IdentityResult> SetEmailAsync(TUser user, string? email)
        => _target.SetEmailAsync(user, email);

    public override Task<TUser?> FindByEmailAsync(string email)
        => _target.FindByEmailAsync(email);

    public override Task UpdateNormalizedEmailAsync(TUser user)
        => _target.UpdateNormalizedEmailAsync(user);

    public override Task<string> GenerateEmailConfirmationTokenAsync(TUser user)
        => _target.GenerateEmailConfirmationTokenAsync(user);

    public override Task<IdentityResult> ConfirmEmailAsync(TUser user, string token)
        => _target.ConfirmEmailAsync(user, token);

    public override Task<bool> IsEmailConfirmedAsync(TUser user)
        => _target.IsEmailConfirmedAsync(user);

    public override Task<string> GenerateChangeEmailTokenAsync(TUser user, string newEmail)
        => _target.GenerateChangeEmailTokenAsync(user, newEmail);

    public override Task<IdentityResult> ChangeEmailAsync(TUser user, string newEmail, string token)
        => _target.ChangeEmailAsync(user, newEmail, token);

    public override Task<string?> GetPhoneNumberAsync(TUser user)
        => _target.GetPhoneNumberAsync(user);

    public override Task<IdentityResult> SetPhoneNumberAsync(TUser user, string? phoneNumber)
        => _target.SetPhoneNumberAsync(user, phoneNumber);

    public override Task<IdentityResult> ChangePhoneNumberAsync(TUser user, string phoneNumber, string token)
        => _target.ChangePhoneNumberAsync(user, phoneNumber, token);

    public override Task<bool> IsPhoneNumberConfirmedAsync(TUser user)
        => _target.IsPhoneNumberConfirmedAsync(user);

    public override Task<string> GenerateChangePhoneNumberTokenAsync(TUser user, string phoneNumber)
        => _target.GenerateChangePhoneNumberTokenAsync(user, phoneNumber);

    public override Task<bool> VerifyChangePhoneNumberTokenAsync(TUser user, string token, string phoneNumber)
        => _target.VerifyChangePhoneNumberTokenAsync(user, token, phoneNumber);

    public override Task<bool> VerifyUserTokenAsync(TUser user, string tokenProvider, string purpose, string token)
        => _target.VerifyUserTokenAsync(user, tokenProvider, purpose, token);

    public override Task<string> GenerateUserTokenAsync(TUser user, string tokenProvider, string purpose)
        => _target.GenerateUserTokenAsync(user, tokenProvider, purpose);

    public override void RegisterTokenProvider(string providerName, IUserTwoFactorTokenProvider<TUser> provider)
        => _target.RegisterTokenProvider(providerName, provider);

    public override Task<IList<string>> GetValidTwoFactorProvidersAsync(TUser user)
        => _target.GetValidTwoFactorProvidersAsync(user);

    public override Task<bool> VerifyTwoFactorTokenAsync(TUser user, string tokenProvider, string token)
        => _target.VerifyTwoFactorTokenAsync(user, tokenProvider, token);

    public override Task<string> GenerateTwoFactorTokenAsync(TUser user, string tokenProvider)
        => _target.GenerateTwoFactorTokenAsync(user, tokenProvider);

    public override Task<bool> GetTwoFactorEnabledAsync(TUser user)
        => _target.GetTwoFactorEnabledAsync(user);

    public override Task<IdentityResult> SetTwoFactorEnabledAsync(TUser user, bool enabled)
        => _target.SetTwoFactorEnabledAsync(user, enabled);

    public override Task<bool> IsLockedOutAsync(TUser user)
        => _target.IsLockedOutAsync(user);

    public override Task<IdentityResult> SetLockoutEnabledAsync(TUser user, bool enabled)
        => _target.SetLockoutEnabledAsync(user, enabled);

    public override Task<bool> GetLockoutEnabledAsync(TUser user)
        => _target.GetLockoutEnabledAsync(user);

    public override Task<DateTimeOffset?> GetLockoutEndDateAsync(TUser user)
        => _target.GetLockoutEndDateAsync(user);

    public override Task<IdentityResult> SetLockoutEndDateAsync(TUser user, DateTimeOffset? lockoutEnd)
        => _target.SetLockoutEndDateAsync(user, lockoutEnd);

    public override Task<IdentityResult> AccessFailedAsync(TUser user)
        => _target.AccessFailedAsync(user);

    public override Task<IdentityResult> ResetAccessFailedCountAsync(TUser user)
        => _target.ResetAccessFailedCountAsync(user);

    public override Task<int> GetAccessFailedCountAsync(TUser user)
        => _target.GetAccessFailedCountAsync(user);

    public override Task<IList<TUser>> GetUsersForClaimAsync(Claim claim)
        => _target.GetUsersForClaimAsync(claim);

    public override Task<IList<TUser>> GetUsersInRoleAsync(string roleName)
        => _target.GetUsersInRoleAsync(roleName);

    public override Task<string?> GetAuthenticationTokenAsync(TUser user, string loginProvider, string tokenName)
        => _target.GetAuthenticationTokenAsync(user, loginProvider, tokenName);

    public override Task<IdentityResult> SetAuthenticationTokenAsync(TUser user, string loginProvider, string tokenName, string? tokenValue)
        => _target.SetAuthenticationTokenAsync(user, loginProvider, tokenName, tokenValue);

    public override Task<IdentityResult> RemoveAuthenticationTokenAsync(TUser user, string loginProvider, string tokenName)
        => _target.RemoveAuthenticationTokenAsync(user, loginProvider, tokenName);

    public override Task<string?> GetAuthenticatorKeyAsync(TUser user)
        => _target.GetAuthenticatorKeyAsync(user);

    public override Task<IdentityResult> ResetAuthenticatorKeyAsync(TUser user)
        => _target.ResetAuthenticatorKeyAsync(user);

    public override string GenerateNewAuthenticatorKey()
        => _target.GenerateNewAuthenticatorKey();

    public override Task<IEnumerable<string>?> GenerateNewTwoFactorRecoveryCodesAsync(TUser user, int number)
        => _target.GenerateNewTwoFactorRecoveryCodesAsync(user, number);

    public override Task<IdentityResult> RedeemTwoFactorRecoveryCodeAsync(TUser user, string code)
        => _target.RedeemTwoFactorRecoveryCodeAsync(user, code);

    public override Task<int> CountRecoveryCodesAsync(TUser user)
        => _target.CountRecoveryCodesAsync(user);

    public override Task<byte[]> CreateSecurityTokenAsync(TUser user)
        => _target.CreateSecurityTokenAsync(user);
}
