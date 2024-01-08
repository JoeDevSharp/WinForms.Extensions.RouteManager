using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Codevia.Router.Net
{
    public class BodyGuard
    {
        public Route From { get; set; }
        public Route To { get; set; }
    }

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
