var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient();

var defaultConn = builder.Configuration.GetConnectionString("ArthaTestDB");
var connectionString = Environment.GetEnvironmentVariable("ARTHA_TEST_DB_CONNECTION_STRING") ?? defaultConn;

if (string.IsNullOrWhiteSpace(connectionString))
{
    throw new InvalidOperationException("Database connection string is not configured.");
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// New 'values' endpoint returning an array of dummy strings
app.MapGet("/values", () =>
{
    var values = new[] { "Value1", "Value2", "Value3" };
    return values;
})
.WithName("GetValues")
.WithOpenApi();

app.Run();
