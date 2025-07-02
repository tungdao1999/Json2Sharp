using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json2SharpLib.Enums.Typescript;

/// <summary>
/// Represent ways to combine different type of a same atrribute in JSON array.
/// </summary>
public enum TypeScriptCombineType : byte
{
    /// <summary>
    /// Use type any
    /// </summary>
    Any,

    /// <summary>
    /// Use union type
    /// </summary>
    Union
}
