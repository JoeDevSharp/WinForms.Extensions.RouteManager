using JoeDevSharp.WinForms.Extensions.RouteManager.Models;

namespace JoeDevSharp.WinForms.Extensions.RouteManager
{
    public class Guard
    {
        private Router Router;
        private BodyGuard BodyGuard;
        public Guard(BodyGuard bodyGuard, Router router)
        {
            BodyGuard = bodyGuard;
            Router = router;
        }
        public void IsAccess(int accesLevel)
        {
            if (BodyGuard != null)
            {
                if (BodyGuard.From != null)
                {
                    if (BodyGuard.To != null)
                    {
                        if ((int)BodyGuard.To.Permisions <= accesLevel)
                        {
                        }else
                        {
                            MessageBox.Show("You don't have acces for this route");
                            return;
                        }
                    }
                }
            }
        }
    }
}
