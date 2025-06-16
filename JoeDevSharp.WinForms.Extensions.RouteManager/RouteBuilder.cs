using System.Drawing;
using System.Windows.Forms;
using JoeDevSharp.WinForms.Extensions.RouteManager.Enums;
using JoeDevSharp.WinForms.Extensions.RouteManager.Models;

namespace JoeDevSharp.WinForms.Extensions.RouteManager.Builders;

/// <summary>
/// RouteBuilder permet de définir une route de manière fluide et typée.
/// </summary>
/// <typeparam name="TView">Type du formulaire associé à la route</typeparam>
public class RouteBuilder<TView> where TView : Form
{
    private readonly Route _route;

    private RouteBuilder(string name)
    {
        _route = new Route
        {
            Name = name,
            ComponentType = typeof(TView),
        };
    }

    /// <summary>
    /// Démarre la construction d'une route en spécifiant le nom de celle-ci.
    /// </summary>
    public static RouteBuilder<TView> Create(string name)
    {
        return new RouteBuilder<TView>(name);
    }

    public RouteBuilder<TView> WithTitle(string title)
    {
        _route.Title = title;
        return this;
    }

    public RouteBuilder<TView> WithDescription(string description)
    {
        _route.Description = description;
        return this;
    }

    public RouteBuilder<TView> WithImage(Image image)
    {
        _route.Image = image;
        return this;
    }

    public RouteBuilder<TView> WithNavigationType(NavigationType type)
    {
        _route.Type = type;
        return this;
    }

    public RouteBuilder<TView> WithPermissions(object permissions)
    {
        _route.Permisions = permissions;
        return this;
    }

    public RouteBuilder<TView> ShowInMenu(bool value = true)
    {
        _route.ShowInMenu = value;
        return this;
    }

    public RouteBuilder<TView> WithChildren(Routes children)
    {
        _route.Childrend = children;
        return this;
    }

    public Route Build()
    {
        return _route;
    }
}
