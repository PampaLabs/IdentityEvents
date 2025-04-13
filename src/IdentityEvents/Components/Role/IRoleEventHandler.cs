namespace Microsoft.AspNetCore.Identity;

/// <summary>
/// Defines event handlers for role events such as creation, update, and deletion.
/// </summary>
/// <typeparam name="TRole">The type of the role entity.</typeparam>
public interface IRoleEventHandler<TRole>
    where TRole : class
{
    /// <summary>
    /// Handles the event when a role is created asynchronously.
    /// </summary>
    /// <param name="role">The <typeparamref name="TRole"/> that was created.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task OnCreatedAsync(TRole role);

    /// <summary>
    /// Handles the event when a role is updated asynchronously.
    /// </summary>
    /// <param name="role">The <typeparamref name="TRole"/> that was updated.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task OnUpdatedAsync(TRole role);

    /// <summary>
    /// Handles the event when a role is deleted asynchronously.
    /// </summary>
    /// <param name="role">The <typeparamref name="TRole"/> that was deleted.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task OnDeletedAsync(TRole role);
}
