using System;
using Hangfire;
using Hangfire.SqlServer;
using Owin;

namespace HangFire_Playground
{
    public partial class Startup
    {
        private void ConfigureHangfire(IAppBuilder app)
        {
            app.UseHangfire(config =>
            {
                var options = new SqlServerStorageOptions
                {
                    InvisibilityTimeout = TimeSpan.FromMinutes(120),
                    QueuePollInterval = TimeSpan.FromMinutes(3)
                };

                config.UseSqlServerStorage("HangFire-Playground", options);
                
                config.UseServer();
            });
        }
    }
}