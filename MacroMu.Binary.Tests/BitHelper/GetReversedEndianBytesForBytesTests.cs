using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Xunit;
using System.Linq;

namespace MacroMu.Binary.Tests.BitHelper
{
    public class GetReversedEndianBytesForBytesTests
    {
        public bool GetBitValues_FromUlong_ActualOutputIsExpected(byte[] numberInput, byte[] expectedOutput)
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

            byte[] byteInput = new byte[8];
            byteInput[0] = 0;
            byteInput[1] = 1;
            byteInput[2] = 2;
            byteInput[3] = 3;
            byteInput[4] = 4;
            byteInput[5] = 5;
            byteInput[6] = 6;
            byteInput[7] = 7;

            byte[] expectedOutput = new byte[8];
            expectedOutput[0] = 0;
            expectedOutput[1] = 1;
            expectedOutput[2] = 2;
            expectedOutput[3] = 3;
            expectedOutput[4] = 4;
            expectedOutput[5] = 5;
            expectedOutput[6] = 6;
            expectedOutput[7] = 7;

            /* Act */
            actualIsExpected = GetBitValues_FromUlong_ActualOutputIsExpected(byteInput, expectedOutput);

            /* Assert */
            Assert.False(actualIsExpected);
        }

        [Fact]
        public void Parse_GetBitValues_FromUlong_65280()
        {
            /* Arrange */
            bool actualIsExpected;

            byte[] byteInput = new byte[8];
            byteInput[0] = 7;
            byteInput[1] = 6;
            byteInput[2] = 5;
            byteInput[3] = 4;
            byteInput[4] = 3;
            byteInput[5] = 2;
            byteInput[6] = 1;
            byteInput[7] = 0;

            byte[] expectedOutput = new byte[8];
            expectedOutput[0] = 0;
            expectedOutput[1] = 1;
            expectedOutput[2] = 2;
            expectedOutput[3] = 3;
            expectedOutput[4] = 4;
            expectedOutput[5] = 5;
            expectedOutput[6] = 6;
            expectedOutput[7] = 7;

            /* Act */
            actualIsExpected = GetBitValues_FromUlong_ActualOutputIsExpected(byteInput, expectedOutput);

            /* Assert */
            Assert.True(actualIsExpected);
        }
    }
}
