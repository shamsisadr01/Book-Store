﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain.Exceptions
{
	public class NullOrEmptyDomainDataException : BaseDomainException
	{
		public NullOrEmptyDomainDataException()
		{

		}

		public NullOrEmptyDomainDataException(string message) : base(message)
		{

		}

		public static void CheckedString(string value, string nameOf)
		{
			if (string.IsNullOrWhiteSpace(value))
				throw new NullOrEmptyDomainDataException($"{nameOf} Is Null Or Empty");
		}
	}
}
