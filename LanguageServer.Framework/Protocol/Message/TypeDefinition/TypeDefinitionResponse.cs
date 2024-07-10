﻿using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmmyLua.LanguageServer.Framework.Protocol.Model;

namespace EmmyLua.LanguageServer.Framework.Protocol.Message.TypeDefinition;

[JsonConverter(typeof(TypeDefinitionResponseJsonConverter))]
public class TypeDefinitionResponse
{
    public Location? Result1 { get; set; }

    public List<Location>? Result2 { get; set; }

    public List<LocationLink>? Result3 { get; set; }

    public TypeDefinitionResponse(Location? result1)
    {
        Result1 = result1;
    }

    public TypeDefinitionResponse(List<Location>? result2)
    {
        Result2 = result2;
    }

    public TypeDefinitionResponse(List<LocationLink>? result3)
    {
        Result3 = result3;
    }
}

public class TypeDefinitionResponseJsonConverter : JsonConverter<TypeDefinitionResponse>
{
    public override TypeDefinitionResponse Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new UnreachableException();
    }

    public override void Write(Utf8JsonWriter writer, TypeDefinitionResponse value, JsonSerializerOptions options)
    {
        if (value.Result1.HasValue)
        {
            JsonSerializer.Serialize(writer, value.Result1.Value, options);
        }
        else if (value.Result2 != null)
        {
            JsonSerializer.Serialize(writer, value.Result2, options);
        }
        else if (value.Result3 != null)
        {
            JsonSerializer.Serialize(writer, value.Result3, options);
        }
        else
        {
            writer.WriteNullValue();
        }
    }
}
