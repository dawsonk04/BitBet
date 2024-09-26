using JD.BitBet.PL.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContextPool<BitBetEntities>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("BitBetConnection"), builder =>
{
    builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
}));

var app = builder.Build();
app.Run();

