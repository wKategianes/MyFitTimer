using Microsoft.EntityFrameworkCore;
using MyFitTimer.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MyFitTimer
{
    public class StopwatchTracker
    {
        public  Stopwatch stopWatch = new Stopwatch();
        public  TimeSpan timeSpan;
        public  DateTime startTime;
        public  DateTime endTime;
        public int stopWatchId;
        private readonly MyFitTimerContext context;

        public StopwatchTracker(MyFitTimerContext context)
        {
            this.context = context;
        }

        public StopwatchTracker()
        {
        }

        // Starts the stopwatch & stores the current DateTime into the startTime var
        public void StartStopWatch()
        {            
            stopWatch.Start();
            startTime = DateTime.Now;
        }

        // Stops the stopwatch
        public void EndStopWatch()
        {
            var timerRun = new MyFitTimer.Models.TimerRun();
            stopWatch.Stop();
            endTime = DateTime.Now;

            timerRun.StartTime = startTime;
            timerRun.EndTime = endTime;

            //Program.context.TimerRuns.Add(timerRun);
            //Program.context.SaveChanges();            

            // var optionsBuilder = new DbContextOptions<MyFitTimerContext>();

            // var context = new MyFitTimerContext(optionsBuilder);

            if (context != null)
            {
                context.TimerRuns.Add(timerRun);
                context.SaveChanges();
            }
        }

        // returns the elapsed time
        public TimeSpan getElapsedTime()
        {
            timeSpan = stopWatch.Elapsed;

            return timeSpan;
        }

        // calls the startTime var which holds when the stopwatch was started
        public DateTime getStartTime()
        {
            return startTime;
        }
    }
}
