//using Microsoft.AspNetCore;

//namespace EmployeeManagement
//{
//    public class Program
//    {
//        public static void Main(string[] strings)
//        {
//            CreateWebHostBuilder.Build().Run();
//        }
//        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
//            WebHost.CreateDefaultBuilder(args).UseStartup<Startup>;
//    }
//}

// Commented above approach as it is before .NET Core 6.x version

var builder = WebApplication.CreateBuilder(args);

var app=builder.Build();

app.MapGet("/", () => System.Diagnostics.Process.GetCurrentProcess().ProcessName);

app.MapGet("user", () => "User Endpoint");

app.Run();
