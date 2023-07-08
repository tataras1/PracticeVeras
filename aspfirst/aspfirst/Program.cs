using aspfirst;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

using (ApplicationContext db = new ApplicationContext())
{
    
}
app.MapGet("/", () => "Hello World!");

app.Run();
