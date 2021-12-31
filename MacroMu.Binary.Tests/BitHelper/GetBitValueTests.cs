using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MacroMu.Binary;
using Xunit;

namespace MacroMu.Binary.Tests.BitHelper
{
    public class GetBitValueTests
    {
        [Fact]
        public void Parse_BitWithinByte_ReturnHigh()
        {
            /* Arrange */

            byte singleByteData = 0b00000010;
            

            /* Act */

            // Bit index 1 is high, and should be true
            bool bitIsHigh = singleByteData.GetBitValue(1);


            /* Assert */

            Assert.True(bitIsHigh, "For byte 0x00000010, Bit index 1 should be high");
        }

        [Fact]
        public void Parse_BitWithinByte_ReturnLow()
        {
            /* Arrange */

            byte singleByteData = 0b00000010;


            /* Act */

            // Bit index 0 is low, and should be false
            bool bitIsLow = !singleByteData.GetBitValue(0);


            /* Assert */

            Assert.True(bitIsLow, "For byte 0x00000010, Bit index 0 should be low");
        }

        [Fact]
        public void FailParse_BitWithinByte_BitIndexOutOfRange()
        {
            Action failParse = new Action(() =>
            {
                /* Arrange */
                byte singleByteData = 0b00000010;
                byte indexToRead = 8;

                /* Act */

                // Bit index 1 is high, and should be true
                singleByteData.GetBitValue(indexToRead);
            });


            /* Assert */

            Assert.Throws<ArgumentOutOfRangeException>(failParse);
        }
    }
}
