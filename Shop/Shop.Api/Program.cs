using Common.AspNetCore;
using Common.AspNetCore.Middlewares;
using Common.L2.Application;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Shop.Api.Infrastructure;
using Shop.Api.Infrastructure.JwtUtil;
using Shop.L6.Config;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().ConfigureApiBehaviorOptions(option =>
{
	option.InvalidModelStateResponseFactory = (context =>
	{
		var result = new ApiResult()
		{
			IsSuccess = false,
			MetaData = new MetaData()
			{
				Message = ModelStateUtil.GetModelStateErrors(context.ModelState),
				AppStatusCode = AppStatusCode.BadRequest
			}
		};
		return new BadRequestObjectResult(result);
	});
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
	var jwtSecurityScheme = new OpenApiSecurityScheme
	{
		Scheme = "bearer",
		BearerFormat = "JWT",
		Name = "JWT Authentication",
		In = ParameterLocation.Header,
		Type = SecuritySchemeType.Http,
		Description = "Enter Token",

		Reference = new OpenApiReference
		{
			Id = JwtBearerDefaults.AuthenticationScheme,
			Type = ReferenceType.SecurityScheme
		}
	};

	option.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

	option.AddSecurityRequirement(new OpenApiSecurityRequirement
	{
		{ jwtSecurityScheme, Array.Empty<string>() }
	});
});
var stringConnection = builder.Configuration.GetConnectionString("DefaultConnection");
ShopBootstrapper.RegisterShopDependency(builder.Services, stringConnection);
CommonBootstrapper.Init(builder.Services);
builder.Services.RegisterApiDependency();
builder.Services.AddJwtAuthentication(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
	app.UseSwagger();
	app.UseSwaggerUI();
//}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.UseApiCustomExceptionHandler();
app.MapControllers();

app.Run();
