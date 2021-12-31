using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

namespace MacroMu.Binary.Tests.BitHelper
{
    public class SetBitValueTests
    {

        [Fact]
        public void SetBitValue_Bit0High()
        {
            /* Arrange */
            byte expectedOutput = 1;
            byte rawData = 0;
            byte index = 0;
            bool newValue = true;

            /* Act */
            byte actualOutput = rawData.SetBitValue(index, newValue);

            /* Assert */
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void SetBitValue_Bit0Low()
        {
            /* Arrange */
            byte expectedOutput = 0;
            byte rawData = 1;
            byte index = 0;
            bool newValue = false;

            /* Act */
            byte actualOutput = rawData.SetBitValue(index, newValue);

            /* Assert */
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void SetBitValue_IndexOutOfRange()
        {
            var testAction = () =>
            {
                /* Arrange */
                byte rawData = 1;
                byte index = 8;
                bool newValue = false;

                /* Act */
                byte actualOutput = rawData.SetBitValue(index, newValue);
            };

            /* Assert */
            Assert.Throws<ArgumentOutOfRangeException>(testAction);
        }
    }
}
