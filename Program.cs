//using Microsoft.AspNetCore;
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

using EmployeeManagement.Repository;
using Microsoft.AspNetCore.Mvc;


var builder = WebApplication.CreateBuilder(args);

// binding the controllers.

builder.Services.AddMvc();
// AddMvc() internally calls AddMvcCore(), no need to add that again, better to use AddMvc();


builder.Services.AddControllersWithViews();

// Adding the Dependency Injection into the Dependency Container

builder.Services.AddSingleton<IEmployeeRepository, EmployeeRepository>();
//builder.Services.AddKeyedSingleton<IEmployeeRepository, EmployeeRepository>("KeyA");  -- Key Based Injection

// -- Other ways to add Dependency Injection into the container.
//builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
//builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

var app=builder.Build();

// IConfiguration is the builtin service to read the Configuration.
IConfiguration config = app.Configuration;

/* Minimal APIs Based on Endpoint

// getting the Processing server name  eg: IIS - Inprocess, Kestrel - OutOfProcess
//app.MapGet("/", () => System.Diagnostics.Process.GetCurrentProcess().ProcessName);

//app.MapGet("/user", () => "User Endpoint");

//// Configuration
//// AppSettings -> AppSettings.development -> User Secrets -> Env Variables -> Cmd line Args.
//// cmd ex: dotnet run MyKey="Value from CMD"

//app.MapGet("/Key", () => config["MyKey"]);

*/

// Minimal Universal API with context delegate.
//app.Use(async (context,next) => {
//    // Use with next parameter will pass the control to next middleware, otherwise it will be terminated.

//    // logger

//    var logger = context.RequestServices.GetRequiredService<ILogger<Program>>();

//    logger.LogInformation("MW1 : Request Processing");

//    await context.Response.WriteAsync(context.Request.Path + "  " + config["MyKey"]);

//    await next();

//    logger.LogInformation("MW1 : Response Processing");

//});

//app.Run( async (context) => { await context.Response.WriteAsync(context.Request.Method +"  "+ config["MyKey"]); });


// adding the DefaultFileOptions to render custom html as default page.

//DefaultFilesOptions options = new DefaultFilesOptions();
//options.DefaultFileNames.Clear();
//options.DefaultFileNames.Add("Foo.html");

// adding FileServerOptions for combined usage of UseDirectoryBrowser middleware, by replacing both UseDefaultFiles, UseStaticFiles Middlewares

//app.UseDefaultFiles(options);
//app.UseStaticFiles();


// Commenting for testing the DeveloperException Middleware.

//FileServerOptions options = new FileServerOptions();
//options.DefaultFilesOptions.DefaultFileNames.Clear();
//options.DefaultFilesOptions.DefaultFileNames.Add("foo.html");

if (app.Environment.IsDevelopment())
{
    //DeveloperExceptionPageOptions developerOptions = new DeveloperExceptionPageOptions
    //{
    //    SourceCodeLineCount = 10
    //};

    app.UseDeveloperExceptionPage();
}


//app.UseFileServer();

// adding routing

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

// adding the default controller mapping

// Convetional routing where it is mandatory  

app.MapControllerRoute(
    name: "default",
    pattern: "{Controller=Home}/{Action=Index}/{id?}"
);

// Attribute Routing => [Route("Home")] in controllers


//app.Run( async (context) => {
//    throw new Exception("Exception from the Running fgvdfgdf");
//    await context.Response.WriteAsync("Hello World!  "+ app.Environment.EnvironmentName.ToString());                                                                      
//});


// Development  -- Staging ( replica of Production with minified versions to test with Client services)  -- Production

app.Run();
 