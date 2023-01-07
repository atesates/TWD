using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWD.Core.CrossCuttingConcerns.Logging.Log4Net;

namespace TWD.Core.CrossCuttingConcerns.Logging.Loggers
{
    public class DatabaseLogger : LoggerServiceBase
    {
        public DatabaseLogger() : base("DatabaseLogger")
        {
        }
    }
}
