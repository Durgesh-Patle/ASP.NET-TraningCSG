var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("Hello .netASP Core6\n");
    await next(context);
});

app.Run(async (context) =>
{
    await context.Response.WriteAsync("Hello Durgesh Patle");
    //next(context);
});
   
app.Run();
