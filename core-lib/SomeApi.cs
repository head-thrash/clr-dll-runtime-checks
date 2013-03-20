using System;

namespace core_lib
{
    public class SomeApi
    {
		public string IDoSomeOtherStuff(string @string)
		{
			var charArray = @string.ToCharArray();
			Array.Reverse(charArray);
			return new string(charArray);
		}

		public string DoSomeStuff(string aString)
		{
			return IDoSomeOtherStuff(aString.ToUpper());
		}

		public static SomeApi ReturnMe()
		{
			return new SomeApi();
		}
    }
}
