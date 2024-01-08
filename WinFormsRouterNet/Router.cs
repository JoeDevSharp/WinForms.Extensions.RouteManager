namespace Codevia.Router.Winform
{
    /// <summary>
    /// This class allows you to manage navigation according to the needs of the application.
    /// </summary>
    public class Router
    {
        /// <summary>
        /// Constructor of class
        /// </summary>
        /// <param name="routes">List of Route</param>
        /// <param name="routerContainer">Container where the current navigation will be capped</param>
        /// <param name="historyNavigate">If we want to activate the navigation record</param>
        public Router(Routes routes, ScrollableControl routerContainer, int? accessLevel = null, bool historyNavigate = false)
        {
            Routes = routes;
            HistoryNavigate = historyNavigate;
            RouterContainer = routerContainer;
            AccesLevel = accessLevel;
        }

        /// <summary>
        /// Constructor of class
        /// </summary>
        /// <param name="routes">List of Route</param>
        /// <param name="routerContainer">Container where the current navigation will be capped</param>
        /// <param name="historyNavigate">If we want to activate the navigation record</param>
        public Router(List<Route> routes, ScrollableControl routerContainer, int? accessLevel = null, bool historyNavigate = false)
        {
            Routes = routes;
            HistoryNavigate = historyNavigate;
            RouterContainer = routerContainer;
            AccesLevel = accessLevel;
        }

        #region "Public Events"
        /// <summary>
        /// Event that captures at the moment that the current route has changed
        /// </summary>
        public EventHandler RouteChange;
        public EventHandler BodyGuard;
        #endregion

        #region "Public Properties"
        /// <summary>
        /// List of route
        /// </summary>
        public List<Route> Routes { get; set; }
        /// <summary>
        /// TODO
        /// History of router navigations
        /// </summary>
        public List<Route> history { get; set; } = new List<Route>();
        /// <summary>
        /// Element containing the current route
        /// </summary>
        public Route CurrentRoute;
        #endregion

        #region "Private properties"
        private ScrollableControl RouterContainer { get; set; }
        /// <summary>
        /// Element contining the history of navigation
        /// </summary>
        private bool HistoryNavigate { get; set; } = false;
        private int? AccesLevel;
        #endregion

        #region "Public methods"
        /// <summary>
        /// This method allows to find a Router from its name
        /// </summary>
        /// <param name="routeName">name of route</param>
        /// <param name="routes">Routes (Optional)</param>
        /// <returns></returns>
        public Route GetRoute(string routeName, List<Route> routes = null)
        {
            if (routes == null)
            {
                routes = Routes;
            }

            foreach (var route in routes)
            {
                if (route.Name == routeName)
                {
                    return route;
                }
                else if (route.Childrend != null)
                {
                    return GetRoute(routeName, route.Childrend);
                }
            }

            return null;
        }
        /// <summary>
        /// This method allows us to navigate to a new router based on its name.
        /// </summary>
        /// <param name="routeName">Name of route</param>
        /// <param name="props">Properties to inject the router in the navigation</param>
        /// <param name="navigationType">Type of navigation (optional)</param>
        public void To(string routeName, Dictionary<string, object> props, NavigationType? navigationType = null)
        {
            Route route = GetRoute(routeName, Routes);

            if (props != null)
            {
                foreach (var prop in props)
                {
                    route.Component.GetType().GetProperty(prop.Key)?.SetValue(route.Component, prop.Value, null);
                }
            }
            route.Component.GetType().GetProperty("Router")?.SetValue(route.Component, this, null);
            CurrentRoute = route;
            To(routeName, navigationType);
        }
        /// <summary>
        /// This method allows us to navigate to a new router based on its name.
        /// </summary>
        /// <param name="routeName">Name of Router</param>
        /// <param name="navigationType">Type of navigation (optional)</param>
        public void To(string routeName, NavigationType? navigationType = null)
        {
            Route route = GetRoute(routeName, Routes);

            EventHandler handlerBodyGuard = BodyGuard;
            if (null != handlerBodyGuard) handlerBodyGuard(new BodyGuard()
            {
                From = CurrentRoute,
                To = route
            }, EventArgs.Empty);

            if (AccesLevel is not null && AccesLevel > (int)route.Permisions)
            {
                MessageBox.Show("You don't have acces for this route");
                return;
            }

            if (navigationType == null)
            {
                navigationType = (NavigationType)route.Type;
            }

            CurrentRoute = route;

            var form = route.Component;
            form.AutoScroll = true;
            // TODO
            route.Component.FormClosing += (s, e) =>
            {
                e.Cancel = true;
                ((Form)s).Hide();
            };

            var propertyInfo = form.GetType().GetProperty("Router");

            if (propertyInfo != null)
            {
                propertyInfo.SetValue(form, this, null);
            }

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
                case NavigationType.CustomDialog:
                    ShowCustomDialog(route);
                    break;
                case NavigationType.Integrate:
                    Integrate(route);
                    break;
            }

            EventHandler handler = RouteChange;
            if (null != handler) handler(route, EventArgs.Empty);
        }
        #endregion

        #region "Private Methods"
        /// <summary>
        /// Hides all the components of the RouterContainer that are of type System.Windows.Forms.Form.
        /// </summary>
        private void HideComponents()
        {
            var components = RouterContainer.Controls.Cast<Control>().ToList().Where(e => e.GetType().BaseType.FullName == "System.Windows.Forms.Form").ToList();
            if (components.Count > 0)
            {
                components.ForEach(e =>
                {
                    e.Hide();
                });
            }
        }
        /// <summary>
        /// Restarts a component by performing various operations on the provided Form object.
        /// </summary>
        /// <param name="component">The Form component to be restarted</param>
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
        /// <summary>
        /// Navigates to a specified route by hiding the current components, adding the route's component to the RouterContainer, and showing it.
        /// </summary>
        /// <param name="route"></param>
        private void Navigate(Route route)
        {
            HideComponents();

            Form component = route.Component;
            component.TopLevel = false;
            component.FormBorderStyle = FormBorderStyle.None;
            component.Dock = DockStyle.Fill;

            RouterContainer.Controls.Add(component);

            component.Show();
        }
        private void Integrate(Route route)
        {
            Form form = route.Component;
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
        private void ShowCustomDialog(Route route)
        {
            // Todo
        }
        #endregion
    }
}
