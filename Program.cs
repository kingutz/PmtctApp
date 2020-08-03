using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Pmtct.Data;
using ZNetCS.AspNetCore.Logging.EntityFrameworkCore;
namespace Pmtct
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        
      
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            //.ConfigureLogging(logging =>
            //{
            //    logging.AddEntityFramework<PmtctContext>();
            //    logging.AddFilter<EntityFrameworkLoggerProvider<PmtctContext>>("Microsoft", LogLevel.None);
            //    logging.AddFilter<EntityFrameworkLoggerProvider<PmtctContext>>("System", LogLevel.None);
            //    //.AddEntityFramework<PmtctContext>();
            //    logging.AddEntityFramework<PmtctContext, ExtendedLog>();
            //})
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();

                });
    }
}
