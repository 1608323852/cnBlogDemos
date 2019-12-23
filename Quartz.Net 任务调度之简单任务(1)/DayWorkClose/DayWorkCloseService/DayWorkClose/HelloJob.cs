using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayWorkCloseService.DayWorkClose
{
    public class HelloJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            await Task.Run(() => {

                Console.WriteLine($@"{"张翼德"}"+DateTime.Now + "");

            });
        }
    }
}
