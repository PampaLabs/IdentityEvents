namespace Microsoft.AspNetCore.Identity;

internal class EnhancedUserManager<TUser> : ProxyUserManager<TUser>
    where TUser : class
{
    private readonly IUserEventHandler<TUser> _eventHandler;

    public EnhancedUserManager(UserManager<TUser> target, IUserEventHandler<TUser> eventHandler)
        : base(target)
    {
        _eventHandler = eventHandler;
    }

    public async override Task<IdentityResult> CreateAsync(TUser user)
    {
        var result = await base.CreateAsync(user);

        if (result.Succeeded)
        {
            await _eventHandler.OnCreatedAsync(user);
        }

        return result;
    }

    public async override Task<IdentityResult> UpdateAsync(TUser user)
    {
        var result = await base.UpdateAsync(user);

        if (result.Succeeded)
        {
            await _eventHandler.OnUpdatedAsync(user);
        }

        return result;
    }

    public async override Task<IdentityResult> DeleteAsync(TUser user)
    {
        var result = await base.DeleteAsync(user);

        if (result.Succeeded)
        {
            await _eventHandler.OnDeletedAsync(user);
        }

        return result;
    }
}
