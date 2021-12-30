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
        public void GetHighBitValueWithinRange()
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
        public void GetLowBitValueWithinRange()
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
        public void GetBitValueOutOfRange()
        {
            /* Arrange */
            bool exceptionThrown = false;
            byte singleByteData = 0b00000010;
            byte indexToRead = 8;

            /* Act */

            try
            {
                // Bit index 1 is high, and should be true
                singleByteData.GetBitValue(indexToRead);
            }
            catch (ArgumentOutOfRangeException exception)
            {
                exceptionThrown = true;
            }


            /* Assert */

            Assert.True(exceptionThrown, "A number greater than or equal to 8 should result in an ArgumentOutOfRangeException");
        }
    }
}
