using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroMu.Binary.Serialization
{
    /// <summary>
    /// Class which contains the logic to serialize a CLR object into a byte array.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinarySerializer<T>
    {
        private readonly BinarySerializationMethod<T> serializationMethod; 

        /// <summary>
        /// Creates a BinarySerializer instance with the provided serialization method.
        /// </summary>
        /// <param name="serializationMethod"></param>
        public BinarySerializer(BinarySerializationMethod<T> serializationMethod)
        {
            this.serializationMethod = serializationMethod;
        }

        /// <summary>
        /// Use the underlying serialization method to serialize
        /// the CLR object provided.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public byte[] Serialize(T obj)
        {
            return serializationMethod(obj);
        }
    }
}
