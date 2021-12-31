using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

namespace MacroMu.Binary.Tests.BitHelper
{
    public class SetWordTests
    {

        [Fact]
        public void SetWord_0()
        {
            /* Arrange */
            byte[] expectedOutput = new byte[8] { 255, 0, 0, 0, 0, 0, 0, 0 };
            byte[] buffer = new byte[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
            int index = 0;
            ushort value = 255;

            /* Act */
            byte[] actualOutput = buffer.SetWord(index, value);
            bool actualIsExpected = expectedOutput.SequenceEqual(actualOutput);

            /* Assert */
            Assert.True(actualIsExpected);
        }

        [Fact]
        public void SetWord_1()
        {
            /* Arrange */
            byte[] expectedOutput = new byte[8] { 0, 0, 0, 0, 255, 0, 0, 0 };
            byte[] buffer = new byte[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
            int index = 4;
            ushort value = 255;

            /* Act */
            byte[] actualOutput = buffer.SetWord(index, value);
            bool actualIsExpected = expectedOutput.SequenceEqual(actualOutput);

            /* Assert */
            Assert.True(actualIsExpected);
        }

        [Fact]
        public void SetWord_IndexOutOfRange_Positive()
        {
            var testAction = () =>
            {
                /* Arrange */
                byte[] expectedOutput = new byte[8] { 0, 0, 0, 0, 255, 0, 0, 0 };
                byte[] buffer = new byte[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
                int index = 7;
                ushort value = 255;

                /* Act */
                byte[] actualOutput = buffer.SetWord(index, value);
                bool actualIsExpected = expectedOutput.SequenceEqual(actualOutput);
            };

            /* Assert */
            Assert.Throws<ArgumentOutOfRangeException>(testAction);
        }

        [Fact]
        public void SetWord_IndexOutOfRange_Negative()
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
