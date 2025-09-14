using Domain.Broker;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// 1. Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// --- Register each domain's services ---
builder.Services.AddBrokerDomain(builder.Configuration);

var app = builder.Build();

// 2. Configure the HTTP request pipeline.
// It's a good practice to only enable Swagger in the development environment.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

// --- Map each domain's endpoints ---
app.MapBrokerEndpoints();

app.Run();