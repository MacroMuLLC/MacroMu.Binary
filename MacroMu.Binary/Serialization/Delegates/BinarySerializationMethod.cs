using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroMu.Binary.Serialization
{
    /// <summary>
    /// Delegate which can be used to define custom logic for taking a CLR object
    /// and serializing it into a binary string.
    /// </summary>
    /// <typeparam name="T">Type of the object to be serialized</typeparam>
    /// <param name="obj">Object to be serialized</param>
    /// <returns></returns>
    public delegate byte[] BinarySerializationMethod<T>(T obj);
}
