using Core.Exceptions;
using CSharpFunctionalExtensions;

namespace Core.Domain;

public class Language: ValueObject
{
    public string Value { get; }
    private Language(string value)
    {
        Value = value;
    }

    public static Result<Language, Error> Create(string? language)
    {
        if (string.IsNullOrWhiteSpace(language))
            return Errors.General.ValueIsRequired();

        language = language.Trim();
        language = language.ToUpperInvariant();

        if (language.Length != 2)
             return Errors.Language.InvalidLength();

        return new Language(language);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
