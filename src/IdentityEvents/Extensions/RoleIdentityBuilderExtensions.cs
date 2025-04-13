using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.AspNetCore.Identity;

/// <summary>
/// Extension methods for <see cref="IdentityBuilder"/> to add role event handlers to the identity configuration.
/// </summary>
public static class RoleIdentityBuilderExtensions
{
    /// <summary>
    /// Adds role events to the <see cref="IdentityBuilder"/> by configuring a <see cref="RoleEventHandler{TRole}"/>.
    /// </summary>
    /// <typeparam name="TRole">The type of the role entity.</typeparam>
    /// <param name="builder">The <see cref="IdentityBuilder"/> instance to add role events to.</param>
    /// <param name="optionsAction">An action to configure the <see cref="RoleEventHandlerOptions{TRole}"/>.</param>
    /// <returns>The <see cref="IdentityBuilder"/> instance with the role events added.</returns>
    public static IdentityBuilder AddRoleEvents<TRole>(this IdentityBuilder builder, Action<RoleEventHandlerOptions<TRole>> optionsAction)
        where TRole : class
    {
        return ConfigureServices(builder, _ =>
        {
            var options = optionsAction.Build();
            return new RoleEventHandler<TRole>(options);
        });
    }

    /// <summary>
    /// Adds role events to the <see cref="IdentityBuilder"/> by configuring a <see cref="RoleEventHandler{TRole}"/> with access to <see cref="IServiceProvider"/>.
    /// </summary>
    /// <typeparam name="TRole">The type of the role entity.</typeparam>
    /// <param name="builder">The <see cref="IdentityBuilder"/> instance to add role events to.</param>
    /// <param name="optionsAction">An action to configure the <see cref="RoleEventHandlerOptions{TRole}"/> using an <see cref="IServiceProvider"/>.</param>
    /// <returns>The <see cref="IdentityBuilder"/> instance with the role events added.</returns>
    public static IdentityBuilder AddRoleEvents<TRole>(this IdentityBuilder builder, Action<IServiceProvider, RoleEventHandlerOptions<TRole>> optionsAction)
        where TRole : class
    {
        return ConfigureServices(builder, sp =>
        {
            var options = optionsAction.Build(sp);
            return new RoleEventHandler<TRole>(options);
        });
    }

    /// <summary>
    /// Adds a custom <see cref="IRoleEventHandler{TRole}"/> to the <see cref="IdentityBuilder"/>.
    /// </summary>
    /// <typeparam name="TRole">The type of the role entity.</typeparam>
    /// <typeparam name="TRoleEventHandler">The type of the custom role event handler implementing <see cref="IRoleEventHandler{TRole}"/>.</typeparam>
    /// <param name="builder">The <see cref="IdentityBuilder"/> instance to add role events to.</param>
    /// <returns>The <see cref="IdentityBuilder"/> instance with the custom role event handler added.</returns>
    public static IdentityBuilder AddRoleEvents<TRole, TRoleEventHandler>(this IdentityBuilder builder)
        where TRole : class
        where TRoleEventHandler : class, IRoleEventHandler<TRole>
    {
        return ConfigureServices(builder, sp => ActivatorUtilities.CreateInstance<TRoleEventHandler>(sp));
    }

    /// <summary>
    /// Configures services for adding role event handlers to the <see cref="IdentityBuilder"/>.
    /// </summary>
    /// <typeparam name="TRole">The type of the role entity.</typeparam>
    /// <param name="builder">The <see cref="IdentityBuilder"/> instance to configure.</param>
    /// <param name="eventHandlerFactory">A factory function to create an instance of <see cref="IRoleEventHandler{TRole}"/>.</param>
    /// <returns>The <see cref="IdentityBuilder"/> instance with the configured services.</returns>
    private static IdentityBuilder ConfigureServices<TRole>(IdentityBuilder builder, Func<IServiceProvider, IRoleEventHandler<TRole>> eventHandlerFactory)
        where TRole : class
    {
        _ = builder ?? throw new ArgumentNullException(nameof(builder));

        if (builder.RoleType == null)
        {
            throw new InvalidOperationException("No RoleType was specified, try AddRoles<TRole>().");
        }

        if (builder.RoleType != typeof(TRole))
        {
            throw new InvalidOperationException($"Type {typeof(TRole)} does not match {builder.RoleType}.");
        }

        var managerType = typeof(RoleManager<TRole>);
        var managerServiceDescriptor = builder.Services.Last(service => service.ServiceType == managerType);
        var implementationType = managerServiceDescriptor.ImplementationType!;

        builder.Services.AddScoped<RoleManager<TRole>>(sp =>
        {
            var target = (RoleManager<TRole>)ActivatorUtilities.CreateInstance(sp, implementationType);
            var eventHandler = eventHandlerFactory(sp);

            return new EnhancedRoleManager<TRole>(target, eventHandler);
        });

        return builder;
    }
}
