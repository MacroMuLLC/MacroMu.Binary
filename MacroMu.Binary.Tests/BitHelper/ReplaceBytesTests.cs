using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

namespace MacroMu.Binary.Tests.BitHelper
{
    public class ReplaceBytesTests
    {

        [Fact]
        public void ReplaceBytes()
        {
            /* Arrange */
            int index = 2;
            byte[] replacementBytes = { 1, 2, 3 };
            byte[] buffer = { 5, 6, 7, 8, 9, 10 };
            byte[] expectedOutput = { 5, 6, 1, 2, 3, 10 };
            byte[] actualOutput;

            /* Act */
            actualOutput = buffer.ReplaceBytes(replacementBytes, index);
            bool actualIsExpected = actualOutput.SequenceEqual(expectedOutput);

            /* Assert */
            Assert.True(actualIsExpected);
        }

        [Fact]
        public void ReplaceBytes_NoReplacement()
        {
            /* Arrange */
            int index = 2;
            byte[] replacementBytes = Array.Empty<byte>();
            byte[] buffer = { 5, 6, 7, 8, 9, 10 };
            byte[] expectedOutput = { 5, 6, 7, 8, 9, 10 };
            byte[] actualOutput;

            /* Act */
            actualOutput = buffer.ReplaceBytes(replacementBytes, index);
            bool actualIsExpected = actualOutput.SequenceEqual(expectedOutput);

            /* Assert */
            Assert.True(actualIsExpected);
        }

        [Fact]
        public void ReplaceBytes_IndexOutOfRange()
        {
            var testAction = () =>
            {
                /* Arrange */
                int index = 4;
                byte[] replacementBytes = { 1, 2, 3 };
                byte[] buffer = { 5, 6, 7, 8, 9, 10 };
                byte[] expectedOutput = { 5, 6, 7, 8, 9, 10 };
                byte[] actualOutput;

                /* Act */
                actualOutput = buffer.ReplaceBytes(replacementBytes, index);
                bool actualIsExpected = actualOutput.SequenceEqual(expectedOutput);
            };

            /* Assert */
            Assert.Throws<IndexOutOfRangeException>(testAction);
        }

        [Fact]
        public void ReplaceBytes_IncorrectReplacement()
        {
            /* Arrange */
            int index = 2;
            byte[] replacementBytes = Array.Empty<byte>();
            byte[] buffer = { 5, 6, 7, 8, 9, 10 };
            byte[] expectedOutput = { 5, 6, 7, 8, 9, 11 };
            byte[] actualOutput;

            /* Act */
            actualOutput = buffer.ReplaceBytes(replacementBytes, index);
            bool actualIsExpected = actualOutput.SequenceEqual(expectedOutput);

            /* Assert */
            Assert.False(actualIsExpected);
        }
    }
}
