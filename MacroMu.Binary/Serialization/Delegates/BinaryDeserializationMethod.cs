using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroMu.Binary.Serialization
{
    /// <summary>
    /// Delegate which can be used to define custom logic for taking a binary string
    /// and deserializing it into a CLR object.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="data"></param>
    /// <returns></returns>
    public delegate T BinaryDeserializationMethod<T>(byte[] data);
}
