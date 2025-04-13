namespace Microsoft.AspNetCore.Identity;

/// <summary>
/// Represents a handler for identity events that can process an event asynchronously.
/// </summary>
/// <typeparam name="T">The type of the item being handled by the event handler.</typeparam>
/// <param name="item">The item being passed to the event handler.</param>
/// <returns>A task representing the asynchronous operation.</returns>
public delegate Task IdentityEventHandler<T>(T item);
