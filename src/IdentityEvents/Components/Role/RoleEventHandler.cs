namespace Microsoft.AspNetCore.Identity;

internal class RoleEventHandler<TRole> : IRoleEventHandler<TRole>
    where TRole : class
{
    private readonly RoleEventHandlerOptions<TRole> _options;

    public RoleEventHandler(RoleEventHandlerOptions<TRole> options)
    {
        _options = options;
    }

    public Task OnCreatedAsync(TRole role)
        => _options.OnCreated(role);

    public Task OnUpdatedAsync(TRole role)
        => _options.OnUpdated(role);

    public Task OnDeletedAsync(TRole role)
        => _options.OnDeleted(role);
}
