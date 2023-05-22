using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WinformRouterNet
{
    public class Router
    {
        public EventHandler RouteChange;

        public List<Route> Routes { get; set; }

        public Router(List<Route> routes, ScrollableControl mainApplication, bool historyNavigate = false)
        {
            Routes = routes;
            HistoryNavigate = historyNavigate;
            MainApplication = mainApplication;
        }

        private ScrollableControl MainApplication { get; set; }

        private bool HistoryNavigate { get; set; } = false;

        public List<Route> history { get; set; } = new List<Route>();

        public Route CurrentRoute;

        public Route GetRoute(string routeName, List<Route> routes)
        {
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

        private void HideComponents()
        {
            var components = MainApplication.Controls.Cast<Control>().ToList().Where(e => e.GetType().BaseType.FullName == "System.Windows.Forms.Form").ToList();
            if (components.Count > 0)
            {
                components.ForEach(e =>
                {
                    e.Hide();
                });
            }
        }

        private void RestarComponent(Form component)
        {
            MainApplication.Controls.Remove(component);
            component.Text = CurrentRoute.Title;
            component.Icon = CurrentRoute.Image != null ? Icon.FromHandle(((Bitmap)CurrentRoute.Image).GetHicon()) : null;
            component.TopLevel = true;
            component.FormBorderStyle = FormBorderStyle.FixedSingle;
            component.Dock = DockStyle.None;
            component.Hide();
        }

        public void To(string routeName, Dictionary<string, object> props, NavigationType? routeType = null)
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
            To(routeName, routeType);
        }

        public void To(string routeName, NavigationType? routeType = null)
        {
            Route route = GetRoute(routeName, Routes);

            if (routeType == null)
            {
                routeType = route.Type;
            }

            CurrentRoute = route;

            var form = route.Component;
            form.AutoScroll = true;
            // TODO
            route.Component.FormClosing += (s,  e) =>
            {
                e.Cancel = true;
                ((Form)s).Hide();
            };

            var propertyInfo = form.GetType().GetProperty("Router");

            if (propertyInfo != null)
            {
                propertyInfo.SetValue(form, this, null);
            }

            switch (routeType)
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

        private void Navigate(Route route)
        {
            HideComponents();

            Form component = route.Component;
            component.TopLevel = false;
            component.FormBorderStyle = FormBorderStyle.None;
            component.Dock = DockStyle.Fill;

            MainApplication.Controls.Add(component);

            component.Show();
        }

        public void Integrate(Route route)
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
    }
}
