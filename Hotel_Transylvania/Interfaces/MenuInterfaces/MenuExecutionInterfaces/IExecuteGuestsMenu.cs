using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Transylvania.Interfaces.MenuInterfaces.MenuExecutionInterfaces
{
    public interface IExecuteGuestsMenu
    {
        public void Execute(int index, ref bool isRunning);
    }
}
