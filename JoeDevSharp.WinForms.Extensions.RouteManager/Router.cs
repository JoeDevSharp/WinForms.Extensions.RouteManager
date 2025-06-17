using JoeDevSharp.WinForms.Extensions.RouteManager.Enums;
using JoeDevSharp.WinForms.Extensions.RouteManager.Models;

namespace JoeDevSharp.WinForms.Extensions.RouteManager
{
    /// <summary>
    /// This class allows you to manage navigation according to the needs of the application.
    /// </summary>
    public class Router
    {
        public Router(Routes routes, ScrollableControl routerContainer, int? accessLevel = null, bool historyNavigate = false)
        {
            Routes = routes;
            HistoryNavigate = historyNavigate;
            RouterContainer = routerContainer;
            AccesLevel = accessLevel;
        }

        #region "Public Events"
        public EventHandler? RouteChange;
        public EventHandler? BodyGuard;
        #endregion

        #region "Public Properties"
        public Routes Routes { get; set; }
        public Route? CurrentRoute;
        #endregion

        #region "Private Properties"
        private ScrollableControl RouterContainer { get; set; }
        private bool HistoryNavigate { get; set; } = false;
        private int? AccesLevel;

        private readonly Stack<Route> _backStack = new();
        private readonly Stack<Route> _forwardStack = new();
        #endregion

        #region "Public Methods"
        public Route GetRoute(string routeName, List<Route>? routes = null)
        {
            routes ??= Routes;

            foreach (var route in routes)
            {
                if (route.Name == routeName)
                    return route;

                if (route.Childrend != null)
                {
                    var childRoute = GetRoute(routeName, route.Childrend);
                    if (childRoute != null)
                        return childRoute;
                }
            }

            return null;
        }

        public void To(string routeName, Dictionary<string, object> props, NavigationType? navigationType = null)
        {
            var route = GetRoute(routeName, Routes);

            if (route == null)
                throw new InvalidOperationException($"Route '{routeName}' not found.");

            if (props != null)
            {
                foreach (var prop in props)
                {
                    route.Component?.GetType().GetProperty(prop.Key)?.SetValue(route.Component, prop.Value, null);
                }
            }

            route.Component?.GetType().GetProperty("Router")?.SetValue(route.Component, this, null);

            if (CurrentRoute != null && HistoryNavigate)
            {
                _backStack.Push(CurrentRoute);
                _forwardStack.Clear();
            }

            NavigateToRoute(route, navigationType);
        }

        public void To(string routeName, NavigationType? navigationType = null)
        {
            var route = GetRoute(routeName, Routes);
            if (route == null)
                throw new InvalidOperationException($"Route '{routeName}' not found.");

            if (CurrentRoute != null && HistoryNavigate)
            {
                _backStack.Push(CurrentRoute);
                _forwardStack.Clear();
            }

            NavigateToRoute(route, navigationType);
        }

        public void Back()
        {
            if (!HistoryNavigate || _backStack.Count == 0)
                return;

            var previous = _backStack.Pop();

            if (CurrentRoute != null)
                _forwardStack.Push(CurrentRoute);

            NavigateToRoute(previous);
        }

        public void Forward()
        {
            if (!HistoryNavigate || _forwardStack.Count == 0)
                return;

            var next = _forwardStack.Pop();

            if (CurrentRoute != null)
                _backStack.Push(CurrentRoute);

            NavigateToRoute(next);
        }
        #endregion

        #region "Private Methods"
        private void NavigateToRoute(Route route, NavigationType? navigationTypeOverride = null)
        {
            var handlerBodyGuard = BodyGuard;
            if (handlerBodyGuard != null)
            {
                handlerBodyGuard(new BodyGuard()
                {
                    From = CurrentRoute,
                    To = route
                }, EventArgs.Empty);
            }

            if (AccesLevel != null && AccesLevel > (int)route.Permisions)
            {
                MessageBox.Show("You don't have access to this route");
                return;
            }

            var form = Activator.CreateInstance(route.ComponentType) as Form;
            if (form == null)
                throw new InvalidOperationException($"Unable to create an instance of the component: {route.ComponentType.FullName}");

            form.AutoScroll = true;
            route.Component = form;

            form.FormClosing += (s, e) =>
            {
                e.Cancel = true;
                if (s is Form f)
                    f.Hide();
            };

            var propertyInfo = form.GetType().GetProperty("Router");
            propertyInfo?.SetValue(form, this, null);

            CurrentRoute = route;

            var navigationType = navigationTypeOverride ?? route.Type;

            switch (navigationType)
            {
                case NavigationType.Navigation:
                    Navigate(route);
                    break;
                case NavigationType.Show:
                    Show(route);
                    break;
                case NavigationType.Dialog:
                    ShowDefaultDialog(route);
                    break;
                //case NavigationType.CustomDialog:
                //    ShowCustomDialog(route);
                //    break;
                case NavigationType.Integrate:
                    Integrate(route);
                    break;
            }

            RouteChange?.Invoke(route, EventArgs.Empty);
        }

        private void HideComponents()
        {
            var components = RouterContainer.Controls
                .Cast<Control>()
                .Where(e => e.GetType().BaseType?.FullName == "System.Windows.Forms.Form")
                .ToList();

            foreach (var c in components)
                c.Hide();
        }

        private void RestarComponent(Form component)
        {
            RouterContainer.Controls.Remove(component);
            component.Text = CurrentRoute.Title;
            component.Icon = CurrentRoute.Image != null ? Icon.FromHandle(((Bitmap)CurrentRoute.Image).GetHicon()) : null;
            component.TopLevel = true;
            component.FormBorderStyle = FormBorderStyle.FixedSingle;
            component.Dock = DockStyle.None;
            component.Hide();
        }

        private void Navigate(Route route)
        {
            HideComponents();

            var component = route.Component;
            component.TopLevel = false;
            component.FormBorderStyle = FormBorderStyle.None;
            component.Dock = DockStyle.Fill;

            RouterContainer.Controls.Add(component);
            component.Show();
        }

        private void Integrate(Route route)
        {
            var form = route.Component;
            form.BackColor = Color.Lime;
            form.ForeColor = Color.Black;
            form.FormBorderStyle = FormBorderStyle.None;
            form.ShowIcon = false;
            form.ShowInTaskbar = false;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.TopMost = true;
            form.TransparencyKey = Color.Lime;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        private void Show(Route route)
        {
            RestarComponent(route.Component);
            route.Component.StartPosition = FormStartPosition.CenterScreen;
            route.Component.Show();
        }

        private void ShowDefaultDialog(Route route)
        {
            RestarComponent(route.Component);
            route.Component.StartPosition = FormStartPosition.CenterParent;
            route.Component.MinimizeBox = false;
            route.Component.MaximizeBox = false;
            route.Component.ShowInTaskbar = false;
            route.Component.ShowDialog();
        }

        //private void ShowCustomDialog(Route route)
        //{
        //    // TODO: Implement custom dialog logic
        //}
        #endregion
    }
}
