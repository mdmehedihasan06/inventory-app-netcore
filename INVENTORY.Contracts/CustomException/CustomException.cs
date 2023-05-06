﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace INVENTORY.Contracts.CustomException
{
    public class CustomException : Exception
    {
		public HttpStatusCode StatusCode { get; set; }

		public CustomException(string message, HttpStatusCode statusCode)
			: base(message)
		{
			StatusCode = statusCode;
		}
	}
}
