using JoeDevSharp.WinForms.Extensions.RouteManager.Builders;
using JoeDevSharp.WinForms.Extensions.RouteManager.Models;
using WinFormsApp.Views;

namespace WinFormsApp
{
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
                    ])
                .Build(),
        };
    }
}
