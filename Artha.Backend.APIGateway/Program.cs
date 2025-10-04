
using Artha.Backend.APIGateway.Extensions;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// 1. Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// --- Register each domain's services ---
builder.Services.RegisterDomainServices(builder.Configuration);

var app = builder.Build();

// 2. Configure the HTTP request pipeline.
// It's a good practice to only enable Swagger in the development environment.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

// This temporary endpoint creates a JWT for a test user.
app.MapPost("/api/v1/auth/token", (IConfiguration config) =>
{
    var issuer = config["Jwt:Issuer"];
    var audience = config["Jwt:Audience"];
    var key = Encoding.ASCII.GetBytes(config["Jwt:Key"]);

    var tokenDescriptor = new SecurityTokenDescriptor
    {
        Subject = new ClaimsIdentity(new[]
        {
            new Claim("Id", Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Sub, "testuser"),
            new Claim(JwtRegisteredClaimNames.Email, "testuser@example.com"),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()) // JWT ID
        }),
        Expires = DateTime.UtcNow.AddMinutes(60),
        Issuer = issuer,
        Audience = audience,
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
    };

    var tokenHandler = new JwtSecurityTokenHandler();
    var token = tokenHandler.CreateToken(tokenDescriptor);
    var jwtToken = tokenHandler.WriteToken(token);

    return Results.Ok(new { token = jwtToken });
});

app.MapControllers();

// --- Map each domain's endpoints ---
app.MapDomainEndpoints();

app.Run();