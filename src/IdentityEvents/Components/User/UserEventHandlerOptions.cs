namespace Microsoft.AspNetCore.Identity;

/// <summary>
/// Options for configuring user event handlers for <see cref="IUserEventHandler{T}"/>.
/// </summary>
/// <typeparam name="T">The type of the user entity.</typeparam>
public class UserEventHandlerOptions<T>
    where T : class
{
    /// <summary>
    /// The event handler to execute when a user is created.
    /// </summary>
    public IdentityEventHandler<T> OnCreated { get; set; }

    /// <summary>
    /// The event handler to execute when a user is updated.
    /// </summary>
    public IdentityEventHandler<T> OnUpdated { get; set; }

    /// <summary>
    /// The event handler to execute when a user is deleted.
    /// </summary>
    public IdentityEventHandler<T> OnDeleted { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="UserEventHandlerOptions{T}"/>.
    /// Sets default handlers for creation, update, and deletion events, which do nothing.
    /// </summary>
    public UserEventHandlerOptions()
    {
        OnCreated = _ => Task.CompletedTask;
        OnUpdated = _ => Task.CompletedTask;
        OnDeleted = _ => Task.CompletedTask;
    }
}
