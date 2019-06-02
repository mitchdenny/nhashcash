using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTestContrib.Specifications;
using System.Diagnostics;

namespace NHashcash.Specifications
{
    [TestClass]
    [SpecificationDescription("NHashcash Minter")]
    [DeploymentItem("Tools\\hashcash.exe")]
    public class MinterSpecification : Specification
    {
        public string Resource { get; set; }
        public Minter Minter { get; set; }
        public string Stamp { get; set; }
        public int Denomination { get; set; }
        public StampFormat Format { get; set; }


        private bool IsValidStamp(int denomination, string resource, string stamp, int expectedExitCode)
        {
            string arguments = string.Format("-c -d -b {0} -r {0} {1}", resource, stamp);
            var process = Process.Start("hashcash.exe", arguments);
            var exited = process.WaitForExit(1000);

            if (!exited)
            {
                throw new TimeoutException(
                    "The hashcash.exe program was not able to validate the stamp produced within one second."
                    );
            }

            return process.ExitCode == 0;
        }

        [TestMethod]
        [ScenarioDescription("Generate a format version one stamp with a denomination of sixteen and ensure it validates using the Hashcash reference implmentation")]
        public void GenerateAFormatVersionOneStampWithADenominationOfSixteenAndEnsureItValidatesUsingTheHashcashReferenceImplementation()
        {
            Given("a resource of 'mitch.denny@notgartner.com'", x => Resource = "foo123456789")
                .And("an instance of the Minter class", x => Minter = new Minter())
                .And("a denomination of sixteen", x => Denomination = 16)
                .And("a stamp format version of 1", x => Format = StampFormat.Version1)
                .When("the Mint method is called", x => Stamp = Minter.Mint(Resource, Denomination, Format))
                .Then("it should generate a valid stamp", x => IsValidStamp(Denomination, Resource, Stamp, 0));
        }

        [TestMethod]
        [ScenarioDescription("Generate a format version one stamp with a denomination of seventeen and ensure it validates using the Hashcash reference implmentation")]
        public void GenerateAFormatVersionOneStampWithADenominationOfSeventeenAndEnsureItValidatesUsingTheHashcashReferenceImplementation()
        {
            Given("a resource of 'mitch.denny@notgartner.com'", x => Resource = "foo123456789")
                .And("an instance of the Minter class", x => Minter = new Minter())
                .And("a denomination of sixteen", x => Denomination = 17)
                .And("a stamp format version of 1", x => Format = StampFormat.Version1)
                .When("the Mint method is called", x => Stamp = Minter.Mint(Resource, Denomination, Format))
                .Then("it should generate a valid stamp", x => IsValidStamp(Denomination, Resource, Stamp, 0));
        }

        [TestMethod]
        [ScenarioDescription("Generate a stamp with a denomination of sixteen and ensure it validates using the Hashcash reference implmentation")]
        public void GenerateAFormatVersionZeroStampWithADenominationOfSixteenAndEnsureItValidatesUsingTheHashcashReferenceImplementation()
        {
            Given("a resource of 'mitch.denny@notgartner.com'", x => Resource = "foo123456789")
                .And("an instance of the Minter class", x => Minter = new Minter())
                .And("a denomination of sixteen", x => Denomination = 16)
                .And("a stamp format version of 1", x => Format = StampFormat.Version0)
                .When("the Mint method is called", x => Stamp = Minter.Mint(Resource, Denomination, Format))
                .Then("it should generate a valid stamp", x => IsValidStamp(Denomination, Resource, Stamp, 0));
        }

        [TestMethod]
        [ScenarioDescription("Generate a stamp with a denomination of seventeen and ensure it validates using the Hashcash reference implmentation")]
        public void GenerateAFormatVersionZeroStampWithADenominationOfSeventeenAndEnsureItValidatesUsingTheHashcashReferenceImplementation()
        {
            Given("a resource of 'mitch.denny@notgartner.com'", x => Resource = "foo123456789")
                .And("an instance of the Minter class", x => Minter = new Minter())
                .And("a denomination of sixteen", x => Denomination = 17)
                .And("a stamp format version of 1", x => Format = StampFormat.Version0)
                .When("the Mint method is called", x => Stamp = Minter.Mint(Resource, Denomination, Format))
                .Then("it should generate a valid stamp", x => IsValidStamp(Denomination, Resource, Stamp, 0));
        }
    }
}
