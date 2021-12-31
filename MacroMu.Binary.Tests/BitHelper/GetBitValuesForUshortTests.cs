using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

namespace MacroMu.Binary.Tests.BitHelper
{
    public class GetBitValuesForUshortTests
    {
        public bool GetBitValues_FromUshort_ActualOutputIsExpected(ushort numberInput, bool[][] expectedOutput)
        {
            /* Arrange */
            bool[][] actualOutput;
            bool actualIsExpected = true;

            /* Act */
            actualOutput = numberInput.GetBitValues();

            for (int i = 0; i < actualOutput.Length; i++)
            {
                if (!actualOutput[i].SequenceEqual(expectedOutput[i]))
                {
                    actualIsExpected = false;
                    break;
                }
            }

            /* Return */
            return actualIsExpected;
        }

        [Fact]
        public void Fail_GetBitValuesFromUshortActialOutputIsExpected_MistmatchInputs()
        {
            /* Arrange */
            bool actualIsExpected;

            ushort byteInput = 16705;

            bool[][] expectedOutput = new bool[2][];
            expectedOutput[0] = new bool[8] { false, false, false, false, false, false, true, false };
            expectedOutput[1] = new bool[8] { false, false, false, false, false, false, true, false };

            /* Act */
            actualIsExpected = GetBitValues_FromUshort_ActualOutputIsExpected(byteInput, expectedOutput);

            /* Assert */
            Assert.False(actualIsExpected);
        }

        [Fact]
        public void Parse_GetBitValues_FromUShort_65280()
        {
            /* Arrange */
            bool actualIsExpected;

            ushort byteInput = 65280;

            bool[][] expectedOutput = new bool[2][];
            expectedOutput[0] = new bool[8] { false, false, false, false, false, false, false, false };
            expectedOutput[1] = new bool[8] { true, true, true, true, true, true, true, true };


            /* Act */
            actualIsExpected = GetBitValues_FromUshort_ActualOutputIsExpected(byteInput, expectedOutput);

            /* Assert */
            Assert.True(actualIsExpected);
        }

        [Fact]
        public void Parse_GetBitValues_FromUshort_16705()
        {
            /* Arrange */
            bool actualIsExpected;

            ushort byteInput = 16705;

            bool[][] expectedOutput = new bool[2][];
            expectedOutput[0] = new bool[8] { true, false, false, false, false, false, true, false };
            expectedOutput[1] = new bool[8] { true, false, false, false, false, false, true, false };

            /* Act */
            actualIsExpected = GetBitValues_FromUshort_ActualOutputIsExpected(byteInput, expectedOutput);

            /* Assert */
            Assert.True(actualIsExpected);
        }
    }
}
