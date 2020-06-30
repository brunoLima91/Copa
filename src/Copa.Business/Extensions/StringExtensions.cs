using System;
using System.Collections.Generic;
using System.Text;

namespace API.Copa.Business.Extensions
{
	public static class StringExtensions
	{
		public static bool In (this String str, params String[] pCompares)
		{
			foreach (var pCompar in pCompares)
			{
				if (str == pCompar)
					return true;
			}
			return false;
		}
	}
}
