using Common.AspNetCore;
using Common.AspNetCore.Middlewares;
using Common.L2.Application;
using Microsoft.AspNetCore.Mvc;
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
builder.Services.AddSwaggerGen();
var stringConnection = builder.Configuration.GetConnectionString("DefaultConnection");
ShopBootstrapper.RegisterShopDependency(builder.Services, stringConnection);
CommonBootstrapper.Init(builder.Services);
builder.Services.AddJwtAuthentication(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
	app.UseSwagger();
	app.UseSwaggerUI();
//}

app.UseHttpsRedirection();
app.UseAuthorization();
//app.UseAuthentication();
app.UseApiCustomExceptionHandler();
app.MapControllers();

app.Run();
