using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

namespace MacroMu.Binary.Tests.BitHelper
{
    public class GetBitValuesForBytesTests
    {
        public bool GetBitValues_FromByte_ActualOutputIsExpected(byte[] byteInput, bool[][] expectedOutput)
        {
            /* Arrange */
            bool[][] actualOutput;
            bool actualIsExpected = true;

            /* Act */
            actualOutput = byteInput.GetBitValues();

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
        public void Fail_GetBitValuesFromByteActialOutputIsExpected_MistmatchInputs()
        {
            /* Arrange */
            bool actualIsExpected;

            byte[] byteInput = { 65, 65 };

            bool[][] expectedOutput = new bool[2][];
            expectedOutput[0] = new bool[8] { false, false, false, false, false, false, true, false };
            expectedOutput[1] = new bool[8] { false, false, false, false, false, false, true, false };

            /* Act */
            actualIsExpected = GetBitValues_FromByte_ActualOutputIsExpected(byteInput, expectedOutput);

            /* Assert */
            Assert.False(actualIsExpected);
        }

        [Fact]
        public void Parse_GetBitValues_FromBytes_0_255()
        {
            /* Arrange */
            bool actualIsExpected;

            byte[] byteInput = { 0, 255 };
            
            bool[][] expectedOutput = new bool[2][];
            expectedOutput[0] = new bool[8] { false, false, false, false, false, false, false, false };
            expectedOutput[1] = new bool[8] { true, true, true, true, true, true, true, true };


            /* Act */
            actualIsExpected = GetBitValues_FromByte_ActualOutputIsExpected(byteInput, expectedOutput);

            /* Assert */
            Assert.True(actualIsExpected);
        }

        [Fact]
        public void Parse_GetBitValues_FromBytes_255_0()
        {
            /* Arrange */
            bool actualIsExpected;

            byte[] byteInput = { 255, 0 };

            bool[][] expectedOutput = new bool[2][];
            expectedOutput[0] = new bool[8] { true, true, true, true, true, true, true, true };
            expectedOutput[1] = new bool[8] { false, false, false, false, false, false, false, false };


            /* Act */
            actualIsExpected = GetBitValues_FromByte_ActualOutputIsExpected(byteInput, expectedOutput);

            /* Assert */
            Assert.True(actualIsExpected);
        }

        [Fact]
        public void Parse_GetBitValues_FromBytes_65_65()
        {
            /* Arrange */
            bool actualIsExpected;

            byte[] byteInput = { 65, 65 };

            bool[][] expectedOutput = new bool[2][];
            expectedOutput[0] = new bool[8] { true, false, false, false, false, false, true, false };
            expectedOutput[1] = new bool[8] { true, false, false, false, false, false, true, false };

            /* Act */
            actualIsExpected = GetBitValues_FromByte_ActualOutputIsExpected(byteInput, expectedOutput);

            /* Assert */
            Assert.True(actualIsExpected);
        }
    }
}
