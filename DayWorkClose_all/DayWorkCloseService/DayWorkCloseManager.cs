using DayWorkCloseService.CustomListener;
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

                //添加监听
                scheduler.ListenerManager.AddJobListener(new CustomJobListener());
                scheduler.ListenerManager.AddTriggerListener(new CustomTriggerListener());

                scheduler.ListenerManager.AddSchedulerListener(new CustomSchedulerListener());

                
                #region job
                IJobDetail sayJobDetail = JobBuilder.Create<sayHiJob>()
                    .WithIdentity("job1", "group1")
                    .Build();

                #endregion

                #region 时间策略
                ITrigger trigger = TriggerBuilder.Create()
                                   .WithIdentity("trigger1", "group1")
                                   .WithCronSchedule("1/5 * * * * ?")//每5秒执行一次，秒针为1时执行
                                   .Build();
                #endregion

                
                // Tell quartz to schedule the job using our trigger
                await scheduler.ScheduleJob(sayJobDetail,trigger);

               


            }
            catch (SchedulerException se)
            {
                Console.WriteLine(se);
            }
        }
    }
}
