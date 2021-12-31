using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

namespace MacroMu.Binary.Tests.BitHelper
{
    public class GetBitValuesForUintTests
    {
        public bool GetBitValues_FromUint_ActualOutputIsExpected(uint numberInput, bool[][] expectedOutput)
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
        public void Fail_GetBitValuesFromUintActialOutputIsExpected_MistmatchInputs()
        {
            /* Arrange */
            bool actualIsExpected;

            uint byteInput = 16705;

            bool[][] expectedOutput = new bool[4][];
            expectedOutput[0] = new bool[8] { false, false, false, false, false, false, true, false };
            expectedOutput[1] = new bool[8] { false, false, false, false, false, false, true, false };
            expectedOutput[2] = new bool[8] { false, false, false, false, false, false, false, false };
            expectedOutput[3] = new bool[8] { false, false, false, false, false, false, false, false };

            /* Act */
            actualIsExpected = GetBitValues_FromUint_ActualOutputIsExpected(byteInput, expectedOutput);

            /* Assert */
            Assert.False(actualIsExpected);
        }

        [Fact]
        public void Parse_GetBitValues_FromUint_65280()
        {
            /* Arrange */
            bool actualIsExpected;

            uint byteInput = 65280;

            bool[][] expectedOutput = new bool[4][];
            expectedOutput[0] = new bool[8] { false, false, false, false, false, false, false, false };
            expectedOutput[1] = new bool[8] { true, true, true, true, true, true, true, true };
            expectedOutput[2] = new bool[8] { false, false, false, false, false, false, false, false };
            expectedOutput[3] = new bool[8] { false, false, false, false, false, false, false, false };

            /* Act */
            actualIsExpected = GetBitValues_FromUint_ActualOutputIsExpected(byteInput, expectedOutput);

            /* Assert */
            Assert.True(actualIsExpected);
        }

        [Fact]
        public void Parse_GetBitValues_FromUint_16705()
        {
            /* Arrange */
            bool actualIsExpected;

            uint byteInput = 16705;

            bool[][] expectedOutput = new bool[4][];
            expectedOutput[0] = new bool[8] { true, false, false, false, false, false, true, false };
            expectedOutput[1] = new bool[8] { true, false, false, false, false, false, true, false };
            expectedOutput[2] = new bool[8] { false, false, false, false, false, false, false, false };
            expectedOutput[3] = new bool[8] { false, false, false, false, false, false, false, false };

            /* Act */
            actualIsExpected = GetBitValues_FromUint_ActualOutputIsExpected(byteInput, expectedOutput);

            /* Assert */
            Assert.True(actualIsExpected);
        }
    }
}
