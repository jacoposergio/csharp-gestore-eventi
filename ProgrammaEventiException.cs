using System.Runtime.Serialization;

[Serializable]
internal class ProgrammaEventiException : Exception
{
    public ProgrammaEventiException()
    {
    }

    public ProgrammaEventiException(string? message) : base(message)
    {
    }

    public ProgrammaEventiException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected ProgrammaEventiException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}