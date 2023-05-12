using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WinformRouter
{
    public class Router
    {
        private List<Route> Routes { get; set; }

        private Form MainApplication { get; set; }

        private bool HistoryNavigate { get; set; } = false;

        public List<Route> history { get; set; } = new List<Route>();

        public Router(List<Route> routes, Form mainApplication, bool historyNavigate = false)
        {
            Routes = routes;
            HistoryNavigate = historyNavigate;
            MainApplication = mainApplication;
        }

        public Route CurrentRoute;

        private Route GetRoute(string routeName) => Routes.FirstOrDefault(r => r.Name == routeName);

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
            component.TopLevel = true;
            component.FormBorderStyle = FormBorderStyle.FixedSingle;
            component.Dock = DockStyle.None;
            component.Hide();
        }

        public void To<T>(string routeName, Dictionary<string, object> props = null, RouteType? routeType = RouteType.Navigation)
        {
            Route route = GetRoute(routeName);
            
            if (props != null)
            {
                foreach (var prop in route.Props)
                {
                    prop.Value = props[prop.Name];
                }
            }

            CurrentRoute = route;
            route.Component.GetType().GetProperty("Router").SetValue(route.Component, this);

            To(routeName, routeType);
        }

        public void To (string routeName, RouteType? routeType = RouteType.Navigation)
        {
            Route route = GetRoute(routeName);
            var form = route.Component;

            route.Component.FormClosing += (s,  e) =>
            {
                e.Cancel = true;
                ((Form)s).Hide();
            };

            switch (routeType)
            {
                case RouteType.Navigation:
                    Navigate(route); 
                    break;
                case RouteType.Show:
                    Show(route);
                    break;
                case RouteType.DefaultDialog:
                    ShowDefaultDialog(route);
                    break;
                case RouteType.CustomDialog:
                    ShowCustomDialog(route);
                    break;
            }
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

        private void Show(Route route)
        {
            RestarComponent(route.Component);
            route.Component.Show();
        }

        private void ShowDefaultDialog(Route route)
        {
            RestarComponent(route.Component);
            route.Component.ShowDialog();
        }

        private void ShowCustomDialog(Route route)
        {
            // Todo
        }
    }
}
