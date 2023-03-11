using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Web.Http.ExceptionHandling;
using VAT.Infrastructure.Context;
using VAT.Infrastructure.Helper;
using VAT.API.Middleware;
using VAT.Application.Helper;
using VAT.Application.Mapping;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<VATDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));

//builder.Services.AddLogging(loggingBuilder =>
//{
//	loggingBuilder.ClearProviders();
//	loggingBuilder.AddConsole();
//});

builder.Host.UseSerilog((context, services, configuration) => configuration
	.ReadFrom.Configuration(context.Configuration)
	.Enrich.FromLogContext()
	.WriteTo.Console());

// Add services to the container.
ApplicationRegister.AddApplication(builder.Services);
InfrastructureRegistration.AddInfrastructure(builder.Services);

builder.Services.AddControllers();

builder.Services.AddAuthentication(options =>
{
	options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
	options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
	options.Authority = "https://your-authorization-server.com";
	options.Audience = "your-audience";
	options.TokenValidationParameters = new TokenValidationParameters
	{
		ValidateIssuer = true,
		ValidateAudience = true,
		ValidateLifetime = true,
		ValidateIssuerSigningKey = true,
		ValidIssuer = "your_issuer",
		ValidAudience = "your_audience",
		IssuerSigningKey = new SymmetricSecurityKey(
						System.Text.Encoding.UTF8.GetBytes("your_secret_key")),
		ClockSkew = TimeSpan.Zero, // set the token lifetime here
	};
})
.AddOpenIdConnect(options =>
{
	options.Authority = "https://your-authorization-server.com";
	options.ClientId = "your-client-id";
	options.ClientSecret = "your-client-secret";
	options.ResponseType = "code";
	options.Scope.Add("openid");
	options.Scope.Add("profile");
	options.SaveTokens = true;
});

builder.Services.AddAuthorization();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

MappingConfig.Configure();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "VATWebAPI-Project v1"));
}
//else
//{
//	app.UseGlobalExceptionHandlerMiddleware();
//}

app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

