using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace MacroMu.Binary
{
    /// <summary>
    /// Enum to classify byte order
    /// </summary>
    public enum Endianness
    {
        LittleEndian,
        BigEndian
    };

    /// <summary>
    /// Helper class to add ability to get bit values as booleans from bytes
    /// </summary>
    public static class BitHelper
    {
        /// <summary>
        /// Returns if the current system operates in Big or Little Endian byte order
        /// </summary>
        public static Endianness Endianness => BitConverter.IsLittleEndian ? Endianness.LittleEndian : Endianness.BigEndian;

        ///// <summary>
        ///// Get the value of a bit within a single byte
        ///// </summary>
        ///// <param name="data">Byte to operate on</param>
        ///// <param name="index">Zero based index of the bit to check</param>
        ///// <returns>true if the bit is 1, false if the bit is 0</returns>
        public static bool GetBitValue(this byte data, byte index)
        {
            if (index >= 8)
                throw new ArgumentOutOfRangeException("0-based index for a bit within the byte must be less than 8 and greater than or equal to 0.");

            return (data & (1 << index)) != 0;
        }

        /// <summary>
        /// Get the value of all bits within a single byte
        /// </summary>
        /// <param name="data">Byte to operate on</param>
        /// <returns>An array of booleans with the index of each bool aligned with the bit in the byte</returns>
        public static bool[] GetBitValues(this byte data)
        {
            bool[] result = new bool[8];
            for (byte index = 0; index < 8; index++)
            {
                result[index] = data.GetBitValue(index);
            }

            return result;
        }

        /// <summary>
        /// Get the valu of all bits within an array of bytes
        /// </summary>
        /// <param name="data"></param>
        /// <returns>true if the bit is 1, false if the bit is 0</returns>
        public static bool[][] GetBitValues(this byte[] data)
        {
            bool[][] result = new bool[data.Length][];

            for (int byteIndex = 0; byteIndex < data.Length; byteIndex++)
            {
                result[byteIndex] = data[byteIndex].GetBitValues();
            }

            return result;
        }

        /// <summary>
        /// Get the value of all bits within a the bytes of an unsigned numeric data type
        /// </summary>
        /// <param name="data">Unsigned numeric value to operate on</param>
        /// <returns>An array of booleans with the index of each bool aligned with the bit in the byte</returns>
        public static bool[][] GetBitValues(this ushort data) => GetBitValues(BitConverter.GetBytes(data));

        /// <summary>
        /// Get the value of all bits within a the bytes of an unsigned numeric data type
        /// </summary>
        /// <param name="data">Unsigned numeric value to operate on</param>
        /// <returns>An array of booleans with the index of each bool aligned with the bit in the byte</returns>
        public static bool[][] GetBitValues(this uint data) => GetBitValues(BitConverter.GetBytes(data));

        /// <summary>
        /// Get the value of all bits within a the bytes of an unsigned numeric data type
        /// </summary>
        /// <param name="data">Unsigned numeric value to operate on</param>
        /// <returns>An array of booleans with the index of each bool aligned with the bit in the byte</returns>
        public static bool[][] GetBitValues(this ulong data) => GetBitValues(BitConverter.GetBytes(data));

        /// <summary>
        /// Returns the byte array representation of the value, but with the byte order of the provided data reversed
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Byte array representation of the value, but with the byte order of the provided data reversed</returns>
        public static byte[] GetReversedEndianBytes(this byte[] data)
        {
            // Copy the data from the initial byte array so that we do not reverse the order in the original reference
            byte[] buffer = new byte[data.Length];
            data.CopyTo(buffer, 0);
            Array.Reverse(buffer);
            return buffer;
        }

        /// <summary>
        /// Returns the byte array representation of the value, but with the byte order of the provided data reversed
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Byte array representation of the value, but with the byte order of the provided data reversed</returns>
        public static byte[] GetReversedEndianBytes(this ushort data)
        {
            var buffer = BitConverter.GetBytes(data);
            Array.Reverse(buffer);
            return buffer;
        }

        /// <summary>
        /// Returns the byte array representation of the value, but with the byte order of the provided data reversed
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Byte array representation of the value, but with the byte order of the provided data reversed</returns>
        public static byte[] GetReversedEndianBytes(this uint data)
        {
            var buffer = BitConverter.GetBytes(data);
            Array.Reverse(buffer);
            return buffer;
        }

        /// <summary>
        /// Returns the byte array representation of the value, but with the byte order of the provided data reversed
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Byte array representation of the value, but with the byte order of the provided data reversed</returns>
        public static byte[] GetReversedEndianBytes(this ulong data)
        {
            var buffer = BitConverter.GetBytes(data);
            Array.Reverse(buffer);
            return buffer;
        }

        /// <summary>
        /// Returns the resulting byte when the index provided has been set either high or low. Does not mutate the current byte.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="index"></param>
        /// <param name="newValue"></param>
        /// <returns></returns>
        public static byte SetBitValue(this byte data, byte index, bool newValue)
        {
            if (index >= 8)
                throw new ArgumentOutOfRangeException("index", "index must be between 0 and 7");

            byte newData = data;

            // Use inclusive or to set high, XOR if it needs tobe CHANGED to 0
            if (newValue)
            {
                newData = (byte)(data | (1 << index));
            }
            else if (data.GetBitValue(index))
            {
                newData = (byte)(data ^ (1 << index));
            }

            return newData;
        }

        /// <summary>
        /// Returns a new byte array containing the original array with the double word
        /// at the index specified replaced with the new value specified
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="index"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="InvalidEnumArgumentException"></exception>
        public static byte[] SetDoubleWord(this byte[] buffer, int index, uint value)
        {
            if (buffer.Length < sizeof(ushort))
                throw new InvalidEnumArgumentException("Cannot set the double word value when the buffer is shorter than a double word.");

            byte[] valueBytes = BitConverter.GetBytes(value);
            List<byte> newBody = buffer[0..(index)].ToList();
            newBody.AddRange(valueBytes);
            newBody.AddRange(buffer[(index + sizeof(uint) - 1)..(buffer.Length-1)]);

            return newBody.ToArray();
        }

        /// <summary>
        /// Returns a new byte array containing the original array with the word at the
        /// index provided replaced with the ushort / word provided.
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="index"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="InvalidEnumArgumentException"></exception>
        public static byte[] SetWord(this byte[] buffer, int index, ushort value)
        {
            if (buffer.Length < sizeof(ushort))
                throw new InvalidEnumArgumentException("Cannot set the word value when the buffer is shorter than a word.");

            byte[] valueBytes = BitConverter.GetBytes(value);
            List<byte> newBody = buffer[0..(index)].ToList();
            newBody.AddRange(valueBytes);
            newBody.AddRange(buffer[(index + sizeof(ushort) - 1)..(buffer.Length - 1)]);

            return newBody.ToArray();
        }

        /// <summary>
        /// Returns a new byte array where the bytes in the array at the index
        /// provided have been replaced with the replacementBytes
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="replacementBytes"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static byte[] ReplaceBytes(this byte[] buffer, byte[] replacementBytes, int index)
        {
            if (index < 0 || index > buffer.Length - replacementBytes.Length)
                throw new IndexOutOfRangeException("Index must be greater than or equal to zero, and less than the length of the starting byte array less the length of replacement bytes.");

            byte[] result = new byte[buffer.Length];
            buffer[0..index].CopyTo(result, 0);
            replacementBytes.CopyTo(result, index);
            buffer[(index + replacementBytes.Length)..].CopyTo(result, index + replacementBytes.Length);

            return result;
        }

        /// <summary>
        /// Returns the results of BitConverter.GetBytes()
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] GetBytes(this int value) => BitConverter.GetBytes(value);

        /// <summary>
        /// Returns the results of BitConverter.GetBytes()
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] GetBytes(this uint value) => BitConverter.GetBytes(value);

        /// <summary>
        /// Returns the results of BitConverter.GetBytes()
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] GetBytes(this short value) => BitConverter.GetBytes(value);

        /// <summary>
        /// Returns the results of BitConverter.GetBytes()
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] GetBytes(this ushort value) => BitConverter.GetBytes(value);

        /// <summary>
        /// Returns the results of BitConverter.GetBytes()
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] GetBytes(this long value) => BitConverter.GetBytes(value);

        /// <summary>
        /// Returns the results of BitConverter.GetBytes()
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] GetBytes(this ulong value) => BitConverter.GetBytes(value);
    }
}