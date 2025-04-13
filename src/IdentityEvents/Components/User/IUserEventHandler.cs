namespace Microsoft.AspNetCore.Identity;

/// <summary>
/// Defines event handlers for user events such as creation, update, and deletion.
/// </summary>
/// <typeparam name="TUser">The type of the user entity.</typeparam>
public interface IUserEventHandler<TUser>
    where TUser : class
{
    /// <summary>
    /// Handles the event when a user is created asynchronously.
    /// </summary>
    /// <param name="user">The <typeparamref name="TUser"/> that was created.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task OnCreatedAsync(TUser user);

    /// <summary>
    /// Handles the event when a user is updated asynchronously.
    /// </summary>
    /// <param name="user">The <typeparamref name="TUser"/> that was updated.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task OnUpdatedAsync(TUser user);

    /// <summary>
    /// Handles the event when a user is deleted asynchronously.
    /// </summary>
    /// <param name="user">The <typeparamref name="TUser"/> that was deleted.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task OnDeletedAsync(TUser user);
}
