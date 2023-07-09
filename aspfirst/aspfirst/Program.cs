using aspfirst;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
Ïðîäóêöèÿ prod = null;

using (ÐåëüñûContext db = new ÐåëüñûContext())
{
     var allprod = db.Ïðîäóêöèÿs;
    foreach (Ïðîäóêöèÿ p in allprod)
    {
        prod = p;
    }
}


app.MapGet("/", () => prod.Id.ToString());
app.Run();

