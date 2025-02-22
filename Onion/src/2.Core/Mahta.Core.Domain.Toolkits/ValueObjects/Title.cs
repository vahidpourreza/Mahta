﻿using Mahta.Core.Domain.Exceptions;
using Mahta.Core.Domain.ValueObjects;

namespace Mahta.Core.Domain.Toolkits.ValueObjects;
public class Title : BaseValueObject<Title>
{
    #region Properties
    public string Value { get; private set; }
    #endregion

    #region Constructors and Factories
    public static Title FromString(string value) => new Title(value);
    private Title(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidValueObjectStateException("ValidationErrorIsRequire {0}", nameof(Title));
        }
        if (value.Length < 2 || value.Length > 250)
        {
            throw new InvalidValueObjectStateException("ValidationErrorStringLength {0} {1} {2}", nameof(Title), "2", "250");
        }
        Value = value;
    }
    private Title()
    {

    }
    #endregion


    #region Equality Check
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    #endregion

    #region Operator Overloading
    public static explicit operator string(Title title) => title.Value;
    public static implicit operator Title(string value) => new(value);
    #endregion

    #region Methods
    public override string ToString() => Value;

    #endregion
}
