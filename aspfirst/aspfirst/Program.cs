using aspfirst;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
��������� prod = null;

using (������Context db = new ������Context())
{
     var allprod = db.���������s;
    foreach (��������� p in allprod)
    {
        prod = p;
    }
}


app.MapGet("/", () => prod.Id.ToString());
app.Run();

