using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayWorkCloseService.DayWorkClose
{
    public class sayHiJob : IJob
    {

        public sayHiJob()
        {
            Console.WriteLine("sayHiJob被构造了");
        }
        public async Task Execute(IJobExecutionContext context)
        {
            await Task.Run(()=> {

                Console.WriteLine();
                Console.WriteLine("************************");
                Console.WriteLine("大家好"+DateTime.Now);
                Console.WriteLine("************************");
            
            });
        }
    }
}
