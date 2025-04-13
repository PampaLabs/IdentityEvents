using System.Security.Claims;

namespace Microsoft.AspNetCore.Identity;

internal abstract class AbstractRoleManager<TRole> : RoleManager<TRole>
    where TRole : class
{
    public AbstractRoleManager(IRoleStore<TRole> store)
        : base(store, null!, null!, null!, null!)
    {
    }

    public abstract override Task<IdentityResult> CreateAsync(TRole role);

    public abstract override Task UpdateNormalizedRoleNameAsync(TRole role);

    public abstract override Task<IdentityResult> UpdateAsync(TRole role);

    public abstract override Task<IdentityResult> DeleteAsync(TRole role);

    public abstract override Task<bool> RoleExistsAsync(string roleName);

    public abstract override string? NormalizeKey(string? key);

    public abstract override Task<TRole?> FindByIdAsync(string roleId);

    public abstract override Task<string?> GetRoleNameAsync(TRole role);

    public abstract override Task<IdentityResult> SetRoleNameAsync(TRole role, string? name);

    public abstract override Task<string> GetRoleIdAsync(TRole role);

    public abstract override Task<TRole?> FindByNameAsync(string roleName);

    public abstract override Task<IdentityResult> AddClaimAsync(TRole role, Claim claim);

    public abstract override Task<IdentityResult> RemoveClaimAsync(TRole role, Claim claim);

    public abstract override Task<IList<Claim>> GetClaimsAsync(TRole role);
}
