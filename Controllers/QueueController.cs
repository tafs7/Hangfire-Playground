using System.Web.Http;
using Hangfire;
using Serilog;

namespace HangFire_Playground.Controllers
{
    public class QueueController : ApiController
    {
        [HttpGet]
        [Route("api/queue/{logMessage}")]
        public string QueueWork(string logMessage)
        {
            return BackgroundJob.Enqueue(() => Log.Debug(logMessage));
        }
    }
}
