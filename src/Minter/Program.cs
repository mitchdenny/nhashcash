using NHashcash;
using System;

namespace Minter
{
	public class Program
	{
		public static int Main(string[] args)
		{
			int returnCode = 0;

			try
			{
				string resource = args[0];
				int denomination = int.Parse(args[1]);
				StampFormat format = (StampFormat)Enum.Parse(typeof(StampFormat), string.Format("Version{0}", args[2]));

				NHashcash.Minter minter = new NHashcash.Minter();
				string stamp = minter.Mint(resource, denomination, DateTime.Now, format);
				Console.WriteLine(stamp);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
				returnCode = 1;
			}

			return returnCode;
		}
	}
}