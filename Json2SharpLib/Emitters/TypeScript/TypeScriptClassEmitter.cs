using Json2SharpLib.Emitters.Abstractions;
using Json2SharpLib.Enums;
using Json2SharpLib.Enums.Typescript;
using Json2SharpLib.Models;
using Json2SharpLib.Models.LanguageOptions;
using System.Text;
using System.Text.Json;

namespace Json2SharpLib.Emitters.TypeScript;
internal class TypeScriptClassEmitter : CodeEmitter
{
    private readonly string _export;
    private readonly string _exportType;
    private readonly string _targetType;
    private readonly bool _isMonoObject;
    private readonly string _indentationPadding;

    /// <summary>
    /// Creates an object that parses JSON data into TypeScript class.
    /// </summary>
    /// <param name="options">The parsing options.</param>
    internal TypeScriptClassEmitter(Json2SharpTypeScriptOptions options)
    {
        _export = "export";
        _targetType = options.TargetType.ToString().ToLowerInvariant();
        _exportType = options.ExportType is TypeScriptExportType.Default ?
                       "default" : String.Empty;
        _isMonoObject = options.IsMonoObject;

        _indentationPadding = new string(
           options.IndentationPaddingCharacter is IndentationCharacterType.Space ? ' ' : '\t',
           options.IndentationCharacterAmount
        );
    }

    /// <inheritdoc />
    public override string Parse(string objectName, JsonElement jsonElement)
        => InternalParse(objectName, jsonElement);

    /// <summary>
    /// Parse JSON data into class or interface in TypeScript.
    /// </summary>
    /// <param name="objectName">The name of the type.</param>
    /// <param name="jsonElement">The JSON element to be processed.</param>
    /// <returns></returns>
    private string InternalParse(string objectName, JsonElement jsonElement)
    {
        objectName = objectName.ToPascalCase();
        var properties = Json2Sharp.ParseProperties(jsonElement);

        if (properties.Count is 0)
            return string.Empty;

        var extraTypes = new List<string>();
        var stringBuilder = new StringBuilder();

        // Class declaration
        stringBuilder.Append($"{_export} {_exportType} {_targetType} {objectName}");
        stringBuilder.Append("{");

        BuildProperties(stringBuilder, extraTypes, properties);

        return "";
    }

    private void BuildProperties(StringBuilder stringBuilder, List<string> extraTypes, IReadOnlyList<ParsedJsonProperty> properties)
    {
        foreach (var property in properties)
        {

        }
    }

    /// <inheritdoc />
    protected override string ParseArrayType(ParsedJsonProperty property, IReadOnlyList<ParsedJsonProperty> childrenTypes, out string typeName) => throw new NotImplementedException();

    /// <inheritdoc />
    protected override string ParseCustomType(ParsedJsonProperty property) => throw new NotImplementedException();
}
