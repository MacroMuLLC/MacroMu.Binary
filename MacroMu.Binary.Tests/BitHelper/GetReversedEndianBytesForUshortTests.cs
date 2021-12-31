using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Xunit;
using System.Linq;

namespace MacroMu.Binary.Tests.BitHelper
{
    public class GetReversedEndianBytesForUshortTests
    {
        public bool GetBitValues_FromUshort_ActualOutputIsExpected(ushort numberInput, byte[] expectedOutput)
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
        public void Fail_GetBitValuesFromUshortActialOutputIsExpected_MistmatchInputs()
        {
            /* Arrange */
            bool actualIsExpected;
            ushort numberInput = 255;

            byte[] expectedOutput = new byte[2];
            expectedOutput[0]  = 255;
            expectedOutput[1]  = 0;

            /* Act */
            actualIsExpected = GetBitValues_FromUshort_ActualOutputIsExpected(numberInput, expectedOutput);

            /* Assert */
            Assert.False(actualIsExpected);
        }

        [Fact]
        public void Parse_GetBitValues_FromUshort_65280()
        {
            /* Arrange */
            bool actualIsExpected;

            ushort numberInput = 65280;

            byte[] expectedOutput = new byte[2];
            expectedOutput[0] = 255;
            expectedOutput[1] = 0;

            /* Act */
            actualIsExpected = GetBitValues_FromUshort_ActualOutputIsExpected(numberInput, expectedOutput);

            /* Assert */
            Assert.True(actualIsExpected);
        }
    }
}
