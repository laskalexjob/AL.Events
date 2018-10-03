using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL.Events.Common.Logger
{
    public interface ICustomLogger
    {
        void WriteToLogInfo(string info);
    }
}
