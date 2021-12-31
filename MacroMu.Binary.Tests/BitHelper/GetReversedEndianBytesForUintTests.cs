using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Xunit;
using System.Linq;

namespace MacroMu.Binary.Tests.BitHelper
{
    public class GetReversedEndianBytesForUintTests
    {
        public bool GetBitValues_FromUint_ActualOutputIsExpected(uint numberInput, byte[] expectedOutput)
        {
            /* Arrange */
            byte[] actualOutput;
            bool actualIsExpected;

            /* Act */
            actualOutput = numberInput.GetReversedEndianBytes();
            actualIsExpected = actualOutput.SequenceEqual(expectedOutput);

            /* Return */
            return actualIsExpected;
        }

        [Fact]
        public void Fail_GetBitValuesFromUintActialOutputIsExpected_MistmatchInputs()
        {
            /* Arrange */
            bool actualIsExpected;
            uint numberInput = 255;

            byte[] expectedOutput = new byte[4];
            expectedOutput[0]  = 255;
            expectedOutput[1]  = 0;
            expectedOutput[2] = 0;
            expectedOutput[3] = 0;

            /* Act */
            actualIsExpected = GetBitValues_FromUint_ActualOutputIsExpected(numberInput, expectedOutput);

            /* Assert */
            Assert.False(actualIsExpected);
        }

        [Fact]
        public void Parse_GetBitValues_FromUint_65280()
        {
            /* Arrange */
            bool actualIsExpected;

            uint numberInput = 65280;

            byte[] expectedOutput = new byte[4];
            expectedOutput[0] = 0;
            expectedOutput[1] = 0;
            expectedOutput[2] = 255;
            expectedOutput[3] = 0;

            /* Act */
            actualIsExpected = GetBitValues_FromUint_ActualOutputIsExpected(numberInput, expectedOutput);

            /* Assert */
            Assert.True(actualIsExpected);
        }
    }
}
