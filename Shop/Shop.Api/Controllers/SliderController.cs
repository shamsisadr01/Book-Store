﻿using Common.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.Infrastructure.Security;
using Shop.L1.Domain.Role_Aggregate.Enums;
using Shop.L2.Application.SiteEntities.Sliders.Create;
using Shop.L2.Application.SiteEntities.Sliders.Edit;
using Shop.L4.Query.SiteEntities.DTOs;
using Shop.L5.Presentation.Facade.SiteEntities.Slider;

namespace Shop.Api.Controllers
{
	[PermissionChecker(Permission.CRUD_Slider)]
	public class SliderController : ApiController
	{
		private readonly ISliderFacade _facade;
		public SliderController(ISliderFacade facade)
		{
			_facade = facade;
		}
		[HttpGet,AllowAnonymous]
		public async Task<ApiResult<List<SliderDto>>> GetList()
		{
			var result = await _facade.GetSliders();
			return QueryResult(result);
		}
		[HttpGet("{id}")]
		public async Task<ApiResult<SliderDto?>> GetById(long id)
		{
			var result = await _facade.GetSliderById(id);
			return QueryResult(result);
		}
		[HttpPost]
		public async Task<ApiResult> Create(CreateSliderCommand command)
		{
			var result = await _facade.CreateSlider(command);
			return CommandResult(result);
		}
		[HttpPut]
		public async Task<ApiResult> Edit(EditSliderCommand command)
		{
			var result = await _facade.EditSlider(command);
			return CommandResult(result);
		}

        [HttpDelete("{sliderId}")]
        public async Task<ApiResult> Delete(long sliderId)
        {
            var result = await _facade.DeleteSlider(sliderId);
            return CommandResult(result);
        }
    }
}
