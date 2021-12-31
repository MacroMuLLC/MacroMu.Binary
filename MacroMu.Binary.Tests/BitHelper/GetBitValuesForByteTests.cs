using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MacroMu.Binary;
using Xunit;

namespace MacroMu.Binary.Tests.BitHelper
{
    public class GetBitValuesForByteTests
    {
        public bool GetBitValues_FromByte_ActualOutputIsExpected(byte byteInput, bool[] expectedOutput)
        {
            /* Arrange */
            bool[] actualOutput;
            bool actualIsExpected;

            /* Act */
            actualOutput = byteInput.GetBitValues();
            actualIsExpected = expectedOutput.SequenceEqual(actualOutput);

            /* Return */
            return actualIsExpected;
        }

        [Fact]
        public void Parse_GetBitValues_FromByte_ForDecimal0()
        {
            /* Arrange */
            byte byteInput = 0;
            bool[] expectedOutput = { false, false, false, false, false, false, false, false };

            /* Act */
            bool actualIsExpected = GetBitValues_FromByte_ActualOutputIsExpected(byteInput, expectedOutput);

            /* Assert */
            Assert.True(actualIsExpected);
        }

        [Fact]
        public void Parse_GetBitValues_FromByte_ForDecimal31()
        {
            /* Arrange */
            byte byteInput = 31;
            bool[] expectedOutput = { true, true, true, true, true, false, false, false };

            /* Act */
            bool actualIsExpected = GetBitValues_FromByte_ActualOutputIsExpected(byteInput, expectedOutput);

            /* Assert */
            Assert.True(actualIsExpected);
        }

        [Fact]
        public void Parse_GetBitValues_FromByte_ForDecimal255()
        {
            /* Arrange */
            byte byteInput = 255;
            bool[] expectedOutput = { true, true, true, true, true, true, true, true };

            /* Act */
            bool actualIsExpected = GetBitValues_FromByte_ActualOutputIsExpected(byteInput, expectedOutput);

            /* Assert */
            Assert.True(actualIsExpected);

        }
    }
}
