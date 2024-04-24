using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace func
{
    public class Recurring
    {
        private readonly ILogger _logger;

        public Recurring(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Recurring>();
        }

        // This attribute indicates that this method is an Azure Function named "Recurring".
        [Function("Recurring")]
        public void Run(
            // This attribute indicates that this function is triggered by a timer.
            // The function is triggered every 1 minute
            // (as indicated by the cron expression "0 */1 * * * *") 
            // (seconds, minutes, hours, days, months, days of the week).
            [TimerTrigger("0 */1 * * * *")] MyInfo myTimer)
        {
            // Log an informational message indicating that the function has been triggered.
            // Include the current date and time in the log message.
            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            // Log an informational message indicating the next scheduled trigger time for the function.
            _logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
        }
    }

    public class MyInfo
    {
        public MyScheduleStatus ScheduleStatus { get; set; }

        public bool IsPastDue { get; set; }
    }

    public class MyScheduleStatus
    {
        public DateTime Last { get; set; }

        public DateTime Next { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}
