﻿using Shop.Api.Infrastructure.Gateways.Zibal;
using Shop.Api.Infrastructure.JwtUtil;

namespace Shop.Api.Infrastructure;

public static class DependencyRegister
{
	public static void RegisterApiDependency(this IServiceCollection service)
	{
		service.AddAutoMapper(typeof(MapperProfile).Assembly);
		service.AddTransient<CustomJwtValidation>();
		service.AddHttpClient<IZibalService,ZibalService>();
	}
}