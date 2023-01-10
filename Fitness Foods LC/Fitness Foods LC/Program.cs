using Fitness_Foods_LC.Scraping;
using Hangfire;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// ----------------- HANGFIRE
WebScraper webScraper = new WebScraper();

builder.Services.AddHangfire(x => x.UseSqlServerStorage(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=challenge-20220626;Integrated Security=True"));

GlobalConfiguration.Configuration
.UseSqlServerStorage(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=challenge-20220626;Integrated Security=True");

RecurringJob.AddOrUpdate(() => webScraper.scraping(), Cron.Daily);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseHangfireDashboard();
app.UseHangfireServer();

app.Run();
