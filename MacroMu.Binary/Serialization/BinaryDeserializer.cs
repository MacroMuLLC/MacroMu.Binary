using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroMu.Binary.Serialization
{
    /// <summary>
    /// Class which contains the logic to deserialize a CLR object from a byte array.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinaryDeserializer<T>
    {
        private BinaryDeserializationMethod<T> deserializationMethod; 

        public BinaryDeserializer(BinaryDeserializationMethod<T> deserializationMethod)
        {
            this.deserializationMethod = deserializationMethod;
        }

        /// <summary>
        /// Use the underlying deserialization method to deserialize
        /// a CLR object from the binary provided.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public T Deserialize(byte[] data)
        {
            return deserializationMethod(data);
        }
    }
}
