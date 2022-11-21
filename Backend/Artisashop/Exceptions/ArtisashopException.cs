namespace Artisashop.Exceptions;

using System;
using System.Runtime.Serialization;

/// <summary>
/// Exception de base Artisashop
/// </summary>
[Serializable]
public class ArtisashopException : Exception
{
    public ArtisashopException()
    {
    }

    public ArtisashopException(string message)
        : base(message)
    {
    }

    public ArtisashopException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    // Without this constructor, deserialization will fail
    protected ArtisashopException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}