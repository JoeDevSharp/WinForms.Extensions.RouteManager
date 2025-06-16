# 📚 JoeDevSharp.WinForms.Extensions.RouteManager

## Overview

`RouteManager` is a flexible navigation framework designed for WinForms applications, enabling structured, declarative routing between views. It supports:

- Centralized route definitions
- Multiple navigation modes (embedded, modal, integrated, etc.)
- Access control and route guards
- Route injection and dynamic component instantiation
- History tracking (optional)

---

## 🚀 Quick Start

### ✅ Step 1: Define Routes

Define all available routes in your application using the fluent `RouteBuilder` syntax. Here's a clean, real-world example using nested routes with descriptions and navigation types.

```csharp
internal static class AppRoutes
{
    public static Routes Main => new()
    {
        RouteBuilder<Users>.Create("Users")
            .WithTitle("Utilisateurs")
            .WithDescription("Gestion des utilisateurs")
            .WithChildren([
                RouteBuilder<UserDetails>.Create("UserDetails")
                    .WithTitle("Détails de l'utilisateur")
                    .WithDescription("Affiche les détails d'un utilisateur spécifique.")
                    .Build(),

                RouteBuilder<UserSettings>.Create("UserSettings")
                    .WithTitle("Paramètres de l'utilisateur")
                    .WithDescription("Permet de modifier les paramètres d'un utilisateur.")
                    .Build(),

                RouteBuilder<UserAdd>.Create("UserAdd")
                    .WithTitle("Ajouter un utilisateur")
                    .WithDescription("Permet d'ajouter un nouvel utilisateur.")
                    .WithNavigationType(NavigationType.Dialog)
                    .Build()
            ])
            .Build(),
    };
}
```

---

### ✅ Step 2: Initialize Router in Your Main Form

```csharp
using JoeDevSharp.WinForms.Extensions.RouteManager;

namespace WinFormsApp
{
    public partial class Main : Form
    {
        public Router Router;

        public Main()
        {
            InitializeComponent();

            // Initialize router with route list and target container
            Router = new Router(AppRoutes.Main, this);

            // Navigate to default route
            Router.To("Users");
        }

        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Router.To("UserDetails");
        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Router.To("UserSettings");
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Router.To("Users");
        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Router.To("UserAdd");
        }
    }
}
```

---

## ⚙️ Navigation Types

`Router` supports multiple navigation modes, controlled via the `NavigationType` enum:

| NavigationType | Behavior                                               |
| -------------- | ------------------------------------------------------ |
| `Navigation`   | Embeds the form inside a container (`RouterContainer`) |
| `Dialog`       | Shows the form as a blocking dialog                    |
| `Show`         | Opens the form in a new window                         |
| `CustomDialog` | Placeholder for advanced modal logic                   |
| `Integrate`    | Full-screen transparent overlay (e.g., for HUD)        |

---

## 🛡️ Access Control and Guards

- `Router` supports access-level filtering using the optional `accessLevel` parameter.
- Route transitions can be intercepted using the `BodyGuard` event.

Example:

```csharp
Router.BodyGuard += (sender, args) =>
{
    var guard = (BodyGuard)sender;
    Console.WriteLine($"Navigating from {guard.From?.Name} to {guard.To.Name}");
};
```

---

## 💡 Property Injection

At navigation time, you can inject properties into target forms:

```csharp
Router.To("UserDetails", new Dictionary<string, object>
{
    { "UserId", 42 }
});
```

---

## 🧠 Best Practices

- Use `RouteBuilder<T>` for type-safe definitions.
- Group routes by domain (e.g., users, settings).
- Avoid hardcoding navigation logic in UI components; route names should act as abstractions.
- Document route `Title` and `Description` for UI/UX traceability.

---

## 📦 Package Structure (Suggested)

```
/WinFormsApp
│
├── /Views
│   ├── Users.cs
│   ├── UserDetails.cs
│   ├── UserSettings.cs
│   └── UserAdd.cs
│
├── /Routing
│   └── AppRoutes.cs
│
└── Main.cs
```
