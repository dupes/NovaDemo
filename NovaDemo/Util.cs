using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovaDemo
{
	class Util
	{
		public static DateTime FromEpoch(long secondsFromEpoch)
		{
			return new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(Convert.ToDouble(secondsFromEpoch)).ToLocalTime();
		}
	}
}
