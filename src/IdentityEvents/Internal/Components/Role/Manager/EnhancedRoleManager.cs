namespace Microsoft.AspNetCore.Identity;

internal class EnhancedRoleManager<TRole> : ProxyRoleManager<TRole>
    where TRole : class
{
    private readonly IRoleEventHandler<TRole> _eventHandler;

    public EnhancedRoleManager(RoleManager<TRole> target, IRoleEventHandler<TRole> eventHandler)
        : base(target)
    {
        _eventHandler = eventHandler;
    }

    public async override Task<IdentityResult> CreateAsync(TRole role)
    {
        var result = await base.CreateAsync(role);

        if (result.Succeeded)
        {
            await _eventHandler.OnCreatedAsync(role);
        }

        return result;
    }

    public async override Task<IdentityResult> UpdateAsync(TRole role)
    {
        var result = await base.UpdateAsync(role);

        if (result.Succeeded)
        {
            await _eventHandler.OnUpdatedAsync(role);
        }

        return result;
    }

    public async override Task<IdentityResult> DeleteAsync(TRole role)
    {
        var result = await base.DeleteAsync(role);

        if (result.Succeeded)
        {
            await _eventHandler.OnDeletedAsync(role);
        }

        return result;
    }
}
