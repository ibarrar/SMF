using System;
using System.Text.RegularExpressions;

namespace SmfRewriteProject.Util
{
	public class IsNumeric
	{
		private static Regex r = new Regex(@"(^[-+]?\d+(,?\d*)*\.?\d*([Ee][-+]\d*)?$)|(^[-+]?\d?(,?\d*)*\.\d+([Ee][-+]\d*)?$)");
		public static bool check(string str){
			str = str.Trim();
			return r.Match(str).Success;
		}
	}
}
