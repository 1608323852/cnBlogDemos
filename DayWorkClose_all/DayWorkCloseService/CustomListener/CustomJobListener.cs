using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DayWorkCloseService.CustomListener
{
    public class CustomJobListener : IJobListener
    {
        public string Name => "CustomJobListener";

        /// <summary>
        /// 停止执行
        /// </summary>
        /// <param name="context"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task JobExecutionVetoed(IJobExecutionContext context, CancellationToken cancellationToken = default)
        {

            await Task.Run(()=> {

                Console.WriteLine("停止执行");
            });
        }
        /// <summary>
        /// 待执行
        /// </summary>
        /// <param name="context"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task JobToBeExecuted(IJobExecutionContext context, CancellationToken cancellationToken = default)
        {
            await Task.Run(() => {

                Console.WriteLine("待执行");
            });
        }
        /// <summary>
        /// 已执行
        /// </summary>
        /// <param name="context"></param>
        /// <param name="jobException"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task JobWasExecuted(IJobExecutionContext context, JobExecutionException jobException, CancellationToken cancellationToken = default)
        {
            await Task.Run(() => {

                Console.WriteLine("已执行");
            });
        }
    }
}
