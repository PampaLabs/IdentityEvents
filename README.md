# IdentityEvents

This package enabled event handling in applications using `ASP.NET Core Identity`.

## Installation

To use this extension with `ASP.NET Core`, you will first need to install the package.

```
dotnet add package IdentityEvents
```

## Usage

Configure the event handlers for user and role events by chaining the methods to the `IdentityBuilder`.

```csharp
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
    {
        // Identity options setup
    })
    .AddUserEvents<ApplicationUser>(options =>
    {
        options.OnCreated = async user => { /* Custom logic for user creation */ };
        options.OnUpdated = async user => { /* Custom logic for user update */ };
        options.OnDeleted = async user => { /* Custom logic for user deletion */ };
    })
    .AddRoleEvents<ApplicationRole>(options =>
    {
        options.OnCreated = async role => { /* Custom logic for role creation */ };
        options.OnUpdated = async role => { /* Custom logic for role update */ };
        options.OnDeleted = async role => { /* Custom logic for role deletion */ };
    });
```

## Contributing

Contributions are welcome! Please open an issue or submit a pull request on GitHub.
