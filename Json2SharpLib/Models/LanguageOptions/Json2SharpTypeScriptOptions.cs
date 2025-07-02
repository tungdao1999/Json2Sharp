using Json2SharpLib.Enums.Typescript;
using Json2SharpLib.Models.LanguageOptions.Abstractions;

namespace Json2SharpLib.Models.LanguageOptions;

/// <summary>
/// The parsing options for TypeScript types
/// </summary>
public sealed record Json2SharpTypeScriptOptions : BaseLanguageOptions
{
    /// <summary>
    /// Define whether nested JSON object or array will stay nested in Typescript object. <br />
    /// Default is <see langword="true"/>.
    /// </summary>
    public bool IsMonoObject { get; init; } = true;

    /// <summary>
    /// Define how a same properties in array will combined if there are more than one type. <br />
    /// Default is <see cref="TypeScriptCombineType.Any"/>
    /// </summary>
    public TypeScriptCombineType CombineType { get; init; } = TypeScriptCombineType.Any;

    /// <summary>
    /// Define how entity will be exported. <br />
    /// Default is <see cref="TypeScriptExportType.Named"/>
    /// </summary>
    public TypeScriptExportType ExportType { get; init; } = TypeScriptExportType.Named;

    /// <summary>
    /// Define the target type of export entity. <br />
    /// Default is <see cref="TypeScriptTargetType.Class"/>
    /// </summary>
    public TypeScriptTargetType TargetType { get; init; } = TypeScriptTargetType.Class;


}
