namespace Microsoft.AspNetCore.Identity;

internal class UserEventHandler<TUser> : IUserEventHandler<TUser>
    where TUser : class
{
    private readonly UserEventHandlerOptions<TUser> _options;

    public UserEventHandler(UserEventHandlerOptions<TUser> options)
    {
        _options = options;
    }

    public Task OnCreatedAsync(TUser user)
        => _options.OnCreated(user);

    public Task OnUpdatedAsync(TUser user)
        => _options.OnUpdated(user);

    public Task OnDeletedAsync(TUser user)
        => _options.OnDeleted(user);
}
