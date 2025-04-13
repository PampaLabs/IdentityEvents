using System.Security.Claims;

namespace Microsoft.AspNetCore.Identity;

internal class ProxyRoleManager<TRole> : AbstractRoleManager<TRole>
    where TRole : class
{
    private readonly RoleManager<TRole> _target;

    public ProxyRoleManager(RoleManager<TRole> target)
        : base(new DummyRoleStore<TRole>())
    {
        ArgumentNullException.ThrowIfNull(target);

        _target = target;
    }

    public override Task<IdentityResult> CreateAsync(TRole role)
        => _target.CreateAsync(role);

    public override Task UpdateNormalizedRoleNameAsync(TRole role)
        => _target.UpdateNormalizedRoleNameAsync(role);

    public override Task<IdentityResult> UpdateAsync(TRole role)
        => _target.UpdateAsync(role);

    public override Task<IdentityResult> DeleteAsync(TRole role)
        => _target.DeleteAsync(role);

    public override Task<bool> RoleExistsAsync(string roleName)
        => _target.RoleExistsAsync(roleName);

    public override string? NormalizeKey(string? key)
        => _target.NormalizeKey(key);

    public override Task<TRole?> FindByIdAsync(string roleId)
        => _target.FindByIdAsync(roleId);

    public override Task<string?> GetRoleNameAsync(TRole role)
        => _target.GetRoleNameAsync(role);

    public override Task<IdentityResult> SetRoleNameAsync(TRole role, string? name)
        => _target.SetRoleNameAsync(role, name);

    public override Task<string> GetRoleIdAsync(TRole role)
        => _target.GetRoleIdAsync(role);

    public override Task<TRole?> FindByNameAsync(string roleName)
        => _target.FindByNameAsync(roleName);

    public override Task<IdentityResult> AddClaimAsync(TRole role, Claim claim)
        => _target.AddClaimAsync(role, claim);

    public override Task<IdentityResult> RemoveClaimAsync(TRole role, Claim claim)
        => _target.RemoveClaimAsync(role, claim);

    public override Task<IList<Claim>> GetClaimsAsync(TRole role)
        => _target.GetClaimsAsync(role);
}
