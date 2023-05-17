using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinformRouter;

namespace WinFormRouter.Interfaces
{
    public interface IFormProps
    {
        Router Router { get; set; }
        void UpdateProps();
    }
}
