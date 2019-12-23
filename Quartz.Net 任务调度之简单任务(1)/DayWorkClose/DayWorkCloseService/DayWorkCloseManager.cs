using DayWorkCloseService.DayWorkClose;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayWorkCloseService
{
    public class DayWorkCloseManager
    {

        public static async Task Init()
        {
            try
            {
                #region 创建单元 (时间轴/载体)
                StdSchedulerFactory factory = new StdSchedulerFactory();
                IScheduler scheduler = await factory.GetScheduler();
                await scheduler.Start();
                #endregion

                #region job
                IJobDetail  jobDetail = JobBuilder.Create<HelloJob>()
                    .WithDescription("this is a job")
                  .WithIdentity("job1", "group1")
                  .Build();
                #endregion

                #region 时间策略
                ITrigger trigger = TriggerBuilder.Create()
                                   .WithIdentity("trigger1", "group1")
                                   .StartNow()
                                   .WithSimpleSchedule(x => x
                                   .WithIntervalInSeconds(1)
                                   .WithRepeatCount(10000))
                                   .Build();
                #endregion

                // Tell quartz to schedule the job using our trigger
                await scheduler.ScheduleJob(jobDetail, trigger);

               


            }
            catch (SchedulerException se)
            {
                Console.WriteLine(se);
            }
        }
    }
}
