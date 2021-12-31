using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Xunit;
using System.Linq;

namespace MacroMu.Binary.Tests.BitHelper
{
    public class GetReversedEndianBytesForUlongTests
    {
        public bool GetBitValues_FromUlong_ActualOutputIsExpected(ulong numberInput, byte[] expectedOutput)
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
        public void Fail_GetBitValuesFromUlongActialOutputIsExpected_MistmatchInputs()
        {
            /* Arrange */
            bool actualIsExpected;
            ulong numberInput = 255;

            byte[] expectedOutput = new byte[8];
            expectedOutput[0] = 255;
            expectedOutput[1] = 0;
            expectedOutput[2] = 0;
            expectedOutput[3] = 0;
            expectedOutput[4] = 0;
            expectedOutput[5] = 0;
            expectedOutput[6] = 0;
            expectedOutput[7] = 0;

            /* Act */
            actualIsExpected = GetBitValues_FromUlong_ActualOutputIsExpected(numberInput, expectedOutput);

            /* Assert */
            Assert.False(actualIsExpected);
        }

        [Fact]
        public void Parse_GetBitValues_FromUlong_65280()
        {
            /* Arrange */
            bool actualIsExpected;

            ulong numberInput = 65280;

            byte[] expectedOutput = new byte[8];
            expectedOutput[0] = 0;
            expectedOutput[1] = 0;
            expectedOutput[2] = 0;
            expectedOutput[3] = 0;
            expectedOutput[4] = 0;
            expectedOutput[5] = 0;
            expectedOutput[6] = 255;
            expectedOutput[7] = 0;

            /* Act */
            actualIsExpected = GetBitValues_FromUlong_ActualOutputIsExpected(numberInput, expectedOutput);

            /* Assert */
            Assert.True(actualIsExpected);
        }
    }
}
