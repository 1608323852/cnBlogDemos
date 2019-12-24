using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DayWorkCloseService.DayWorkClose
{
    [PersistJobDataAfterExecution] //执行后的保留作业数据，链式传参（上一次的任务数据）
    [DisallowConcurrentExecution]//不允许重复执行，必须等上次任务执行完成后再继续执行
    public class HelloJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            await Task.Run(() =>
            {
                Thread.Sleep(5000);
                string name = context.JobDetail.JobDataMap.GetString("张翼德");
                int year = context.JobDetail.JobDataMap.GetInt("year");
                string name2 = context.Trigger.JobDataMap.GetString("刘玄德");
                int year3= context.MergedJobDataMap.GetInt("year");
                int year2 = context.Trigger.JobDataMap.GetInt("year");

                Console.WriteLine($@"JobDetail{name}" + DateTime.Now + "");
                Console.WriteLine($@"Trigger{name2}" + DateTime.Now + "");
                Console.WriteLine("JobDetail 当前年份" + year);
                Console.WriteLine("Trigger 当前年份" + year2);
                Console.WriteLine("MergedJobDataMap 当前年份" + year3);

                if (year==2030)
                {
                    Console.WriteLine("牛逼了");
                }
                context.JobDetail.JobDataMap.Put("year", year + 1);
                
            });
        }
    }
}
