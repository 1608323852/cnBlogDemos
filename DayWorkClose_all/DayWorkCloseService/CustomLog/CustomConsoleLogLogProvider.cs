using Quartz.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayWorkCloseService.CustomLog
{
  public  class CustomConsoleLogLogProvider : ILogProvider
    {
        public Logger GetLogger(string name)
        {
            return new Logger((level, func, exception, parmters)=> {
                if (level>=LogLevel.Info&&func!=null)
                {
                    Console.WriteLine($"[{DateTime.Now.ToLongTimeString()}] [{level}] [{func()}] {string.Join(":",parmters.Select(p=>p==null?"":p.ToString()))} 自定义日志{name}");
                }
                return true;
            });
        }

        public IDisposable OpenMappedContext(string key, string value)
        {
            throw new NotImplementedException();
        }

        public IDisposable OpenNestedContext(string message)
        {
            throw new NotImplementedException();
        }
    }
}
