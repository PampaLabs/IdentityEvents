using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.AspNetCore.Identity;

/// <summary>
/// Extension methods for <see cref="IdentityBuilder"/> to add user event handlers to the identity configuration.
/// </summary>
public static class UserIdentityBuilderExtensions
{
    /// <summary>
    /// Adds user events to the <see cref="IdentityBuilder"/> by configuring a <see cref="UserEventHandler{TUser}"/>.
    /// </summary>
    /// <typeparam name="TUser">The type of the user entity.</typeparam>
    /// <param name="builder">The <see cref="IdentityBuilder"/> instance to add user events to.</param>
    /// <param name="optionsAction">An action to configure the <see cref="UserEventHandlerOptions{TUser}"/>.</param>
    /// <returns>The <see cref="IdentityBuilder"/> instance with the user events added.</returns>
    public static IdentityBuilder AddUserEvents<TUser>(this IdentityBuilder builder, Action<UserEventHandlerOptions<TUser>> optionsAction)
        where TUser : class
    {
        return ConfigureServices(builder, sp =>
        {
            var options = optionsAction.Build();
            return new UserEventHandler<TUser>(options);
        });
    }

    /// <summary>
    /// Adds user events to the <see cref="IdentityBuilder"/> by configuring a <see cref="UserEventHandler{TUser}"/> with access to <see cref="IServiceProvider"/>.
    /// </summary>
    /// <typeparam name="TUser">The type of the user entity.</typeparam>
    /// <param name="builder">The <see cref="IdentityBuilder"/> instance to add user events to.</param>
    /// <param name="optionsAction">An action to configure the <see cref="UserEventHandlerOptions{TUser}"/> using an <see cref="IServiceProvider"/>.</param>
    /// <returns>The <see cref="IdentityBuilder"/> instance with the user events added.</returns>
    public static IdentityBuilder AddUserEvents<TUser>(this IdentityBuilder builder, Action<IServiceProvider, UserEventHandlerOptions<TUser>> optionsAction)
        where TUser : class
    {
        return ConfigureServices(builder, sp =>
        {
            var options = optionsAction.Build(sp);
            return new UserEventHandler<TUser>(options);
        });
    }

    /// <summary>
    /// Adds a custom <see cref="IUserEventHandler{TUser}"/> to the <see cref="IdentityBuilder"/>.
    /// </summary>
    /// <typeparam name="TUser">The type of the user entity.</typeparam>
    /// <typeparam name="TUserEventHandler">The type of the custom user event handler implementing <see cref="IUserEventHandler{TUser}"/>.</typeparam>
    /// <param name="builder">The <see cref="IdentityBuilder"/> instance to add user events to.</param>
    /// <returns>The <see cref="IdentityBuilder"/> instance with the custom user event handler added.</returns>
    public static IdentityBuilder AddUserEvents<TUser, TUserEventHandler>(this IdentityBuilder builder)
        where TUser : class
        where TUserEventHandler : class, IUserEventHandler<TUser>
    {
        return ConfigureServices(builder, sp => ActivatorUtilities.CreateInstance<TUserEventHandler>(sp));
    }

    /// <summary>
    /// Configures services for adding user event handlers to the <see cref="IdentityBuilder"/>.
    /// </summary>
    /// <typeparam name="TUser">The type of the user entity.</typeparam>
    /// <param name="builder">The <see cref="IdentityBuilder"/> instance to configure.</param>
    /// <param name="eventHandlerFactory">A factory function to create an instance of <see cref="IUserEventHandler{TUser}"/>.</param>
    /// <returns>The <see cref="IdentityBuilder"/> instance with the configured services.</returns>
    private static IdentityBuilder ConfigureServices<TUser>(IdentityBuilder builder, Func<IServiceProvider, IUserEventHandler<TUser>> eventHandlerFactory)
        where TUser : class
    {
        _ = builder ?? throw new ArgumentNullException(nameof(builder));

        if (builder.UserType != typeof(TUser))
        {
            throw new InvalidOperationException($"Type {typeof(TUser)} does not match {builder.UserType}.");
        }

        var managerType = typeof(UserManager<TUser>);
        var managerServiceDescriptor = builder.Services.Last(service => service.ServiceType == managerType);
        var implementationType = managerServiceDescriptor.ImplementationType!;

        builder.Services.AddScoped<UserManager<TUser>>(sp =>
        {
            var target = (UserManager<TUser>)ActivatorUtilities.CreateInstance(sp, implementationType);
            var eventHandler = eventHandlerFactory(sp);

            return new EnhancedUserManager<TUser>(target, eventHandler);
        });

        return builder;
    }
}
