using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALT_R_ManagerLibrary.DataAccess
{
    public class ConsoleBuilderArgs:EventArgs
    {
        public ContainerBuilder Builder { get; set; }
    }
}
