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
    private readonly TypeScriptCombineType _combineType;
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
        _combineType = options.CombineType;

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

        if (_isMonoObject)
        {
            BuildMonoObject(stringBuilder, properties);
        }
        else
        {
            BuildObjects(stringBuilder, properties);
        }

        return stringBuilder.ToStringAndClear();
    }

    private void BuildMonoObject(StringBuilder stringBuilder, IReadOnlyList<ParsedJsonProperty> properties)
    {

        foreach (var property in properties)
        {
            // Processes custom types and nullable arrays

        }
    }

    private void BuildObjects(StringBuilder stringBuilder, IReadOnlyList<ParsedJsonProperty> properties)
    {
        // Define whether neccessary to define a root type
        var hasRootType = false;
        var typeMap = new Dictionary<string, string>();
        var jsonFirstElement = properties[0];

        switch 
        foreach (var property in properties)
        {
            if (HandleCustomType(stringBuilder, property, typeMap))
                continue;

        }
    }

    private bool HandleCustomType(StringBuilder stringBuilder, ParsedJsonProperty property, Dictionary<string, string> typeMap)
    {
        switch (property.JsonElement.ValueKind)
        {
            case JsonValueKind.Object:
                typeMap.Add(property, )
                return true;

        }
    }

    /// <inheritdoc />
    protected override string ParseArrayType(ParsedJsonProperty property, IReadOnlyList<ParsedJsonProperty> childrenTypes, out string typeName) => throw new NotImplementedException();

    /// <inheritdoc />
    protected override string ParseCustomType(ParsedJsonProperty property) => throw new NotImplementedException();
}
