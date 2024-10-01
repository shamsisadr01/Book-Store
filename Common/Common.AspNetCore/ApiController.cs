﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Common.L2.Application;

namespace Common.AspNetCore
{
	[Route("api/[controller]")]
	[ApiController]
	public class ApiController : ControllerBase
	{
		protected ApiResult CommandResult(OperationResult result)
		{
			return new ApiResult()
			{
				IsSuccess = result.Status == OperationResultStatus.Success,
				MetaData = new MetaData()
				{
					Message = result.Message,
					AppStatusCode = result.Status.MapOperationStatus(),
				}
			};
		}

		protected ApiResult<TData?> CommandResult<TData>(OperationResult<TData> result,
			HttpStatusCode httpStatus = HttpStatusCode.OK,string locationUrl = null)
		{
			var isSuccess = result.Status == OperationResultStatus.Success;
			if (isSuccess)
			{
				HttpContext.Response.StatusCode = (int)httpStatus;
				if (string.IsNullOrWhiteSpace(locationUrl) == false)
				{
					HttpContext.Response.Headers.Add("location", locationUrl);
				}
			}
			return new ApiResult<TData?>()
			{
				IsSuccess = isSuccess,
				Data = isSuccess?result.Data:default,
				MetaData = new MetaData()
				{
					Message = result.Message,
					AppStatusCode = result.Status.MapOperationStatus(),
				}
			};
		}

		protected ApiResult<TData> QueryResult<TData>(TData result)
		{
			return new ApiResult<TData>()
			{
				IsSuccess = true,
				Data = result,
				MetaData = new MetaData()
				{
					Message = "عملیات با موفقیت انجام شد.",
					AppStatusCode = AppStatusCode.Success
				}
			};
		}
	}

	public static class EnumHelper
	{
		public static AppStatusCode MapOperationStatus(this OperationResultStatus status)
		{
			switch (status)
			{
				case OperationResultStatus.Success:
					return AppStatusCode.Success;
				case OperationResultStatus.NotFound:
					return AppStatusCode.NotFound;
				case OperationResultStatus.Error:
					return AppStatusCode.LogicError;
			}
			return AppStatusCode.LogicError;
		}
	}
}
