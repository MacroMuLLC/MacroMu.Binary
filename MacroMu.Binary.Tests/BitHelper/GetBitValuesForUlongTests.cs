using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

namespace MacroMu.Binary.Tests.BitHelper
{
    public class GetBitValuesForUlongTests
    {
        public bool GetBitValues_FromUlong_ActualOutputIsExpected(ulong numberInput, bool[][] expectedOutput)
        {
            /* Arrange */
            bool[][] actualOutput;
            bool actualIsExpected = true;

            /* Act */
            actualOutput = numberInput.GetBitValues();

            // Iterate over each byte in the array and compare the sequence of our acutal output to the provided expected output
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
        public void Fail_GetBitValuesFromUlongActialOutputIsExpected_MistmatchInputs()
        {
            /* Arrange */
            bool actualIsExpected;

            ulong byteInput = 16705;

            bool[][] expectedOutput = new bool[8][];
            expectedOutput[0] = new bool[8] { false, false, false, false, false, false, true, false };
            expectedOutput[1] = new bool[8] { false, false, false, false, false, false, true, false };
            expectedOutput[2] = new bool[8] { false, false, false, false, false, false, false, false };
            expectedOutput[3] = new bool[8] { false, false, false, false, false, false, false, false };
            expectedOutput[4] = new bool[8] { false, false, false, false, false, false, false, false };
            expectedOutput[5] = new bool[8] { false, false, false, false, false, false, false, false };
            expectedOutput[6] = new bool[8] { false, false, false, false, false, false, false, false };
            expectedOutput[7] = new bool[8] { false, false, false, false, false, false, false, false };

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

            uint byteInput = 65280;

            bool[][] expectedOutput = new bool[8][];
            expectedOutput[0] = new bool[8] { false, false, false, false, false, false, false, false };
            expectedOutput[1] = new bool[8] { true, true, true, true, true, true, true, true };
            expectedOutput[2] = new bool[8] { false, false, false, false, false, false, false, false };
            expectedOutput[3] = new bool[8] { false, false, false, false, false, false, false, false };
            expectedOutput[4] = new bool[8] { false, false, false, false, false, false, false, false };
            expectedOutput[5] = new bool[8] { false, false, false, false, false, false, false, false };
            expectedOutput[6] = new bool[8] { false, false, false, false, false, false, false, false };
            expectedOutput[7] = new bool[8] { false, false, false, false, false, false, false, false };

            /* Act */
            actualIsExpected = GetBitValues_FromUlong_ActualOutputIsExpected(byteInput, expectedOutput);

            /* Assert */
            Assert.True(actualIsExpected);
        }

        [Fact]
        public void Parse_GetBitValues_FromUlong_16705()
        {
            /* Arrange */
            bool actualIsExpected;

            ulong byteInput = 16705;

            bool[][] expectedOutput = new bool[8][];
            expectedOutput[0] = new bool[8] { true, false, false, false, false, false, true, false };
            expectedOutput[1] = new bool[8] { true, false, false, false, false, false, true, false };
            expectedOutput[2] = new bool[8] { false, false, false, false, false, false, false, false };
            expectedOutput[3] = new bool[8] { false, false, false, false, false, false, false, false };
            expectedOutput[4] = new bool[8] { false, false, false, false, false, false, false, false };
            expectedOutput[5] = new bool[8] { false, false, false, false, false, false, false, false }; 
            expectedOutput[6] = new bool[8] { false, false, false, false, false, false, false, false };
            expectedOutput[7] = new bool[8] { false, false, false, false, false, false, false, false };

            /* Act */
            actualIsExpected = GetBitValues_FromUlong_ActualOutputIsExpected(byteInput, expectedOutput);

            /* Assert */
            Assert.True(actualIsExpected);
        }
    }
}
