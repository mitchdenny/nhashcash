using NHashcash;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NHashcash.Tests
{
	[TestClass()]
	public class MinterTests
	{
		[TestMethod()]
		[ExpectedException(typeof(ArgumentException))]
		public void CheckForFailureOnZeroLengthResource()
		{
			Minter minter = new Minter();
			string stamp = minter.Mint(string.Empty, 8, DateTime.Now, StampFormat.Version0);
		}

        [TestMethod()]
		[ExpectedException(typeof(ArgumentException))]
		public void CheckForFailureOnUrlResource()
		{
			Minter minter = new Minter();
			string stamp = minter.Mint("http://notgartner.com", 8, DateTime.Now, StampFormat.Version0);
		}

        [TestMethod()]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void CheckForFailureOnZeroLengthDenomination()
		{
			Minter minter = new Minter();
			string stamp = minter.Mint("foo0123456789", 0, DateTime.Now, StampFormat.Version0);
		}
}
}