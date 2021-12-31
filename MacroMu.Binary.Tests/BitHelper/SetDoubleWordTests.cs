using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

namespace MacroMu.Binary.Tests.BitHelper
{
    public class SetDoubleWordTests
    {

        [Fact]
        public void SetDoubleWord_0()
        {
            /* Arrange */
            byte[] expectedOutput = new byte[8] { 255, 0, 0, 0, 0, 0, 0, 0 };
            byte[] buffer = new byte[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
            int index = 0;
            uint value = 255;

            /* Act */
            byte[] actualOutput = buffer.SetDoubleWord(index, value);
            bool actualIsExpected = expectedOutput.SequenceEqual(actualOutput);

            /* Assert */
            Assert.True(actualIsExpected);
        }

        [Fact]
        public void SetDoubleWord_1()
        {
            /* Arrange */
            byte[] expectedOutput = new byte[8] { 0, 0, 0, 0, 255, 0, 0, 0 };
            byte[] buffer = new byte[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
            int index = 4;
            uint value = 255;

            /* Act */
            byte[] actualOutput = buffer.SetDoubleWord(index, value);
            bool actualIsExpected = expectedOutput.SequenceEqual(actualOutput);

            /* Assert */
            Assert.True(actualIsExpected);
        }

        [Fact]
        public void SetDoubleWord_IndexOutOfRange_Positive()
        {
            var testAction = () =>
            {
                /* Arrange */
                byte[] expectedOutput = new byte[8] { 0, 0, 0, 0, 255, 0, 0, 0 };
                byte[] buffer = new byte[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
                int index = 7;
                uint value = 255;

                /* Act */
                byte[] actualOutput = buffer.SetDoubleWord(index, value);
                bool actualIsExpected = expectedOutput.SequenceEqual(actualOutput);
            };

            /* Assert */
            Assert.Throws<ArgumentOutOfRangeException>(testAction);
        }

        [Fact]
        public void SetDoubleWord_IndexOutOfRange_Negative()
        {
            var testAction = () =>
            {
                /* Arrange */
                byte[] expectedOutput = new byte[8] { 0, 0, 0, 0, 255, 0, 0, 0 };
                byte[] buffer = new byte[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
                int index = -1;
                uint value = 255;

                /* Act */
                byte[] actualOutput = buffer.SetDoubleWord(index, value);
                bool actualIsExpected = expectedOutput.SequenceEqual(actualOutput);
            };

            /* Assert */
            Assert.Throws<ArgumentOutOfRangeException>(testAction);
        }
    }
}
