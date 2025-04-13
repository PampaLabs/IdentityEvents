namespace Microsoft.AspNetCore.Identity;

/// <summary>
/// Options for configuring role event handlers for <see cref="IRoleEventHandler{T}"/>.
/// </summary>
/// <typeparam name="T">The type of the role entity.</typeparam>
public class RoleEventHandlerOptions<T>
    where T : class
{
    /// <summary>
    /// The event handler to execute when a role is created.
    /// </summary>
    public IdentityEventHandler<T> OnCreated { get; set; }

    /// <summary>
    /// The event handler to execute when a role is updated.
    /// </summary>
    public IdentityEventHandler<T> OnUpdated { get; set; }

    /// <summary>
    /// The event handler to execute when a role is deleted.
    /// </summary>
    public IdentityEventHandler<T> OnDeleted { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="RoleEventHandlerOptions{T}"/>.
    /// Sets default handlers for creation, update, and deletion events, which do nothing.
    /// </summary>
    public RoleEventHandlerOptions()
    {
        OnCreated = _ => Task.CompletedTask;
        OnUpdated = _ => Task.CompletedTask;
        OnDeleted = _ => Task.CompletedTask;
    }
}
